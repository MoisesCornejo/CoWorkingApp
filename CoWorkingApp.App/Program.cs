using CoWorkingApp.App.Enums;
using CoWorkingApp.Data;

var rolSelected = "";

// mientras rolSelected sea diferente de 1 o 2 seguira el while
while (rolSelected != "1" && rolSelected != "2")
{
    Console.WriteLine("Bienvenido a CoWorkingApp " +
                      "\n Ingrese su rol: " +
                      "\n 1. Administrador " +
                      "\n 2. Usuario");
    rolSelected = Console.ReadLine();
}

// Al crear un enum debemos parsear el valor string a enum en este caso UserRole
switch (Enum.Parse<UserRole> (rolSelected))
{
    // si es administrador
    case UserRole.Admin:
    {
        var menuAdminSelected = "";
        while (menuAdminSelected != "1" && menuAdminSelected != "2")
        {
            Console.WriteLine("Bienvenido Administrador " +
                              "\n 1. Administración de puestos " +
                              "\n 2. Administración de usuarios ");
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
                
                switch (Enum.Parse<AdminUser>(menuAdminUser))
                {
                    case AdminUser.CrearUsuario:
                        Console.WriteLine("Crear Usuario");
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
                }
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

