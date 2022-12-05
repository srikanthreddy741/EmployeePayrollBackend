using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeEntity Create(EmployeeModel details, long EmployeeId);
        public List<EmployeeEntity> Getall(long EmployeeId);


    }
}
