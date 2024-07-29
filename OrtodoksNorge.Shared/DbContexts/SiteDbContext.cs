using Microsoft.EntityFrameworkCore;
using OrtodoksNorge.Shared.Configuration.Database;
using OrtodoksNorge.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.DbContexts;
public class SiteDbContext : DbContext
{
    private readonly DatabaseSection _config;
    public SiteDbContext(DbContextOptions options, IDatabaseConfiguration config) : base(options)
    {
        _config = config.Database;
    }

    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.HasDefaultSchema("Site");

        mb.Entity<CalendarEvent>(o =>
        {
            o.ToTable("CalendarEvents");
            o.HasKey(o => o.Id)
                .HasName("PK_CalendarEvents_Id");
            o.HasIndex(p => new { p.Id, p.Author, p.StartTime }, "IX_CalendarEvents_Id_Author_Title_StartTime");
            o.Property(p => p.Id)
                .IsRequired()
                .UseIdentityColumn(_config.IdentityColumnConfigs["CalendarEvents"].Seed, _config.IdentityColumnConfigs["CalendarEvents"].Increment);
            o.Property(p => p.Author)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);
            o.Property(p => p.Type)
                .IsRequired()
                .IsUnicode()
                .HasConversion<string>()
                .HasMaxLength(50);
            o.Property(p => p.IngressImageId)
                .IsRequired();
            o.Property(p => p.StartTime)
                .IsRequired();
            o.Property(p => p.EndTime)
                .IsRequired(false);
            o.Property(p => p.Created)
                .IsRequired();
            o.Property(p => p.Updated)
                .HasDefaultValue(null);
            o.Property(p => p.CssColorClasses)
                .HasDefaultValue(null);

            o.HasMany(p => p.LocalizedBlurbs)
                .WithOne(p => p.CalendarEvent)
                .IsRequired()
                .HasForeignKey(p => p.CalendarEventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CalendarEvents_CalendarEventBlurbs_CalendarEventId");
        });

        mb.Entity<LocalizedCalendarEventBlurb>(o =>
        {
            o.ToTable("CalendarEventBlurbs");
            o.HasKey(p => new { p.CalendarEventId, p.Culture })
                .HasName("PK_CalendarEventBlurbs_CalendarEventId_Culture");
            o.Property(p => p.CalendarEventId)
                .IsRequired();
            o.Property(p => p.Culture)
                .IsRequired()
                .IsUnicode()
                .HasConversion<string>();
            o.Property(p => p.Title)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(150);
            o.Property(p => p.Description)
                .IsRequired()
                .IsRequired()
                .HasMaxLength(2500);
        });

        mb.Entity<Location>(o =>
        {
            o.ToTable("Locations");
            o.HasKey(p => p.Id)
                .HasName("PK_Locations_Id");
            o.HasIndex(p => new { p.Id, p.Name }, "IX_Locations_Id_Name");
            o.Property(p => p.Id)
                .IsRequired()
                .UseIdentityColumn(_config.IdentityColumnConfigs["Locations"].Seed, _config.IdentityColumnConfigs["Locations"].Increment);
            o.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(150);

            o.HasMany(p => p.CalendarEvents)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Locations_CalendarEvents_LocationId");
        });

        base.OnModelCreating(mb);
    }
}
