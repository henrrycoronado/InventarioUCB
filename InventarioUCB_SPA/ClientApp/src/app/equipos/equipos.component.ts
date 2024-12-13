import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-equipos',
  templateUrl: './equipos.component.html',
  styleUrls: ['./equipos.component.css']
})
export class EquiposComponent implements OnInit {
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
  ]; // Lista de equipos cargada desde la API
  equipoSeleccionado: any = null; // Equipo actualmente seleccionado para mostrar detalles
  equipoData = { // Datos del nuevo equipo
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
  mostrarFormulario = false; // Controla la visibilidad del formulario de registro
  modoEdicion = false; // Indica si estamos editando un equipo

  camposEquipo = [ // Configuración de los campos del equipo para el formulario dinámico
    { label: 'Código UCB', key: 'CodigoUcb' },
    { label: 'Código de Equipo', key: 'CodigoEquipo' },
    { label: 'Número de Serie', key: 'NumeroSerie' },
    { label: 'Fabricante', key: 'Fabricante' },
    { label: 'Dirección de Enlace', key: 'DireccionEnlace' },
    { label: 'Nombre', key: 'Nombre' },
    { label: 'Descripción', key: 'Descripcion' },
    { label: 'Categoría', key: 'IdCategoria' },
    { label: 'Ubicación', key: 'Ubicacion' },
    { label: 'Estado del Equipo', key: 'EstadoEquipo' },
    { label: 'Estado', key: 'Estado' },
  ];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.cargarEquipos();
  }

  cargarEquipos(): void {
    this.http.get<any[]>('tu_api_base_url/equipos').subscribe(
      (data) => {
        this.equipos = data;
      },
      (error) => {
        console.error('Error al cargar equipos:', error);
      }
    );
  }

  seleccionarEquipo(equipo: any): void {
    this.equipoSeleccionado = { ...equipo }; // Clonar para evitar mutaciones directas
    this.modoEdicion = false; // Asegúrate de que no está en modo edición
    this.mostrarFormulario = false; // Ocultar el formulario de registro si está abierto
  }
  

  habilitarEdicion(): void {
    this.modoEdicion = true;
  }

  guardarCambios(): void {
    this.http.put(`tu_api_base_url/equipos/${this.equipoSeleccionado.id}`, this.equipoSeleccionado).subscribe(
      () => {
        alert('Equipo actualizado correctamente');
        this.cargarEquipos(); // Recargar la lista de equipos
        this.modoEdicion = false;
      },
      (error) => {
        console.error('Error al actualizar el equipo:', error);
        alert('Ocurrió un error al actualizar el equipo.');
      }
    );
  }

  eliminarEquipo(): void {
    if (confirm('¿Estás seguro de que deseas eliminar este equipo?')) {
      this.http.delete(`tu_api_base_url/equipos/${this.equipoSeleccionado.id}`).subscribe(
        () => {
          alert('Equipo eliminado correctamente');
          this.cargarEquipos(); // Recargar la lista de equipos
          this.equipoSeleccionado = null;
        },
        (error) => {
          console.error('Error al eliminar el equipo:', error);
          alert('Ocurrió un error al eliminar el equipo.');
        }
      );
    }
  }

  mostrarFormularioNuevoEquipo(): void {
    this.mostrarFormulario = true;
    this.equipoSeleccionado = null;
  }

  registrarEquipo(): void {
    this.http.post('tu_api_base_url/equipos', this.equipoData).subscribe(
      () => {
        alert('Equipo registrado correctamente');
        this.cargarEquipos();
        this.mostrarFormulario = false;
        this.resetearFormulario();
      },
      (error) => {
        console.error('Error al registrar el equipo:', error);
        alert('Ocurrió un error al registrar el equipo.');
      }
    );
  }

  resetearFormulario(): void {
    this.equipoData = {
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
  }
}
