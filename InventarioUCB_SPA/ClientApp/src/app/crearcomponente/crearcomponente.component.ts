import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'crearcomponente',
  templateUrl: './crearcomponente.component.html',
  styleUrls: ['./crearcomponente.component.css']
})
export class CrearComponenteComponent {

  componenteData = {
    CodigoUcb: '',
    CodigoComponente: '',
    NumeroSerie: '',
    Fabricante: '',
    DireccionEnlace: '',
    Nombre: '',
    Descripcion: '',
    IdCategoria: 0,
    Ubicacion: '',
    EstadoEquipo: '',
    Estado: '',
    Cantidad: 0,  // Campo cantidad agregado
  };

  constructor(private http: HttpClient, private router: Router) {}

  registrarComponente(): void {
    this.http.post('tu_api_base_url/componentes', this.componenteData).subscribe({
      next: (response) => {
        alert('Componente registrado correctamente');
        this.router.navigate(['/componentes']);  // Redirige a la página de componentes
      },
      error: (error) => {
        console.error('Error al registrar el componente:', error);
        alert('Ocurrió un error al registrar el componente.');
      },
    });
  }

}