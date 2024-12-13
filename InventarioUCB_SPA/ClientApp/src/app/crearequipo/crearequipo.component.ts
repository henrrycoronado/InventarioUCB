import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'crearequipo',
  templateUrl: './crearequipo.component.html',
  styleUrls: ['./crearequipo.component.css']
})
export class CrearEquipoComponent {

  isFormOpen = false;
  formData = {
    name: '',
    email: '',
    message: '',
    description:''
  };

  openForm() {
    this.isFormOpen = true;
  }

  closeForm() {
    this.isFormOpen = false;
  }

  submitForm() {
    alert(`Formulario enviado:\nNombre: ${this.formData.name}\nCorreo: ${this.formData.email}\nMensaje: ${this.formData.message}`);
    this.isFormOpen = false;
    this.formData = { name: '', email: '', message: '', description: '' }; // Reiniciar datos del formulario
  }

}