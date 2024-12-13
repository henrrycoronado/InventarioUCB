import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class testComponent {

  constructor(private http: HttpClient,private router: Router, @Inject('BASE_URL') private baseUrl: string) 
  { 
    this.prueba_get();
  }

  prueba_get()
  {
    this.http.get<Equipo[]>(this.baseUrl + 'equipo/seeEquipos').subscribe(
      result=>{
        console.log(result);
      }, error=>{console.log("error");})
  }

  prueba_post(Id_equipo: string, Codigo_Equipo: string, Nombre_equipo: string, Estado_Equipo: string, Detalle_equipo: string) {
    // Convertir el Id_equipo a número
    const idEquipoNumber = Number(Id_equipo);

    // Crear el objeto equipo basado en los parámetros recibidos
    const nuevoEquipo = {
      Id_equipo: idEquipoNumber,
      Codigo_Equipo,
      Nombre_equipo,
      Estado_Equipo,
      Detalle_equipo
    };

    // Hacer la solicitud POST
    this.http.post<any>(this.baseUrl + 'equipo/addEquipo', nuevoEquipo)
      .subscribe(
        result => {
          console.log('Success:', result);
          alert('Equipo registrado con éxito');
        },
        error => {
          console.error('Error:', error);
          alert('Error al registrar el equipo');
        }
      );
  }
}

interface Equipo
{
  Id_equipo: number;
  Codigo_Equipo: string;
  Nombre_equipo: string
  Estado_Equipo: string;
  Detalle_equipo: string;
}