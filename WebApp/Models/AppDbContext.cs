using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source ={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);
        
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Name = "WSEI",
                    NIP ="98765423",
                    REGON = "298517521",
                },
            new OrganizationEntity()
                {
                   Id= 102,
                   Name = "PKP",
                   NIP = "98421322",
                   REGON = "3421251825"
                       
                }
            );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new 
                {
                City="Kraków",
                Street="św. Filipa 17",
                OrganizationEntityId = 101
                },
        new 
            {
                City="Warszawa",
                Street="Przedmieście Krakowskie",
                OrganizationEntityId = 102
            }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowal",
                    BirthDate = new DateOnly(2000,10,10),
                    Email = "adam@op.pl",
                    PhoneNumber = "123456789",
                    Created = DateTime.Now,
                    OrganizationId = 101
                },
        new ContactEntity()
            {
                Id = 2,
                FirstName = "Ewa",
                LastName = "Kowal",
                BirthDate = new DateOnly(1996,2,2),
                Email = "ewa@op.pl",
                PhoneNumber = "987654321",
                Created = DateTime.Now,
                OrganizationId = 102
            }
            );
    }
}