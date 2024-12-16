import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'crearcategoria',
  templateUrl: './crearcategoria.component.html',
  styleUrls: ['./crearcategoria.component.css']
})
export class CrearCategoriaComponent {

  categorias: any[] = [];
  categoriaSeleccionada: any = null; // Categoría actualmente seleccionada para mostrar detalles
  categoriaData = { // Datos de la nueva categoría
    nombre: '',
    area: []
  };
  mostrarFormulario = false; // Controla la visibilidad del formulario de registro
  modoEdicion = false; // Indica si estamos editando una categoría

  camposCategoria = [ // Configuración de los campos de la categoría para el formulario dinámico
    { label: 'Nombre', key: 'nombre' },
    { label: 'Área', key: 'area' }
  ];

  opcionesArea = ['Aula', 'Laboratorio', 'Taller']; // Opciones disponibles para el área

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    this.cargarCategorias();
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

  seleccionarCategoria(categoria: any): void {
    this.categoriaSeleccionada = { ...categoria }; // Clonar para evitar mutaciones directas
    this.modoEdicion = false; // Asegúrate de que no está en modo edición
    this.mostrarFormulario = false; // Ocultar el formulario de registro si está abierto
  }

  habilitarEdicion(): void {
    this.modoEdicion = true;
  }

  guardarCambios(): void {
    const categoriaEntradaUpdate = {
      categoria: {
        nombre: this.categoriaSeleccionada.nombre,
        area: this.categoriaSeleccionada.area
      }
    };

    this.http.post(this.baseUrl + 'categoria/actualizarcategoria', categoriaEntradaUpdate).subscribe(
      () => {
        alert('Categoría actualizada correctamente');
        this.cargarCategorias(); // Recargar la lista de categorías
        this.modoEdicion = false;
      },
      (error) => {
        console.error('Error al actualizar la categoría:', error);
        alert('Ocurrió un error al actualizar la categoría.');
      }
    );
  }

  cancelarEdicion(): void {
    this.modoEdicion = false;
    this.categoriaSeleccionada = null; // Ocultar los detalles
  }

  eliminarCategoria(): void {
    if (confirm('¿Estás seguro de que deseas eliminar esta categoría?')) {
      const nombre = { nombre: this.categoriaSeleccionada.nombre };
      this.http.post(this.baseUrl + 'categoria/eliminarcategoria', nombre).subscribe(
        () => {
          alert('Categoría eliminada correctamente');
          this.cargarCategorias(); // Recargar la lista de categorías
          this.categoriaSeleccionada = null;
        },
        (error) => {
          console.error('Error al eliminar la categoría:', error);
          alert('Ocurrió un error al eliminar la categoría.');
        }
      );
    }
  }

  mostrarFormularioNuevaCategoria(): void {
    this.mostrarFormulario = true;
    this.categoriaSeleccionada = null;
  }

  registrarCategoria(): void {
    const nuevaCategoria = {
      nombre: this.categoriaData.nombre,
      area: this.categoriaData.area
    };
    this.http.post(this.baseUrl + 'categoria/crearcategoria', nuevaCategoria).subscribe(
      () => {
        alert('Categoría registrada correctamente');
        this.cargarCategorias();
        this.mostrarFormulario = false;
        this.resetearFormulario();
      },
      (error) => {
        console.error('Error al registrar la categoría:', error);
        alert('Ocurrió un error al registrar la categoría.');
      }
    );
  }

  cancelarFormulario(): void {
    this.mostrarFormulario = false;
    this.resetearFormulario();
  }

  resetearFormulario(): void {
    this.categoriaData = { // Datos de la nueva categoría
      nombre: '',
      area: []
    };
  }

}