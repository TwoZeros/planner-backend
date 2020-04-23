using Microsoft.EntityFrameworkCore;
using Planner.Data.Configurations;
using Planner.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;



namespace Planner.Data
{
    public class PlannerDbContext : DbContext
    {
        
       public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LogConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.Entity<User>().HasData(
               new User[]
               {
                new User { Id=1, Login="Admin", Password="12345678",Role="Admin"},
               });
            builder.Entity<Position>().HasData(
               new Position[]
               {
                new Position { Id=1, Name="Директор", IsAllowedDelete=false},
                new Position { Id=2, Name="Менеджер", IsAllowedDelete=false},
                new Position { Id=3, Name="Курьер", IsAllowedDelete=false},
                new Position { Id=4, Name="Повар", IsAllowedDelete=false},

               });
            builder.Entity<KnowledgeLevel>().HasData(
               new KnowledgeLevel[]
               {
                new KnowledgeLevel { Id=1, Name="Junior"},
                new KnowledgeLevel { Id=2, Name="Middle"},
                new KnowledgeLevel { Id=3, Name="Senior"},
                });


        }

        public DbSet<LogEntry> Logs { get; set; }
        public DbSet<User> Users { get; set; }
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<GroupSkill> GroupSkills { get; set; }
        public DbSet<KnowledgeLevel> KnowledgeLevel { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<CarmaUser> CarmaUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<ProductInOrder> ProductInOrders { get; set; }

    }
}
