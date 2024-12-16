import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-equipos',
  templateUrl: './equipos.component.html',
  styleUrls: ['./equipos.component.css']
})
export class EquiposComponent implements OnInit {
  equiponuevo:any;
  idAdministrador = 1;
  //codigoequipo:any ;

  equipos: any[] = [];
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
    EstadoEquipo: ''
  };
  categorias: any[] = [];
  
  mostrarFormulario = false; // Controla la visibilidad del formulario de registro
  modoEdicion = false; // Indica si estamos editando un equipo

  camposEquipo = [ // Configuración de los campos del equipo para el formulario dinámico
    { label: 'Código UCB', key: 'CodigoUcb' },
    { label: 'Código de Equipo', key: 'CodigoEquipo' },
    { label: 'Número de Serie', key: 'NumeroSerie' },
    { label: 'Fabricante', key: 'Fabricante' },
    { label: 'Dirección de Enlace', key: 'DireccionEnlace' },
    { label: 'Nombre del Equipo', key: 'Nombre' },
    { label: 'Descripción', key: 'Descripcion' },
    { label: 'Categoría', key: 'IdCategoria' },
    { label: 'Ubicación', key: 'Ubicacion' },
    { label: 'Estado del Equipo', key: 'EstadoEquipo' }
  ];  

  constructor(private http: HttpClient,private router: Router, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    this.cargarEquipos();
    this.cargarCategorias();
  }

  cargarEquipos(): void {
    this.http.get<any[]>(this.baseUrl + 'equipo/verequipos').subscribe(
      (data) => {
        console.log(data);
        this.equipos = data;
      },
      (error) => {
        console.error('Error al cargar equipos:', error);
      }
    );
  }

  seleccionarEquipo(equipo: any): void {
    //this.codigoequipo = equipo.codigoEquipo;
    this.equipoSeleccionado = { ...equipo };
     // Clonar para evitar mutaciones directas
    this.modoEdicion = false; // Asegúrate de que no está en modo edición
    this.mostrarFormulario = false; // Ocultar el formulario de registro si está abierto
  }

  cargarCategorias(): void {
    this.http.get<any[]>(this.baseUrl + 'categoria/vercategorias').subscribe(
      (data) => {
        console.log(data);
        this.categorias = data;
      },
      (error) => {
        console.error('Error al cargar categorías:', error);
      }
    );
  }

  habilitarEdicion(): void {
    this.modoEdicion = true;
  }

  guardarCambios(): void {

    const equipoEntradaUpdate = {
      equipo: {
        codigoEquipo: this.equipoSeleccionado.codigoEquipo,
        codigoUcb: this.equipoSeleccionado.codigoUcb,
        descripcion: this.equipoSeleccionado.descripcion,
        direccionEnlace: this.equipoSeleccionado.direccionEnlace,
        estadoEquipo: this.equipoSeleccionado.estadoEquipo,
        fabricante: this.equipoSeleccionado.fabricante,
        idCategoria: this.equipoSeleccionado.idCategoria,
        nombre: this.equipoSeleccionado.nombre,
        numeroSerie: this.equipoSeleccionado.numeroSerie,
        ubicacion: this.equipoSeleccionado.ubicacion,
      },
      idAdministrador: this.idAdministrador,
    };

    this.http.post(this.baseUrl + 'equipo/ActualizarEquipo', equipoEntradaUpdate).subscribe(
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
    this.cargarEquipos();
  }

  eliminarEquipo(): void {
    if (confirm('¿Estás seguro de que deseas eliminar este equipo?')) {
      const codigo = {codigoequipo:0, IdAdministrador:1};
      this.http.post(this.baseUrl + 'equipo/eliminarEquipo' , codigo).subscribe(
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
    this.cargarEquipos();
  }

  mostrarFormularioNuevoEquipo(): void {
    this.mostrarFormulario = true;
    this.equipoSeleccionado = null;
  }

  registrarEquipo(): void {
    this.equiponuevo = {equipo:this.equipoData, IdAdministrador: 1 }; 
    this.http.post('equipo/CrearEquipo', this.equiponuevo).subscribe(
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
    this.cargarEquipos();
  }
  resetearFormulario(): void {
    this.equipoData = { // Datos del nuevo equipo
      CodigoUcb: '',
      CodigoEquipo: '',
      NumeroSerie: '',
      Fabricante: '',
      DireccionEnlace: '',
      Nombre: '',
      Descripcion: '',
      IdCategoria: 0,
      Ubicacion: '',
      EstadoEquipo: ''
    };
  }
}
