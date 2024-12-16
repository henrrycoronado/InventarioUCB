import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { testComponent } from './test/test.component';
import { ActualizarComponenteComponent } from './actualizarcomponente/actualizarcomponente.component';
import { ActualizarEquipoComponent } from './actualizarequipo/actualizarequipo.component';
import { BusquedaCategoriaComponent } from './busquedacategoria/busquedacategoria.component';
import { ComponentesComponent } from './componentes/componentes.component';
import { CrearCategoriaComponent } from './crearcategoria/crearcategoria.component';
import { CrearComponenteComponent } from './crearcomponente/crearcomponente.component';
import { CrearEquipoComponent } from './crearequipo/crearequipo.component';
import { CrearSolicitudPrestamoComponent } from './crearsolicitudprestamo/crearsolicitudprestamo.component';
import { DetalleComponenteComponent } from './detallecomponente/detallecomponente.component';
import { DetalleEquipoComponent } from './detalleequipo/detalleequipo.component';
import { DetalleSolicitudComponent } from './destallesolicitud/detallesolicitud.component';
import { DevolucionPrestamoComponent } from './devolucionprestamo/devolucionprestamo.component';
import { EquiposComponent } from './equipos/equipos.component';
import { FormularioResponsabilidadComponent } from './formularioresponsabilidad/formularioresponsabilidad.component';
import { GestionarSolicitudComponent } from './gestionarsolicitud/gestionarsolicitud.component';
import { HistorialPrestamoComponent } from './historialprestamo/historialprestamo.component';
import { HistorialSolicitudComponent } from './historialsolicitudes/historialsolicitud.component';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { ReportesComponent } from './reportes/reportes.component';
import { SolicitudesPrestamoComponent } from './solicitudesprestamos/solicitudesprestamo.component';
import { SolicitudesAprobadasComponent } from './solictudesaprobadas/solicitudesaprobadas.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    testComponent,
    ActualizarComponenteComponent,
    ActualizarEquipoComponent,
    BusquedaCategoriaComponent,
    ComponentesComponent,
    CrearCategoriaComponent,
    CrearComponenteComponent,
    CrearEquipoComponent,
    CrearSolicitudPrestamoComponent,
    DetalleComponenteComponent,
    DetalleEquipoComponent,
    DetalleSolicitudComponent,
    DevolucionPrestamoComponent,
    EquiposComponent,
    FormularioResponsabilidadComponent,
    GestionarSolicitudComponent,
    HistorialPrestamoComponent,
    HistorialSolicitudComponent,
    LoginComponent,
    RegistroComponent,
    ReportesComponent,
    SolicitudesPrestamoComponent,
    SolicitudesAprobadasComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'test', component: testComponent} ,
      { path: 'actualizarcomponente', component: ActualizarComponenteComponent },
      { path: 'actualizarequipo', component: ActualizarEquipoComponent },
      { path: 'buscarcategoria', component: BusquedaCategoriaComponent },
      { path: 'componentes', component: ComponentesComponent },
      { path: 'crearcategoria', component: CrearCategoriaComponent },
      { path: 'crearcomponente', component: CrearComponenteComponent },
      { path: 'crearequipo', component: CrearEquipoComponent },
      { path: 'crearsolicitudprestamo', component: CrearSolicitudPrestamoComponent },
      { path: 'detallecomponentes', component: DetalleComponenteComponent },
      { path: 'detalleequipo', component: DetalleEquipoComponent },
      { path: 'detallesolicitud', component: DetalleSolicitudComponent },
      { path: 'devoluvionprestamo', component: DevolucionPrestamoComponent },
      { path: 'equipos', component: EquiposComponent },
      { path: 'formularioresponsabilidad', component: FormularioResponsabilidadComponent },
      { path: 'gestionsolicitud', component: GestionarSolicitudComponent },
      { path: 'historialprestamo', component: HistorialPrestamoComponent },
      { path: 'historialsolicitud', component: HistorialSolicitudComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registro', component: RegistroComponent },
      { path: 'reportes', component: ReportesComponent },
      { path: 'solicitudesprestamo', component: SolicitudesPrestamoComponent }, 
      { path: 'solicitudesaprobadas', component: SolicitudesAprobadasComponent }, //gestionaraprobaciones
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
