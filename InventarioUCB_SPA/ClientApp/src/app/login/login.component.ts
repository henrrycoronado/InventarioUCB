import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  constructor(private http: HttpClient,private router: Router, @Inject('BASE_URL') private baseUrl: string) 
  { }
;
  loginData = {
    Correo: '',
    Password: '',
  }; 

  submitForm() {
    console.log(this.loginData.Correo + " " + this.loginData.Password);
    this.http.post<number>(this.baseUrl + 'usuario/loggin', this.loginData).subscribe({
      next: (result) => {
        if(result == null)
        {
          alert(`Error al iniciar Sesion.`);
        }
        else{
          alert(`Sesion Iniciada Correctamente`);
        }
        console.log('Resultado:', result);
        
      },
      error: (error) => {
        console.error('Error al enviar la solicitud:', error);
        alert(`Ocurrió un error: ${error.message}`);
      },
    });
  
    this.loginData = { Correo: '', Password: '' }; // Reinicia el formulario
  }
}