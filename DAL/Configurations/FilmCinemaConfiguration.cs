using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFlicks.DAL.Configurations;

public class FilmCinemaConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {

        builder
            .HasMany(f => f.Cinemas)
            .WithMany(c => c.Films)
            .UsingEntity<FilmCinema>(
                f => f
                    .HasOne(fc => fc.Cinema)
                    .WithMany(c => c.FilmCinemas)
                    .HasForeignKey(fc => fc.CinemaId),
                f => f
                    .HasOne(fc => fc.Film)
                    .WithMany(f => f.FilmCinemas)
                    .HasForeignKey(fc => fc.FilmId),
                j => j.HasKey(fc => new { fc.CinemaId, fc.FilmId })
                );
    }
}