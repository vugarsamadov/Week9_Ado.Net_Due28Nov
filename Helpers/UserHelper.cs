﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov27Practice.Helpers
{

    public record UserDto(string userName,string name, string surname, string password);

    public class UserBuilder
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                //CoreValidator.Validators.ValidateName(value);
                _name = value;
            }
        }
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                //CoreValidator.Validators.ValidateName(value);
                _username = value;
            }
        }
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                //CoreValidator.Validators.ValidateName(value);
                _surname = value;
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                //CoreValidator.Validators.ValidatePassword(value);
                _password = value;
            }
        }

        public UserDto Build()
        {
            return new UserDto(Username, Name, Surname, Password);
        }

    }

    internal static class UserHelper
    {
        public static (string username, string password) GetLoginCreds()
        {
            var username = InputHelper.PromptAndTryGetNonEmptyString("Username: ");
            var password = InputHelper.PromptAndTryGetNonEmptyString("Password: ");
            return (username, password);
        }

        public static UserDto GetUserDetails()
        {
            UserBuilder ub = new();
            ub.Username = InputHelper.PromptAndTryGetNonEmptyString("Username: ");
            ub.Name = InputHelper.PromptAndTryGetNonEmptyString("Name: ");
            ub.Surname = InputHelper.PromptAndTryGetNonEmptyString("Surname: ");
            ub.Password = InputHelper.PromptAndTryGetNonEmptyString("Password: ");
            return ub.Build();
        }
    }
}
