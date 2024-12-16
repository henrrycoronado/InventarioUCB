import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'solicitudesprestamo',
  templateUrl: './solicitudesprestamo.component.html',
  styleUrls: ['./solicitudesprestamo.component.css']
})
export class SolicitudesPrestamoComponent {

  solicitudesPrestamo: any[] = [];
  solicitudSeleccionada: any = null; // Solicitud actualmente seleccionada
  equipo:any;
  idEquipo:any;
  justificacion = ''; // Justificación para aprobar o rechazar

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    this.cargarSolicitudes();
  }

  cargarSolicitudes(): void {
    this.http.get<any[]>(this.baseUrl + 'solicitudprestamo/versolicitudes').subscribe(
      (data) => {
        this.solicitudesPrestamo = data;
        console.log(data);
      },
      (error) => {
        console.error('Error al cargar solicitudes:', error);
      }
    );
  }

  verDetallesSolicitud(solicitud: any): void {
    this.solicitudSeleccionada = solicitud;
    this.cargarEquipo();
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

    const payload = {
      idSolicitud: this.solicitudSeleccionada.IdSolicitudPrestamo,
      estado: 'Aprobada',
      justificacion: this.justificacion
    };

    this.http.post(this.baseUrl + 'prestamo/actualizarsolicitud', payload).subscribe(
      () => {
        alert('Solicitud aprobada correctamente.');
        this.cargarSolicitudes();
        this.cerrarDetalle();
      },
      (error) => {
        console.error('Error al aprobar la solicitud:', error);
      }
    );
  }

  cargarEquipo(): void {
    this.http.get<any>(`${this.baseUrl}equipo/VerDetalleEquipo/${this.idEquipo}`).subscribe(
      (data) => {
        console.log(data);
        this.equipo = data;
      },
      (error) => {
        console.error('Error al cargar equipo:', error);
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
        this.cargarSolicitudes();
        this.cerrarDetalle();
      },
      (error) => {
        console.error('Error al rechazar la solicitud:', error);
      }
    );
  }

}