import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'crearequipo',
  templateUrl: './crearequipo.component.html',
  styleUrls: ['./crearequipo.component.css']
})
export class CrearEquipoComponent {

  equipoData = {
    CodigoUcb: '',
    CodigoEquipo: '',
    NumeroSerie: '',
    Fabricante: '',
    DireccionEnlace: '',
    Nombre: '',
    Descripcion: '',
    IdCategoria: 0,
    Ubicacion: '',
    EstadoEquipo: '',
    Estado: '',
  };

  constructor(private http: HttpClient, private router: Router) {}

  registrarEquipo(): void {
    this.http.post('tu_api_base_url/equipos', this.equipoData).subscribe({
      next: (response) => {
        alert('Equipo registrado correctamente');
        this.router.navigate(['/equipos']);
      },
      error: (error) => {
        console.error('Error al registrar el equipo:', error);
        alert('Ocurrió un error al registrar el equipo.');
      },
    });
  }

}