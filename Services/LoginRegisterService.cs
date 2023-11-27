using Nov27Practice.Models;
using Nov27Practice.Services;

internal static class LoginRegisterService
{
    internal static User? Login(string username, string password)
    {
        UserService us = new();
        return us.CheckCreds(username, password);
    }

    internal static void Register(string username, string name, string surname, string password)
    {
        UserService us = new();
        us.Create(new User() {Username=username, Name = name,Surname = surname,Password = password });
    }
}