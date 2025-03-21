

using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ClientEntity
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? JobTitle { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
