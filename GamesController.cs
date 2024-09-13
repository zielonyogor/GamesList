using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamesList.Data;
using Microsoft.EntityFrameworkCore;
using GamesList.Models;

namespace GamesList;

[Route("api/games")]
[ApiController]
public class GamesController : Controller
{
    private readonly GameContext _db;

    public GamesController(GameContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<GameDto>>> GetGames()
    {
        var games = await _db.Games
        .Include(g => g.GameTags).ThenInclude(t => t.Tag)
        .Select(g => new GameDto
        {
            Id = g.Id,
            Title = g.Title,
            Description = g.Description,
            ReleaseTime = g.ReleaseTime,
            PlayingSinceTime = g.PlayingSinceTime,
            Rating = g.Rating,
            ImageUri = g.ImageUri,
            Tags = g.GameTags.Select(gt => gt.Tag.Name).ToList()
        })
        .ToListAsync();

        return games;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetGame(int id)
    {
        var game = await _db.Games
            .Include(g => g.GameTags)
            .ThenInclude(t => t.Tag)
            .FirstOrDefaultAsync(g => g.Id == id);

        if(game is null)
        {
            return NotFound();
        }

        var gameDto = new GameDto{
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            ReleaseTime = game.ReleaseTime,
            PlayingSinceTime = game.PlayingSinceTime,
            Rating = game.Rating,
            ImageUri = game.ImageUri,
            Tags = game.GameTags.Select(gt => gt.Tag.Name).ToList()
        };

        return gameDto;
    }

    [HttpPost]
    public async Task<ActionResult<Game>> CreateGame(GameDto gameDto)
    {
        var tags = await _db.Tags
            .Where(t => gameDto.Tags.Contains(t.Name))
            .ToListAsync();
        
        var newTags = gameDto.Tags
            .Except(tags.Select(t => t.Name))
            .Select(tagName => new Tag { Name = tagName })
            .ToList();
        
        _db.Tags.AddRange(newTags);
        await _db.SaveChangesAsync();

        tags.AddRange(newTags);
        
        var game = new Game{
            Title = gameDto.Title,
            Description = gameDto.Description,
            ReleaseTime = gameDto.ReleaseTime,
            PlayingSinceTime = gameDto.PlayingSinceTime,
            Rating = gameDto.Rating,
            ImageUri = gameDto.ImageUri,
            GameTags = tags.Select(tag => new GameTags
            {
                Tag = tag
            }).ToList()
        };

        _db.Games.Add(game);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGame), new { id = game.Id }, gameDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Game>> UpdateGame(int id, GameDto gameDto)
    {
        if(id != gameDto.Id)
        {
            return BadRequest();
        }

        var game = await _db.Games
            .Include(g => g.GameTags)
            .ThenInclude(t => t.Tag)
            .FirstOrDefaultAsync(g => g.Id == id);

        if(game is null)
        {
            return NotFound();
        }

        //add new tags, just like in create game
        var tags = await _db.Tags
            .Where(t => gameDto.Tags.Contains(t.Name))
            .ToListAsync();
        
        var newTags = gameDto.Tags
            .Except(tags.Select(t => t.Name))
            .Select(tagName => new Tag { Name = tagName })
            .ToList();
        
        _db.Tags.AddRange(newTags);
        await _db.SaveChangesAsync();

        tags.AddRange(newTags);

        game.GameTags.Clear();
        game.GameTags = tags.Select(tag => new GameTags
        {
            Tag = tag
        }).ToList();

        game.Title = gameDto.Title;
        game.Description = gameDto.Description;
        game.ReleaseTime = gameDto.ReleaseTime;
        game.PlayingSinceTime = gameDto.PlayingSinceTime;
        game.Rating = gameDto.Rating;
        game.ImageUri = gameDto.ImageUri;

        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var game = await _db.Games
            .Include(g => g.GameTags)
            .FirstOrDefaultAsync(g => g.Id == id);
        
        if(game is null)
        {
            return NotFound();
        }

        _db.Games.Remove(game);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
