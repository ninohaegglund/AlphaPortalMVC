using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class AddClientForm
{
    [DataType(DataType.Text)]   
    [Display(Name = "First Name", Prompt = "Enter first name")]
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter last name")]
    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter email address")]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Enter phone number (optional)")]
    public string? Phone { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Job Title", Prompt = "Enter Job Title")]
    public string? JobTitle { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth", Prompt = "Select Date of Birth")]
    [Required(ErrorMessage = "Required")]
    public DateTime DateOfBirth { get; set; }



}
