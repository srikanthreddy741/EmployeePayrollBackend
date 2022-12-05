﻿using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity UserRegistration(Registration registration);
        public string Login(LoginModel loginModel);
        public string ForgetPassword(string emailId);
        public bool ResetPassword(string password, string confirmPassword);
    }
}
