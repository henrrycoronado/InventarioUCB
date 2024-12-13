import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  usuarioData = {
    Ci: '',
    Nombre: '',
    Apellido: '',
    Correo: '',
    Contrasena: '',
    Telefono: '',
    Rol: '',
  };

  submitForm() {
    console.log('Datos del usuario:', this.usuarioData);
    this.http.post<number>(this.baseUrl + 'usuario/crearcuenta', {usuario:this.usuarioData, idAdministrador: 1}).subscribe({
      next: (result) => {
        console.log('Resultado:', result);
        alert(`Usuario registrado exitosamente.`);
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error('Error al enviar la solicitud:', error);
        alert(`Ocurrió un error: ${error.message}`);
      },
    });

    // Reinicia el formulario
    this.usuarioData = {
      Ci: '',
      Nombre: '',
      Apellido: '',
      Correo: '',
      Contrasena: '',
      Telefono: '',
      Rol: '',
    };
  }
}