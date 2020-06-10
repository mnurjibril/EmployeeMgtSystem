using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class EmpMgtContext:DbContext
    {
        public EmpMgtContext(DbContextOptions<EmpMgtContext> options) : base(options)
        {

        }

        public DbSet<EmployeesDb> EmployeesDb { get; set; }
        public DbSet<ManagerDb> ManagerDb { get; set; }
        public DbSet<DepartmentDb> DepartmentDb { get; set; }
        public DbSet<AccountDb> AccountDb { get; set; }
        public DbSet<Employee2db> Employees2Db { get; set; }
        public DbSet<customerdb> customerdb { get; set; }

    }
}
