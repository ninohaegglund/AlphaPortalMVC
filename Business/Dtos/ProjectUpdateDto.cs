

namespace Business.Dtos;

public class ProjectUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ClientName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Budget { get; set; }
    public int StatusId { get; set; }

}
