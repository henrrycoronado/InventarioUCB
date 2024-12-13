import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'componentes',
  templateUrl: './componentes.component.html',
  styleUrls: ['./componentes.component.css']
})
export class ComponentesComponent {
  
  codigoequipo : any;
  equiponuevo : any = '';

  equipos : any[] = []; // Lista de equipos cargada desde la API
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

  constructor(private http: HttpClient,private router: Router, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    this.cargarEquipos();
  }

  cargarEquipos(): void {
    
    this.http.get<any[]>(this.baseUrl + 'equipo/VerEquipos').subscribe(
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
    this.codigoequipo = this.equipoSeleccionado.codigoEquipo;
    this.modoEdicion = false; // Asegúrate de que no está en modo edición
    this.mostrarFormulario = false; // Ocultar el formulario de registro si está abierto
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
        estado: this.equipoSeleccionado.estado,
        estadoEquipo: this.equipoSeleccionado.estadoEquipo,
        fabricante: this.equipoSeleccionado.fabricante,
        idCategoria: this.equipoSeleccionado.idCategoria,
        nombre: this.equipoSeleccionado.nombre,
        numeroSerie: this.equipoSeleccionado.numeroSerie,
        ubicacion: this.equipoSeleccionado.ubicacion,
      },
      IdAdministrador: 1,
    };

    
    this.http.put(`this.baseUrl + 'usuario/'${this.equipoSeleccionado.id}`, equipoEntradaUpdate).subscribe(
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
      const codigo = {codigoequipo:this.codigoequipo, IdAdministrador:1};
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
  }

  mostrarFormularioNuevoEquipo(): void {
    this.mostrarFormulario = true;
    this.equipoSeleccionado = null;
  }

  registrarEquipo(): void {

    const equipoEntradaUpdate = {
      equipo: {
        CodigoEquipo: this.equipoSeleccionado.codigoEquipo,
        CodigoUcb: this.equipoSeleccionado.codigoUcb,
        Descripcion: this.equipoSeleccionado.descripcion,
        DireccionEnlace: this.equipoSeleccionado.direccionEnlace,
        Estado: this.equipoSeleccionado.estado,
        EstadoEquipo: this.equipoSeleccionado.estadoEquipo,
        Fabricante: this.equipoSeleccionado.fabricante,
        IdCategoria: this.equipoSeleccionado.idCategoria,
        Nombre: this.equipoSeleccionado.nombre,
        NumeroSerie: this.equipoSeleccionado.numeroSerie,
        Ubicacion: this.equipoSeleccionado.ubicacion,
      },
      IdAdministrador: 1
    };

    this.equiponuevo = {equipo:this.equipoData, IdAdministrador: 0 }; 
    this.http.post('componente/crearequipo', equipoEntradaUpdate).subscribe(
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
