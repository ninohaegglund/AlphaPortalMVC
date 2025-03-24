using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class AddStatusForm
{
    [DataType(DataType.Text)]   
    [Display(Name = "Status", Prompt = "Enter Status name")]
    [Required(ErrorMessage = "Required")]
    public string StatusName { get; set; } = null!;   

}
