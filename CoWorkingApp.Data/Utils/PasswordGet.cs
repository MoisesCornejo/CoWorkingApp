namespace CoWorkingApp.Data.Utils;

public static class PasswordGet
{
    // creamos metodo para que no se muestre la contraseña
    public static string GetPassword()
    {
        var passwordInput = "";

        while (true)
        {
            var keyPress = Console.ReadKey(true);

            if (keyPress.Key == ConsoleKey.Enter)
            {
                Console.Write(" ");
                break;
            }
            else if (keyPress.Key == ConsoleKey.Backspace)
            {
                if (passwordInput.Length > 0)
                {
                    passwordInput = passwordInput.Substring(0, passwordInput.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else if (keyPress.Key != ConsoleKey.Spacebar)
            {
                Console.Write("*");
                passwordInput += keyPress.KeyChar;
            }
        }
        return passwordInput;
    }
}