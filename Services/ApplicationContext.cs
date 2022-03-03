using System;
using Library.Helper;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Splat;

namespace Library.Services;

public class ApplicationContext : DbContext, IApplicationContext
{
    // entities
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<IssueCertificate> IssueCertificates { get; set; }
    public DbSet<Models.Library> Libraries { get; set; }
    public DbSet<ReadingRoom> ReadingRooms { get; set; }
    public DbSet<Staff> Staves { get; set; }

    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // get connection string from config via locator
        var connString = Locator.Current.GetService<IConfigurationRoot>()
            .GetConnectionString("Server");

        // configure to use SQL Server
        optionsBuilder.UseSqlServer(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Branch>(builder =>
        {
            builder.Property(x => x.OpenTime)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            builder.Property(x => x.CloseTime)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
        });
        
        modelBuilder.Entity<Models.Library>(builder =>
        {
            builder.Property(x => x.OpenTime)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            builder.Property(x => x.CloseTime)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
        });

        modelBuilder.Entity<Staff>(builder
            => builder.Property(x => x.DateOfEmployment)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>());

        modelBuilder.Entity<IssueCertificate>(builder =>
        {
            builder.Property(x => x.DateOfDelivery)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            builder.Property(x => x.DateOfIssue)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
        });

        modelBuilder.Entity<Staff>().HasData(
            new Staff()
            {
                StaffId = 1,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                PassportSeries = "1234",
                PassportNumber = "567890",
                DateOfEmployment = DateOnly.FromDateTime(DateTime.Now),
                PhoneNumber = "123456780",
                Email = "user@example.com",
                Password = "123",
                Branch = null!
            });

        modelBuilder.Entity<Client>().HasData(
            new Client()
            {
                ClientId = 1,
                Surname = "Петров",
                Name = "Петр",
                Patronymic = "Петрович",
                Address = "ул. Несуществующая",
                PhoneNumber = "134567890",
                Email = "client@example.com",
                Password = "123",
                Age = 18
            });

    }
}