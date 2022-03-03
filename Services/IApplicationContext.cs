using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services;

// хрень ес чесно, лучше использовать IDbContextFactory для абстракции
// но пофиг
public interface IApplicationContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<IssueCertificate> IssueCertificates { get; set; }
    public DbSet<Models.Library> Libraries { get; set; }
    public DbSet<ReadingRoom> ReadingRooms { get; set; }
    public DbSet<Staff> Staves { get; set; }
}