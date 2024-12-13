import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'crearcomponente',
  templateUrl: './crearcomponente.component.html',
  styleUrls: ['./crearcomponente.component.css']
})
export class CrearComponenteComponent {

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