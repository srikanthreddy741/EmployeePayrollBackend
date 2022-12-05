using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL :IEmployeeRL
    {
        private readonly EmployeeContext employeeContext;
        private readonly IConfiguration configuration;
        public EmployeeRL(EmployeeContext employeeContext, IConfiguration configuration)
        {
            this.employeeContext = employeeContext;
            this.configuration = configuration;

        }

        public EmployeeEntity Create(EmployeeModel details, long EmployeeId)
        {
            try
            {
                EmployeeEntity detailsent = new EmployeeEntity();
                var result = employeeContext.EmployeeFormTable.Where(e => e.EmployeeId == EmployeeId);
                if (result != null)
                {


                    detailsent.EmployeeId = EmployeeId;
                    detailsent.Name = details.Name;
                    detailsent.Image = details.Image;
                    detailsent.Gender = details.Gender;
                    detailsent.Department = details.Department;
                    detailsent.Salary = details.Salary;
                    detailsent.Notes = details.Notes;

                    employeeContext.EmployeeFormTable.Add(detailsent);
                    employeeContext.SaveChanges();
                    return detailsent;
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
        public List<EmployeeEntity> Getall(long EmployeeId)
        {
            try
            {
                var result = employeeContext.EmployeeFormTable.Where(e => e.EmployeeId == EmployeeId).ToList();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
