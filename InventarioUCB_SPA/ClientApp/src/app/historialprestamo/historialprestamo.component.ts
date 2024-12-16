import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'historialprestamo',
  templateUrl: './historialprestamo.component.html',
  styleUrls: ['./historialprestamo.component.css']
})
export class HistorialPrestamoComponent {
  historialPrestamos: any[] = []; // Lista final que mostrará la tabla
  cargando: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(): void {
    const idUser = 1; // Aquí debes asignar el ID del usuario actual
    this.obtenerHistorialPrestamos(idUser);
  }

  obtenerHistorialPrestamos(idUser: any): void {
    this.cargando = true;
    // 1. Obtener la lista de préstamos
    this.http.get<any[]>(`${this.baseUrl}Prestamo/HistorialPrestamo/${idUser}`).subscribe(
      (prestamos) => {
        console.log(prestamos);
        const listaHistorial: any[] = [];

        prestamos.forEach((prestamo) => {
          // 2. Obtener la solicitud de préstamo asociada
          this.http
            .get<any>(`${this.baseUrl}solicitudprestamo/VerSolicitudes/`)
            .subscribe(
              (solicitud) => {
                console.log(solicitud);
                // Agregar la información al historial
                listaHistorial.push({
                  idPrestamo: prestamo.id,
                  fechaSolicitud: solicitud.fechaSolicitud || 'N/A',
                  fechaDevolucion: prestamo.fechaDevolucion || 'N/A',
                  estadoPrestamo: prestamo.estado || 'N/A'
                });
              },
              (error) => console.error('Error al obtener solicitud:', error)
            );
        });

        // Asignar la lista final después de cargar todo
        this.historialPrestamos = listaHistorial;
        this.cargando = false;
      },
      (error) => {
        console.error('Error al obtener historial de préstamos:', error);
        this.cargando = false;
      }
    );
  }
}