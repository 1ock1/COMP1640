﻿using COMP1640.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Utils
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //local connect: Remember to uncomment this to use your database at local
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=COMP1640;Trusted_Connection=True;TrustServerCertificate=true");
            //stg connect: Remember to uncomment this when you want to use your database at stg
            optionsBuilder.UseSqlServer("Server=tcp:comp1640-stg.database.windows.net,1433;Initial Catalog=comp1640-stg;Persist Security Info=False;User ID=comp1640-stg;Password=Azuredbstaging252;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //prod connect: Connect to production environment
            //optionsBuilder.UseSqlServer("Server=tcp:comp1640-prod.database.windows.net,1433;Initial Catalog=comp1640-prod;Persist Security Info=False;User ID=comp1640-prod;Password=Azuredb252;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<Academic> Academics { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Falcuty> Falcuties { get; set; }
        public DbSet<FileReport> FileReports { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<PublishedReport> PublishedReports { get; set; }
        public DbSet<ReportComment> ReportComments { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
