using GhostPizza.UI.Helpers;
using Nov27Practice.Models;

public enum LoginRegisterMenuCommand
{
    Login,
    Register
}



public class Program
{


    static User LoggedInUser = null;

    static LoginRegisterMenuCommand[] initialCommands =
    new LoginRegisterMenuCommand[]
    {
                LoginRegisterMenuCommand.Login,
                LoginRegisterMenuCommand.Register
    };

    public static void Main()
    {
        DisplayLoginRegisterMenu();
    }


    static void DisplayLoginRegisterMenu()
    {
        LoginRegisterMenuCommand command = InputHelper.DisplayAndGetCommandBySelection(initialCommands, ConsoleHelpers.Splash);

        switch (command)
        {
            case LoginRegisterMenuCommand.Login:
                LoginUser();
                break;
            case LoginRegisterMenuCommand.Register:
                RegisterUser();
                break;
        }
    }


    public static void LoginUser()
    {
        (string username, string password) = UserHelper.GetLoginCreds();
        LoggedInUser = LoginRegisterService.Login(username, password);
        ConsoleHelpers.Buffer = $"Welcome back {LoggedInUser.Name}";
    }

    public static void RegisterUser()
    {
        ConsoleHelpers.PrintBuffer();
        var userDto = UserHelper.GetUserDetails();
        LoginRegisterService.Register(userDto.name, userDto.surname, userDto.password);
    }


}





 



