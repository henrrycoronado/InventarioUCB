import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'solicitudesprestamo',
  templateUrl: './solicitudesprestamo.component.html',
  styleUrls: ['./solicitudesprestamo.component.css']
})
export class SolicitudesPrestamoComponent {

  solicitudesPrestamo: any[] = [
    {
      IdSolicitudPrestamo: 1,
      Estado: 'Aprobada',
      IdEquipoNavigation: {
        Nombre: 'Laptop Administrativa',
        EstadoEquipo: 'En uso',
      },
      IdSolicitudPrestamoNavigation: {
        FechaSolicitud: '2024-12-01',
        IdUsuarioNavigation: {
          Nombre: 'Juan',
          Apellido: 'Pérez',
        },
      },
    },
    {
      IdSolicitudPrestamo: 2,
      Estado: 'Pendiente',
      IdEquipoNavigation: {
        Nombre: 'Proyector Sala 3',
        EstadoEquipo: 'Disponible',
      },
      IdSolicitudPrestamoNavigation: {
        FechaSolicitud: '2024-12-05',
        IdUsuarioNavigation: {
          Nombre: 'Ana',
          Apellido: 'Gómez',
        },
      },
    },
    {
      IdSolicitudPrestamo: 3,
      Estado: 'Rechazada',
      IdEquipoNavigation: {
        Nombre: 'Impresora Oficina 1',
        EstadoEquipo: 'En reparación',
      },
      IdSolicitudPrestamoNavigation: {
        FechaSolicitud: '2024-12-10',
        IdUsuarioNavigation: {
          Nombre: 'Carlos',
          Apellido: 'Martínez',
        },
      },
    },
    {
      IdSolicitudPrestamo: 4,
      Estado: 'Aprobada',
      IdEquipoNavigation: {
        Nombre: 'Pantalla Interactiva',
        EstadoEquipo: 'Disponible',
      },
      IdSolicitudPrestamoNavigation: {
        FechaSolicitud: '2024-12-12',
        IdUsuarioNavigation: {
          Nombre: 'María',
          Apellido: 'Lopez',
        },
      },
    },
  ];; // Aquí se almacenará la lista de solicitudes

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.cargarSolicitudesPrestamo();
  }

  cargarSolicitudesPrestamo(): void {
    this.http.get<any[]>('tu_api_base_url/solicitudesprestamo/').subscribe({
      next: (data) => {
        this.solicitudesPrestamo = data;
        console.log('Solicitudes de préstamo cargadas:', this.solicitudesPrestamo);
      },
      error: (error) => {
        console.error('Error al cargar solicitudes de préstamo:', error);
      },
    });
  }

  redirigir(idSolicitudPrestamo: number): void {
    this.router.navigate(['/detalle-solicitud', idSolicitudPrestamo]);
  }

}