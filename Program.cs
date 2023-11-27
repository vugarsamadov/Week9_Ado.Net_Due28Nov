using ADO.NET.Services;
using Nov27Practice.Helpers;
using Nov27Practice.Models;
using Nov27Practice.Services;

public enum LoginRegisterMenuCommand
{
    Login,
    Register
}
public enum AfterLoginMenu
{
    Get_All_Blogs,
    Get_Blog_By_Id,
    Create_Blog,
    Update_Blog,
    Delete_Blog,
    Quit
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

    static AfterLoginMenu[] afterLoginCommands =
    new AfterLoginMenu[]
    {
                AfterLoginMenu.Get_All_Blogs,
                AfterLoginMenu.Get_Blog_By_Id,
                AfterLoginMenu.Create_Blog,
                AfterLoginMenu.Update_Blog,
                AfterLoginMenu.Delete_Blog,
                AfterLoginMenu.Quit
    };
    public static BlogService blogService = new();
    public static void Main()
    {
        
        while(true)
        {
            DisplayLoginRegisterMenu();
            DisplayAfterLoginMenu();
            LoggedInUser = null;
        }
        


    }

    static void DisplayAfterLoginMenu()
    {
        AfterLoginMenu command;
        do
        {
            command = InputHelper.DisplayAndGetCommandBySelection(afterLoginCommands);
            try
            {

            switch (command)
            {
                case AfterLoginMenu.Get_All_Blogs:
                    ConsoleHelpers.AddListToBuffer(blogService.GetAll(LoggedInUser.Id));
                    break;
                case AfterLoginMenu.Get_Blog_By_Id:
                    var id = InputHelper.PromptAndTryGetPositiveInt("Enter Id: ");
                    ConsoleHelpers.Buffer = blogService.GetById(id,LoggedInUser.Id).ToString();
                    break;
                case AfterLoginMenu.Update_Blog:
                    var idblog = InputHelper.PromptAndTryGetPositiveInt("Enter Id: ");
                    var blog = InputHelper.GetBlogFromUser();
                    blog.UserId = LoggedInUser.Id;
                    blogService.Update(idblog,blog);
                    break;
                case AfterLoginMenu.Create_Blog:
                    var crblog = InputHelper.GetBlogFromUser();
                    crblog.UserId = LoggedInUser.Id;
                    blogService.Create(crblog);
                    break;
                case AfterLoginMenu.Delete_Blog:
                    idblog = InputHelper.PromptAndTryGetPositiveInt("Enter Id: ");
                    blogService.Delete(idblog, LoggedInUser.Id);
                    break;
            }
            }catch(Exception e)
            {
                ConsoleHelpers.BufferError(e.Message);
            }
        } while (command != AfterLoginMenu.Quit);
    }

    static void DisplayLoginRegisterMenu()
    {
        LoginRegisterMenuCommand command;
        do
        {

        command = InputHelper.DisplayAndGetCommandBySelection(initialCommands);
            try
            {

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
            catch (Exception e)
            {
                ConsoleHelpers.BufferError(e.Message);
            }
        } while (LoggedInUser == null);
    }


    public static void LoginUser()
    {
        (string username, string password) = UserHelper.GetLoginCreds();
        LoggedInUser = LoginRegisterService.Login(username, password);
        if(LoggedInUser != null)
            ConsoleHelpers.Buffer = ($"Welcome back {LoggedInUser.Name}");
        else
            ConsoleHelpers.BufferError("Creds are invalid!");
    }

    public static void RegisterUser()
    {
        ConsoleHelpers.PrintBuffer();
        var userDto = UserHelper.GetUserDetails();
        LoginRegisterService.Register(userDto.userName,userDto.name, userDto.surname, userDto.password);
    }


}





 



