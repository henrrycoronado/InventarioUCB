import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  isFormOpen = false;

  loginData = {
    email: '',
    password: '',
  };

  openForm() {
    this.isFormOpen = true;
  }

  closeForm() {
    this.isFormOpen = false;
  }

  submitForm() {
    alert(`Formulario enviado:\nCorreo: ${this.loginData.email}\nContraseña: ${this.loginData.password}`);
    this.loginData = { email: '', password: ''}; // Reiniciar datos del formulario
  }
  
}