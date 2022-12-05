using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)

        {
        }
        public DbSet<UserEntity> userTable { get; set; }
        public DbSet<EmployeeEntity> EmployeeFormTable { get; set; }
    }
}
