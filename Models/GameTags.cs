namespace GamesList.Models;

public class GameTags
{
    public int GameId { get; set; }
    public Game Game { get; set; }
    public int TagId { get; set; }
    public Tag Tag{ get; set; }
}