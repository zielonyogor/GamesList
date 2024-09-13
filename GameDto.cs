using System.ComponentModel.DataAnnotations;
public class GameDto
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = "Game Title";
    public string? Description { get; set; }
    public DateTime ReleaseTime { get; set; }
	public DateTime PlayingSinceTime { get; set; }

    [Range(1, 10)]
    public int? Rating { get; set; }
    public string? ImageUri { get; set; }
    public List<string> Tags { get; set; } = [];
}