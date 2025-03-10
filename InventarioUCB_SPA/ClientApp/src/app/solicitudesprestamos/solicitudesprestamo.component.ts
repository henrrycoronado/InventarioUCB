import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'solicitudesprestamo',
  templateUrl: './solicitudesprestamo.component.html',
  styleUrls: ['./solicitudesprestamo.component.css']
})
export class SolicitudesPrestamoComponent {
  Id: number = 4;
  TipoSolicitudes: string = 'Pendiente';
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


  obtenerUsuarioRol(): void {
    this.http.get(`${this.baseUrl}usuario/VerRol/${this.Id}`, { responseType: 'text' }).subscribe(
      (rol) => {
        if (rol == null) {
          this.TipoSolicitudes = 'vacio';
        } else {
          if (rol === 'Administrativo') {
            this.TipoSolicitudes = 'Pendiente';
          } else if (rol === 'Root') {
            this.TipoSolicitudes = 'Aprobado_Fase1';
          } else {
            this.TipoSolicitudes = 'Aprobado_Fase2';
          }
        }
      },
      (error) => {
        console.error('Error al obtener el rol del usuario:', error);
      }
    );
    console.log(this.TipoSolicitudes);
  }
  

  obtenerSolicitudes(): void {
    this.cargandoSolicitudes = true;

    // 1. Obtener la lista de solicitudes
    this.http.get<any[]>(`${this.baseUrl}solicitudprestamo/VerSolicitudes/${this.TipoSolicitudes}`).subscribe(
      (solicitudes) => {
        solicitudes.forEach((solicitud) => {
          console.log(solicitud)
          // Inicializar una lista de equipos vacía para cada solicitud
          solicitud.equipos = [];

          // 2. Obtener los detalles de la solicitud
          this.http.get<any[]>(`${this.baseUrl}solicitudprestamo/VerDetalleSolicitud/${solicitud.id}`).subscribe(
            (detalles) => {
              detalles.forEach((detalle) => {
                console.log(detalle)
                // 3. Obtener la información del equipo para cada detalle
                this.http.get<any>(`${this.baseUrl}equipo/VerDetalleEquipo/${detalle.idEquipo}`).subscribe(
                  (equipo) => {
                    console.log(equipo)
                    // Agregar el equipo a la solicitud actual
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
    let estadoSiguiente: string = '';
    if(this.TipoSolicitudes == 'vacio' || this.TipoSolicitudes == 'Aprobada_Fase2'){
      return;
    }
    if(this.TipoSolicitudes == 'Pendiente'){
      estadoSiguiente = 'Aprobada_Fase1';
    }
    else if(this.TipoSolicitudes == 'Aprobada_Fase1'){
      estadoSiguiente = 'Aprobada_Fase2';
    }
    const payload = {
      idSolicitud: this.solicitudSeleccionada.IdSolicitudPrestamo,
      idAdministrador: this.Id
    };

    this.http.post(this.baseUrl + 'gestionarsolicitudes/AprobarSoicitud', payload).subscribe(
      () => {
        alert('Solicitud aprobada correctamente.');
        this.obtenerSolicitudes();
        this.cerrarDetalle();
      },
      (error) => {
        console.error('Error al aprobar la solicitud:', error);
      }
    );
  }

  rechazarSolicitud(): void {
    if (!this.justificacion.trim()) {
      alert('Por favor, proporciona una justificación.');
      return;
    }

    const payload = {
      idSolicitud: this.solicitudSeleccionada.IdSolicitudPrestamo,
      estado: 'Rechazada',
      justificacion: this.justificacion
    };

    this.http.post(this.baseUrl + 'prestamo/actualizarsolicitud', payload).subscribe(
      () => {
        alert('Solicitud rechazada correctamente.');
        this.obtenerSolicitudes();
        this.cerrarDetalle();
      },
      (error) => {
        console.error('Error al rechazar la solicitud:', error);
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