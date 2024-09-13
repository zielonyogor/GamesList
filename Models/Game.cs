using System.ComponentModel.DataAnnotations;

namespace GamesList.Models
{
	public class Game
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; } = "Game Title";

		[MaxLength(500)]
		public string? Description { get; set; }
		public DateTime ReleaseTime { get; set; }
		public DateTime PlayingSinceTime { get; set; }

		[Range(1, 10)]
		public int? Rating { get; set; }
		public string? ImageUri { get; set; } //change here to place holder maybe
		public List<GameTags> GameTags { get; set; } = [];
	}
}
