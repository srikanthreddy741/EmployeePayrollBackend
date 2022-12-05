using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly EmployeeContext employeeContext;
        private readonly IConfiguration configuration;

        public UserRL(EmployeeContext employeeContext, IConfiguration configuration)
        {
            this.employeeContext = employeeContext;
            this.configuration = configuration;
        }
        public UserEntity UserRegistration(Registration registration)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = registration.FirstName;
                userEntity.LastName = registration.LastName;
                userEntity.Email = registration.Email;
                userEntity.Password = registration.Password;
                employeeContext.userTable.Add(userEntity);
                int result = employeeContext.SaveChanges();
                if (result > 0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public string Login(LoginModel loginModel)
            {
                try
                {
                    var LoginDetails = employeeContext.userTable.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password).FirstOrDefault();
                    if (LoginDetails != null)
                    {
                        var token = GenerateSecurityToken(LoginDetails.Email, LoginDetails.EmployeeId);
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            private string GenerateSecurityToken(string Email, long EmployeeId)
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.configuration[("JWT:key")]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, Email),
                    new Claim("EmployeeId", EmployeeId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddHours(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        public string ForgetPassword(string emailId)
        {
            try
            {
                var emailCheck = employeeContext.userTable.FirstOrDefault(e => e.Email == emailId);
                if (emailCheck != null)
                {
                    var token = GenerateSecurityToken(emailCheck.Email, emailCheck.EmployeeId);
                    MSMQModel mSMQModel = new MSMQModel();
                    mSMQModel.sendData2Queue(token);
                    return token.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool ResetPassword(string Password, string ConfirmPassword)
        {
            try
            {
                if (Password.Equals(ConfirmPassword))
                {
                    var emailCheck = employeeContext.userTable.FirstOrDefault();
                    emailCheck.Password = Password;
                    employeeContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }

