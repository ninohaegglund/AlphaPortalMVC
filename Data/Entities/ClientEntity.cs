

using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ClientEntity
{
    public int Id { get; set; }

    [Required]
    public string ClientName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Location { get; set; }
}
