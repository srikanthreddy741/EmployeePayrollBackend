using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserEntity UserRegistration(Registration registration)
        {
            try
            {
                return userRL.UserRegistration(registration);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(LoginModel loginModel)
        {
            try
            {
                return userRL.Login(loginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ForgetPassword(string emailId)
        {
            try
            {
                return this.userRL.ForgetPassword(emailId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool ResetPassword(string password, string confirmPassword)
        {
            try
            {
                return userRL.ResetPassword(password, confirmPassword);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
