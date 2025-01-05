using FilmFlicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFlicks.DAL.Configurations;

public class FilmCinemaConfiguration : IEntityTypeConfiguration<FilmCinema>
{
    public void Configure(EntityTypeBuilder<FilmCinema> builder)
    {
        builder.HasKey(fc => new { fc.CinemaId, fc.FilmId });
        
        builder
            .HasOne(cf => cf.Cinema)
            .WithMany()
            .HasForeignKey(cf => cf.CinemaId);

        builder
            .HasOne(cf => cf.Film)
            .WithMany()
            .HasForeignKey(cf => cf.FilmId);
    }
}