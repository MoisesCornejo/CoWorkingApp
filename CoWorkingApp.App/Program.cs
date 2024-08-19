using CoWorkingApp.App.Enums;
using CoWorkingApp.App.Service;
using CoWorkingApp.Data;
using CoWorkingApp.Data.Utils;

var userData = new UserData();
var userService = new UserService(userData);

var rolSelected = "";

// mientras rolSelected sea diferente de 1 o 2 seguira el while
while (rolSelected != "1" && rolSelected != "2")
{
    Console.WriteLine("Bienvenido a CoWorkingApp " +
                      "\n 1. Administrador " +
                      "\n 2. Usuario");
    Console.Write("Ingrese su rol: ");
    rolSelected = Console.ReadLine();
}

// Al crear un enum debemos parsear el valor string a enum en este caso UserRole
switch (Enum.Parse<UserRole> (rolSelected))
{
    // si es administrador
    case UserRole.Admin:
    {
        var loginResult = false;

        while (!loginResult)
        {
            Console.Write("Ingrese su usuario: ");
            var user = Console.ReadLine();
            
            Console.Write("Ingrese su contraseña: ");
            var password = EncryptData.GetPassword();

            if (user != null) loginResult = userData.Login(user, password);

            if (!loginResult)
            {
                Console.WriteLine("\n\n#####\nUsuario o contraseña incorrecta\nintente nuevamente\n#####\n");
            }
        }
        
        var menuAdminSelected = "";
        while (menuAdminSelected != "1" && menuAdminSelected != "2")
        {
            Console.WriteLine("\nBienvenido Administrador " +
                              "\n 1. Administración de puestos " +
                              "\n 2. Administración de usuarios ");
            Console.Write("Ingrese opcion: ");
            menuAdminSelected = Console.ReadLine();
        }

        switch (Enum.Parse<MenuAdmin>(menuAdminSelected))
        {
            case MenuAdmin.AdminPuestos:
            {
                var menuAdminDesk = "";
                while (menuAdminDesk != "1" 
                       && menuAdminDesk != "2" 
                       && menuAdminDesk != "3" 
                       && menuAdminDesk != "4")
                {
                    Console.WriteLine("Administración de puestos " +
                                      "\n 1. Crear puesto " +
                                      "\n 2. Editar puesto " +
                                      "\n 3. Eliminar puesto " +
                                      "\n 4. Bloquear puesto");
                    menuAdminDesk = Console.ReadLine();
                }
                
                switch (Enum.Parse<AdminDesk>(menuAdminDesk))
                {
                    case AdminDesk.CrearPuesto:
                        Console.WriteLine("Crear Puestos");
                        break;
                    case AdminDesk.EditarPuesto:
                        Console.WriteLine("Editar Puestos");
                        break;
                    case AdminDesk.EliminarPuesto:
                        Console.WriteLine("Eliminar Puestos");
                        break;
                    case AdminDesk.BloquearPuesto:
                        Console.WriteLine("Bloquear Puestos");
                        break;
                }

                break;
            }
            
            case MenuAdmin.AdminUsuario:
            {
                var menuAdminUser = "";
                while (menuAdminUser != "1" 
                       && menuAdminUser != "2" 
                       && menuAdminUser != "3" 
                       && menuAdminUser != "4")
                {
                    Console.WriteLine("Administración de Usuarios " +
                                      "\n 1. Crear Usuario " +
                                      "\n 2. Editar Usuario " +
                                      "\n 3. Eliminar Usuario " +
                                      "\n 4. Cambiar Contraseña Usuario");
                    menuAdminUser = Console.ReadLine();
                }

                // parseamos el valor string a enum AdminUser
                var menuAdminUserSelected = Enum.Parse<AdminUser>(menuAdminUser);
                // ejecutamos el metodo ExecuteAction de la clase UserService
                userService.ExecuteAction(menuAdminUserSelected);
                break;
            }
        }
        break;
    }
    // si es usuario
    case UserRole.User:
        var menuUserSelected = "";

        while (menuUserSelected != "1" 
               && menuUserSelected != "2" 
               && menuUserSelected != "3" 
               && menuUserSelected != "4")
        {
            Console.WriteLine("Bienvenido Usuario " +
                              "\n 1. Reservar puesto " +
                              "\n 2. Cancelar reserva " +
                              "\n 3. Ver historial de reserva " +
                              "\n 4. Cambiar contraseña");
            menuUserSelected = Console.ReadLine();
        }

        switch (Enum.Parse<MenuUser>(menuUserSelected))
        {
            case MenuUser.ReservarPuesto:
                Console.WriteLine("Reserva de Puesto");
                break;
            case MenuUser.CancelarReserva:
                Console.WriteLine("Cancelar reserva");
                break;
            case MenuUser.HistorialReserva:
                Console.WriteLine("Ver historial de reservas");
                break;
            case MenuUser.CambiarContraseña:
                Console.WriteLine("Cambiar contraseña");
                break;
        }
        break;
}