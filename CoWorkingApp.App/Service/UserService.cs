using CoWorkingApp.App.Enums;
using CoWorkingApp.Data;
using CoWorkingApp.Data.Utils;
using CoWorkingApp.Models;

namespace CoWorkingApp.App.Service;

public class UserService
{
    private UserData UserData { get; set; }
    
    public UserService(UserData userData)
    {
        this.UserData = new UserData();
    }

    public void ExecuteAction(AdminUser menuAdminUser)
    {
        switch (menuAdminUser)
        {
            case AdminUser.CrearUsuario:
                Console.WriteLine("Crear Usuario");
                var user = new User();
                Console.Write("Escriba el nombre del usuario: ");
                user.Name = Console.ReadLine();
                Console.Write("Escriba el apellido del usuario: ");
                user.LasName = Console.ReadLine();
                Console.Write("Escriba el correo del usuario: ");
                user.Email = Console.ReadLine();
                Console.Write("Escriba la contraseña del usuario: ");
                user.Password = EncryptData.GetPassword();

                UserData.CreateUser(user);
                
                // Verificar que el usuario se ha guardado
                var jsonManager = new JsonManager<User>();
                var users = jsonManager.GetCollection();
                Console.WriteLine("\nUsuarios guardados:");
                foreach (var u in users)
                {
                    Console.WriteLine($"Nombre: {u.Name}, Apellido: {u.LasName}, Email: {u.Email}");
                }
                
                Console.WriteLine("\nUsuario creado con exito");
                break;
            
            case AdminUser.EditarUsuario:
                Console.WriteLine("Editar Usuario");
                break;
            
            case AdminUser.EliminarUsuario:
                Console.WriteLine("Eliminar Usuario");
                break;
            
            case AdminUser.CambiarContraseña:
                Console.WriteLine("Cambiar Contraseña Usuario");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(menuAdminUser), menuAdminUser, null);
        }
    }
}