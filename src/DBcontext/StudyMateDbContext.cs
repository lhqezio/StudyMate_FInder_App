using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace StudyMate
{
    public class StudyMateDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        // The following configures EF to connect to an oracle database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            Console.Write("Enter the username for the database: ");
            string username = Console.ReadLine();

            Console.Write("Enter the password for the database: ");
            string password = Console.ReadLine();

            optionsBuilder.UseOracle(@$"User Id={username}; Password={password};
		        Data Source=198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca;");
        }
    }
}