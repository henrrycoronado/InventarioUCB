import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'soli',
  templateUrl: './solicitudesprestamo.component.html',
  styleUrls: ['./solicitudesprestamo.component.css']
})
export class SolicitudesPrestamoComponent {

  solicitudes: any[] = [];
  cargandoSolicitudes = false;
  solicitudSeleccionada: any = null; // Solicitud actualmente seleccionada
  equipo:any;
  idEquipo:any;
  justificacion = ''; // Justificación para aprobar o rechazar
  mostrarFormulario: boolean = false;
  fechaSolicitud: string = ''; // Fecha actual
  solicitud = {
    FechaSolicitud: '',
    FechaInicioPrestamo: '',
    FechaFinPrestamo: ''
  };
  equiposDisponibles: any[] = [];
  equiposSeleccionados: number[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    this.obtenerSolicitudes();
    this.obtenerEquiposDisponibles();
    this.fechaSolicitud = new Date().toISOString().split('T')[0];
  }

  obtenerEquiposDisponibles(): void {
    this.http.get<any[]>(`${this.baseUrl}equipo/VerEquipos`).subscribe(
      (equipos) => {
        this.equiposDisponibles = equipos;
      },
      (error) => {
        console.error('Error al obtener equipos:', error);
      }
    );
  }

  obtenerSolicitudes(): void {
    this.cargandoSolicitudes = true;

    this.http.get<any[]>(`${this.baseUrl}solicitudprestamo/VerSolicitudes`).subscribe(
      (solicitudes) => {
        solicitudes.forEach((solicitud) => {
          console.log(solicitud)
          solicitud.equipos = [];

          this.http.get<any[]>(`${this.baseUrl}solicitudprestamo/VerDetalleSolicitud/${solicitud.id}`).subscribe(
            (detalles) => {
              detalles.forEach((detalle) => {
                console.log(detalle)
                this.http.get<any>(`${this.baseUrl}equipo/VerDetalleEquipo/${detalle.idEquipo}`).subscribe(
                  (equipo) => {
                    console.log(equipo)
                    solicitud.equipos.push(equipo);
                  },
                  (error) => console.error('Error al obtener detalle del equipo:', error)
                );
              });
            },
            (error) => console.error('Error al obtener detalles de la solicitud:', error)
          );
        });
        this.solicitudes = solicitudes;
        this.cargandoSolicitudes = false;
      },
      (error) => {
        console.error('Error al obtener solicitudes:', error);
        this.cargandoSolicitudes = false;
      }
    );
  }

  verDetallesSolicitud(solicitud: any): void {
    this.solicitudSeleccionada = solicitud;
    this.idEquipo = this.solicitudSeleccionada.idEquipo;
    this.justificacion = '';
  }

  cerrarDetalle(): void {
    this.solicitudSeleccionada = null;
    this.justificacion = '';
  }

  aprobarSolicitud(): void {
    if (!this.justificacion.trim()) {
      alert('Por favor, proporciona una justificación.');
      return;
    }

    const request = {
      IdElement1: this.solicitudSeleccionada.id,
      IdElement2: 1
    };
    console.log(request);
    this.http.post(this.baseUrl + 'gestionarsolicitudes/aprobar', request).subscribe(
      () => {
        alert('Solicitud aprobada correctamente.');
        this.obtenerSolicitudes();
        this.cerrarDetalle();

      },
      (error) => {
        console.error('Error al aprobar la solicitud:', error);
        alert('Error en la aprobacion');
      }
    );
  }

  rechazarSolicitud(): void {
    if (!this.justificacion.trim()) {
      alert('Por favor, proporciona una justificación.');
      return;
    }

    const request = {
      IdElement1: this.solicitudSeleccionada.id,
      IdElement2: 1
    };

    this.http.post(this.baseUrl + 'gestionarsolicitudes/rechazar', request).subscribe(
      () => {
        alert('Solicitud rechazada correctamente.');
        this.obtenerSolicitudes();
        this.cerrarDetalle();
      },
      (error) => {
        console.error('Error al rechazar la solicitud:', error);
        alert('Error al rechazar la solicitud');
      }
    );
  }

  registrarSolicitud(): void {
    // Paso 1: Registrar la solicitud de préstamo
    const nuevaSolicitud = {
      IdUsuario: 1, // Usuario siempre es 1
      FechaSolicitud: this.fechaSolicitud, // Usamos la fecha actual
      FechaInicioPrestamo: this.solicitud.FechaInicioPrestamo,
      FechaFinPrestamo: this.solicitud.FechaFinPrestamo,
      Estado: 'Pendiente' // Estado siempre es "Pendiente"
    };

    this.http.post<boolean>(`${this.baseUrl}solicitudprestamo/EnviarSolicitud`, nuevaSolicitud).subscribe(
      (exito) => {
        if (exito) {
          // Si la solicitud se registra correctamente, se recibe el ID de la solicitud
          this.agregarDetallesEquipos();
        } else {
          console.error('Error al registrar la solicitud');
        }
      },
      (error) => {
        console.error('Error al registrar solicitud:', error);
      }
    );
  }

  agregarDetallesEquipos(): void {
    // Paso 2: Agregar los detalles para cada equipo seleccionado
    const idSolicitud = 1; // El ID de la solicitud debe ser retornado por el backend
    this.equiposSeleccionados.forEach((idEquipo) => {
      const request = { IdElement1: idSolicitud, IdElement2: idEquipo };
      
      this.http.post<string>(`${this.baseUrl}solicitudprestamo/AgregarDetalle`, request).subscribe(
        (resultado) => {
          console.log(`Detalle agregado: ${resultado}`);
        },
        (error) => {
          console.error('Error al agregar detalle:', error);
        }
      );
    });
  }

}