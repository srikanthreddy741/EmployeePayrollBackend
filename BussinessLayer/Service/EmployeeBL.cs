using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.Data.SqlClient.Server;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class EmployeeBL: IEmployeeBL
    {
     
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public EmployeeEntity Create(EmployeeModel details, long EmployeeId)
        {
            try
            {
                return employeeRL.Create(details, EmployeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<EmployeeEntity> Getall(long EmployeeId)
        {
            try
            {
                return employeeRL.Getall(EmployeeId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
