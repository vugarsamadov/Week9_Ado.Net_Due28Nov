using Nov27Practice.Services;

internal static class LoginRegisterService
{
    internal static Nov27Practice.Models.User Login(string username, string password)
    {
        UserService us = new();
        us.Create(new Nov27Practice.Models.User(){Name = username,Password=password });
        return new();
    }

    internal static void Register(string name, string surname, string password)
    {
        throw new NotImplementedException();
    }
}