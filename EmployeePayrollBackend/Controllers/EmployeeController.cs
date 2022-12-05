using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using System.Linq;
using System;
using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.Data.SqlClient.Server;

namespace EmployeePayrollBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
            private readonly IEmployeeBL employeeBL;
            private readonly EmployeeContext employeeContext;

            public EmployeeController(IEmployeeBL employeeBL, EmployeeContext employeeContext)
            {
                this.employeeBL = employeeBL;
                this.employeeContext = employeeContext;

            }
            [Authorize]
            [HttpPost]
            [Route("Create")]
            public ActionResult Create(EmployeeModel details)
            {
                try
                {
                    long EmployeeId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "EmployeeId").Value);
                    var result = employeeBL.Create(details, EmployeeId);
                    if (result != null)
                    {
                        return Ok(new { success = true, message = "Employee Form Created Successfully", data = result });
                    }
                    else
                    {
                        return NotFound(new { success = false, message = "UnSuccessfully " });
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Getall()
        {
            try
            {
                long EmployeeId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "EmployeeId").Value);
                var result = employeeBL.Getall(EmployeeId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Read all Employee details", data = result });
                }
                else
                {
                    return NotFound(new { success = false, message = "Unable to Read all Employee details" });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
