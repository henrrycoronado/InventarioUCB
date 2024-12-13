import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'equipos',
  templateUrl: './equipos.component.html',
  styleUrls: ['./equipos.component.css']
})
export class EquiposComponent {
  equipos = [
    {
      CodigoUcb: 'UCB-001',
      CodigoEquipo: 'EQ-1001',
      NumeroSerie: 'SN12345',
      Fabricante: 'Dell',
      DireccionEnlace: 'http://example.com/equipo1',
      Nombre: 'Laptop Administrativa',
      Descripcion: 'Laptop para tareas administrativas',
      IdCategoria: 1,
      Ubicacion: 'Oficina 101',
      EstadoEquipo: 'Activo',
      Estado: 'En uso',
    },
    {
      CodigoUcb: 'UCB-002',
      CodigoEquipo: 'EQ-1002',
      NumeroSerie: 'SN67890',
      Fabricante: 'HP',
      DireccionEnlace: 'http://example.com/equipo2',
      Nombre: 'Impresora Color',
      Descripcion: 'Impresora de alta calidad para documentos',
      IdCategoria: 2,
      Ubicacion: 'Sala de impresión',
      EstadoEquipo: 'Inactivo',
      Estado: 'En reparación',
    },
    {
      CodigoUcb: 'UCB-003',
      CodigoEquipo: 'EQ-1003',
      NumeroSerie: 'SN24680',
      Fabricante: 'Lenovo',
      DireccionEnlace: 'http://example.com/equipo3',
      Nombre: 'Proyector Salón 3',
      Descripcion: 'Proyector para presentaciones en el Salón 3',
      IdCategoria: 3,
      Ubicacion: 'Salón 3',
      EstadoEquipo: 'Activo',
      Estado: 'Disponible',
    },
  ]; // Aquí se almacenará la lista de equipos

  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  ngOnInit(): void {
    this.cargarEquipos();
  }

  cargarEquipos(): void {
    this.http.get<any[]>(this.baseUrl + 'equipos/').subscribe({
      next: (data) => {
        this.equipos = data;
        console.log('Equipos cargados:', this.equipos);
      },
      error: (error) => {
        console.error('Error al cargar equipos:', error);
      },
    });
  }

  redirigir(id: string): void {
    // Cambia '/detalles-equipo' a la ruta deseada
    this.router.navigate(['/detalleequipo', id]);
  }
}