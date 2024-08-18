using CoWorkingApp.Data.Utils;
using CoWorkingApp.Models;
using Newtonsoft.Json;

namespace CoWorkingApp.Data;

public class UserData
{
    // Creamos variable de tipo JsonManager para poder utilizar los metodos de la clase JsonManager
    private JsonManager<User> JsonManager;

    // Constructor de la clase UserData
    public UserData()
    {
        // Initializamos la variable JsonManager de tipo User
        JsonManager = new JsonManager<User>();
    }

    public bool CreateAdmin()
    {
        var userCollection = JsonManager.GetCollection();

        // verificamos si el admin existe o no (LINQ)
        // utilizamos el metodo Any() para verificar si existe algun elemento que cumpla con la condicion
        // // en este caso utilizamos la negacion para verificar que no existe ninguna coincidencia
        if (!userCollection.Any(p => p.Name == "ADMIN" && p.LasName == "ADMIN" && p.Email == "ADMIN")) 
        {
            try
            {
                // creamos nuevo adminUser de tipo User
                var adminUser = new User() 
                { // inicializamos los valores del admin
                    UserId = Guid.NewGuid(),
                    Name = "ADMIN",
                    LasName = "ADMIN",
                    Email = "ADMIN",
                    Password = EncryptData.EncryptText("admin")
                };
                // agregamos el adminUser a la coleccion de usuarios
                userCollection.Add(adminUser);
                // guardamos la coleccion de usuarios en el archivo json
                JsonManager.SaveCollection(userCollection);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        return true;
    }

    public bool Login(string? user, string? password, bool isAdmin = false)
    {
        // obtenemos la coleccion de usuarios
        var userCollection = JsonManager.GetCollection();
        // encriptamos la contraseña
        var passwordEncrypted = EncryptData.EncryptText(password);
        // si el usuario es admin, asignamos el valor "ADMIN" a la variable user
        if (isAdmin) user = "ADMIN";
        // buscamos el usuario en la coleccion de usuarios
        var userFound = userCollection.FirstOrDefault(p => p.Email == user && p.Password == passwordEncrypted);
        // retornamos si el usuario fue encontrado o no
        return userFound != null;
    }
}