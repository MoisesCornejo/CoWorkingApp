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

switch (rolSelected)
{
    // si es administrador
    case "1":
    {
        var menuAdminSelected = "";
        while (menuAdminSelected != "1" && menuAdminSelected != "2")
        {
            Console.WriteLine("Bienvenido Administrador " +
                              "\n 1. Administración de puestos " +
                              "\n 2. Administración de usuarios ");
            menuAdminSelected = Console.ReadLine();
        }

        switch (menuAdminSelected)
        {
            case "1":
            {
                var menuDeskSelected = "";
                while (menuDeskSelected != "1" 
                       && menuDeskSelected != "2" 
                       && menuDeskSelected != "3" 
                       && menuDeskSelected != "4")
                {
                    Console.WriteLine("Administración de puestos " +
                                      "\n 1. Crear puesto " +
                                      "\n 2. Editar puesto " +
                                      "\n 3. Eliminar puesto " +
                                      "\n 4. Bloquear puesto");
                    menuDeskSelected = Console.ReadLine();
                }
                
                switch (menuDeskSelected)
                {
                    case "1":
                        Console.WriteLine("Crear Puestos");
                        break;
                    case "2":
                        Console.WriteLine("Editar Puestos");
                        break;
                    case "3":
                        Console.WriteLine("Eliminar Puestos");
                        break;
                    case "4":
                        Console.WriteLine("Bloquear Puestos");
                        break;
                }

                break;
            }
            
            case "2":
            {
                var menuUserSelected = "";
                while (menuUserSelected != "1" 
                       && menuUserSelected != "2" 
                       && menuUserSelected != "3" 
                       && menuUserSelected != "4")
                {
                    Console.WriteLine("Administración de Usuarios " +
                                      "\n 1. Crear Usuario " +
                                      "\n 2. Editar Usuario " +
                                      "\n 3. Eliminar Usuario " +
                                      "\n 4. Cambiar Contraseña Usuario");
                    menuUserSelected = Console.ReadLine();
                }
                
                switch (menuUserSelected)
                {
                    case "1":
                        Console.WriteLine("Crear Usuario");
                        break;
                    case "2":
                        Console.WriteLine("Editar Usuario");
                        break;
                    case "3":
                        Console.WriteLine("Eliminar Usuario");
                        break;
                    case "4":
                        Console.WriteLine("Cambiar Contraseña Usuario");
                        break;
                }

                break;
            }
        }
        break;
    }
    // si es usuario
    case "2":
        break;
}

