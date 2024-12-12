using System;
using System.Collections.Generic;

namespace InventarioUCB_SPA.DataBaseApp.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Ci { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Rol { get; set; }

    public virtual ICollection<Registrosactividade> RegistrosactividadeIdAdminNavigations { get; } = new List<Registrosactividade>();

    public virtual ICollection<Registrosactividade> RegistrosactividadeIdUsuarioNavigations { get; } = new List<Registrosactividade>();

    public virtual ICollection<Solicitudesprestamo> Solicitudesprestamos { get; } = new List<Solicitudesprestamo>();
}
