using System;
using Microsoft.EntityFrameworkCore;
using DatabaseExample.Entities;

namespace DatabaseExample.Repositories;

public class ExampleDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost;Database=Example;User Id=sa;TrustServerCertificate=true;password=reallyStrongPwd123");
        optionsBuilder.UseSqlServer("Server=HTO\\SQLEXPRESS;Database=Example;Integrated Security=True;TrustServerCertificate=True");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Personal> Personals { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Jobber> Jobbers { get; set; }

}