using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFlicks.Domain.Entities;

[Table("addresses")]
public class Address : IdEntity
{
    [Column("city_name")]
    [StringLength(1024), Required]
    public string CityName { get; set; }
    
    [Column("street_name")]
    [StringLength(1024), Required]
    public string StreetName { get; set; }
    
    [Column("house_number"), Required]
    [Range(1, int.MaxValue)]
    public int HouseNumber { get; set; }
    
    [Column("apartment_number")]
    [Range(1, int.MaxValue)]
    public int? ApartmentNumber { get; set; }

    public override string ToString() => $"{CityName}/{StreetName}/{HouseNumber}";
}