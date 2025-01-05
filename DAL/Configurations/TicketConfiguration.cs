using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFlicks.DAL.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasOne(t => t.FilmCinema)
            .WithMany(f => f.Tickets);
        
        builder
            .HasOne(t => t.User)
            .WithOne();
    }
}