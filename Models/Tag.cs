namespace GamesList.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public List<GameTags> GameTags { get; set; } = [];
	}
}
