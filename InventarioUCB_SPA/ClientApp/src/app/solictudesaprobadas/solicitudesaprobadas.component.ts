import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'solicitudesaprobadas',
  templateUrl: './solicitudesaprobadas.component.html',
  styleUrls: ['./solicitudesaprobadas.component.css']
})
export class SolicitudesAprobadasComponent {

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
  equiposSeleccionados: number[] = []; // Almacena los IDs de los equipos seleccionados

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    this.obtenerSolicitudes();
    this.obtenerEquiposDisponibles();
    this.fechaSolicitud = new Date().toISOString().split('T')[0]; // Obtener la fecha actual (YYYY-MM-DD)
  }

  obtenerEquiposDisponibles(): void {
    // Obtener los equipos disponibles para prestar
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

    this.http.get<any[]>(`${this.baseUrl}solicitudprestamo/VerSolicitudesAceptadas`).subscribe(
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

        // Asignar las solicitudes finales al arreglo
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
    this.http.post(this.baseUrl + 'gestionaraprobaciones/aprobar', request).subscribe(
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

    this.http.post(this.baseUrl + 'gestionaraprobaciones/rechazar', request).subscribe(
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
    const nuevaSolicitud = {
      IdUsuario: 1,
      FechaSolicitud: this.fechaSolicitud, 
      FechaInicioPrestamo: this.solicitud.FechaInicioPrestamo,
      FechaFinPrestamo: this.solicitud.FechaFinPrestamo,
      Estado: 'Pendiente'
    };

    this.http.post<boolean>(`${this.baseUrl}solicitudprestamo/EnviarSolicitud`, nuevaSolicitud).subscribe(
      (exito) => {
        if (exito) {
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
    const idSolicitud = 1; 
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