using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace InventarioUCB_SPA.DataBaseApp.Models.Services;

public class UsuarioRepository : BaseRepository<Usuario>
{
    public UsuarioRepository(InventarioUcbContext context) : base(context) { }

    // Obtener usuarios por rol
    public List<Usuario> GetByRole(string rol)
    {
        return _context.Usuarios
            .Where(u => u.Rol == rol)
            .ToList();
    }

    // Verificar si un correo existe
    public bool ExistsByEmail(string correo)
    {
        return _context.Usuarios
            .Any(u => u.Correo == correo);
    }

    public bool ExistsByCI(string ci)
    {
        return _context.Usuarios
            .Any(u => u.Ci == ci);
    }
    public bool ExistsByTelefono(string telefono)
    {
        return _context.Usuarios
            .Any(u => u.Telefono == telefono);
    }
    public int? GetIdByLog(string correo, string password)
    {
        string hashedPassword = HashPassword(password);
        return _context.Set<Usuario>()
                .Where(e => e.Correo == correo && e.Contraseña == hashedPassword)
                .Select(e => e.Id)
                .FirstOrDefault();
    }

    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password); // Convierte la contraseña a bytes
            var hash = sha256.ComputeHash(bytes);         // Calcula el hash
            return BitConverter.ToString(hash).Replace("-", "").ToLower(); // Devuelve el hash como string en minúsculas
        }
    }

    public void CrearUser(Usuario user){
        user.Contraseña = HashPassword(user.Contraseña);
        Add(user);
    } 

}