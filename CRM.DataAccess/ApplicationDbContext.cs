using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TaskAssignment> TaskAssignment { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Detail> Detail { get; set; }


    }
}
