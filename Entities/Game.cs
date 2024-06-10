using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Genre { get; set; }

    [Range(1, 1000)]
    public decimal Price { get; set; }




    public DateTime ReleaseDate { get; set; }

    [Url]
    [StringLength(50)]
    public required string ImageUrl { get; set; }
}
