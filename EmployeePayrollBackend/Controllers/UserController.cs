using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace EmployeePayrollBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        
        [HttpPost("Register")]//Custom route
        public IActionResult UserRegistration(Registration Registration)
        {
            try
            {
                var result = userBL.UserRegistration(Registration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "UserRegistration Successfull", data = result });
                }
                else
                {

                    return this.BadRequest(new { success = true, message = "UserRegistration UnSuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                var result = userBL.Login(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login is Successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login is Not Successfull" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(string emailId)
        {
            try
            {
                var result = userBL.ForgetPassword(emailId);
                if (result != null)
                {
                    return this.Ok(new { Sucess = true, message = "Email sends successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Email doesnot send successfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
        [HttpPut]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(string Password, string ConfirmPassword)
        {
            try
            {
               var Email = User.FindFirst(ClaimTypes.Email).Value.ToString();

                if (userBL.ResetPassword(Password, ConfirmPassword))
                {
                    return Ok(new { success = true, message = "Reset Password is Succesfull" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Reset Password Link Could Not Be Sent" });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
