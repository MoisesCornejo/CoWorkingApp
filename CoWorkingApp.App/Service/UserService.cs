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
                
                Console.WriteLine("\nUsuario creado con exito");
                break;
            
            case AdminUser.EditarUsuario:
                Console.WriteLine("Editar Usuario");
                Console.Write("Escriba el correo del usuario: ");
                var userFound = UserData.FindByUser(Console.ReadLine());
                
                while (userFound == null)
                {
                    Console.WriteLine("Usuario no encontrado\nIntente nuevamente");
                    userFound = UserData.FindByUser(Console.ReadLine());
                }
                
                Console.Write("Escriba el nombre del usuario: ");
                userFound.Name = Console.ReadLine();
                Console.Write("Escriba el apellido del usuario: ");
                userFound.LasName = Console.ReadLine();
                Console.Write("Escriba el correo del usuario: ");
                userFound.Email = Console.ReadLine();
                Console.Write("Escriba la contraseña del usuario: ");
                userFound.Password = EncryptData.GetPassword();
                
                UserData.EditUser(userFound);
                Console.WriteLine("\nUsuario editado con exito");
                break;
            
            case AdminUser.EliminarUsuario:
                Console.WriteLine("Eliminar Usuario");
                Console.Write("Escriba el correo del usuario: ");
                var userFoundDelete = UserData.FindByUser(Console.ReadLine());
                
                while (userFoundDelete == null)
                {
                    Console.WriteLine("Usuario no encontrado\nIntente nuevamente");
                    userFoundDelete = UserData.FindByUser(Console.ReadLine());
                }
                
                Console.WriteLine($"¿Esta seguro que desea eliminar a {userFoundDelete.Name} {userFoundDelete.LasName}?\nSI/NO: ");

                if (Console.ReadLine() == "SI")
                {
                    UserData.DeleteUser(userFoundDelete.UserId);
                }
                else if (Console.ReadLine() == "NO")
                {
                    Console.WriteLine("Usuario no eliminado");
                }
                
                Console.Write("\nusuario eliminado con exito");
                break;
            
            case AdminUser.CambiarContraseña:
                Console.WriteLine("Cambiar Contraseña Usuario");
                Console.Write("Escriba el correo del usuario: ");
                var userFoundPassword = UserData.FindByUser(Console.ReadLine());
                
                while (userFoundPassword == null)
                {
                    Console.WriteLine("Usuario no encontrado\nIntente nuevamente");
                    userFoundPassword = UserData.FindByUser(Console.ReadLine());
                }
                
                Console.Write("Escriba la contraseña del usuario: ");
                userFoundPassword.Password = EncryptData.GetPassword();
                
                UserData.EditUser(userFoundPassword);
                Console.WriteLine("\nContraseña de usuario editada con exito");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(menuAdminUser), menuAdminUser, null);
        }
    }
}