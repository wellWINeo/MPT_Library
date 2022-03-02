using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Splat;

namespace Library.Services;

public class ApplicationContext : DbContext, IApplicationContext
{
    // entities
    public DbSet<Charity> Charities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<RegistrationStatus> RegistrationStatuses { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Sponsorship> Sponsorships { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Timesheet> Timesheets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }

    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // get connection string from config via locator
        var connString = Locator.Current.GetService<IConfigurationRoot>()
            .GetConnectionString("Server");

        // configure to use MySQL
        optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
    }
}