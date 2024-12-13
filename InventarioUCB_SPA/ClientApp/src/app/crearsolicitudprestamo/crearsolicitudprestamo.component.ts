import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'crearsolicitudprestamo',
  templateUrl: './crearsolicitudprestamo.component.html',
  styleUrls: ['./crearsolicitudprestamo.component.css']
})
export class CrearSolicitudPrestamoComponent {
  solicitudData = {
    CodigoUcb: '',
    FechaInicioPrestamo: '',
    FechaFinPrestamo: '',
    MotivoPrestamo: '',
    FechaSolicitud: new Date().toISOString().split('T')[0],  // Fecha actual
    Estado: 'Pendiente',  // Estado inicial
  };

  constructor(private http: HttpClient, private router: Router) {}

  registrarSolicitud(): void {

    if (this.solicitudData.FechaFinPrestamo < this.solicitudData.FechaInicioPrestamo) {
      alert('La fecha de fin no puede ser menor que la fecha de inicio.');
      return;
    }

    this.http.post('tu_api_base_url/solicitudesprestamo', this.solicitudData).subscribe({
      next: (response) => {
        alert('Solicitud de préstamo registrada correctamente');
        this.router.navigate(['/solicitudes']);  // Redirige a la página de solicitudes
      },
      error: (error) => {
        console.error('Error al registrar la solicitud:', error);
        alert('Ocurrió un error al registrar la solicitud.');
      },
    });
  }
}