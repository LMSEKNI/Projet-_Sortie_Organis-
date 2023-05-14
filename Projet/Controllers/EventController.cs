using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet.Data;

namespace ProjetSortieOrganise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EvenementController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EvenementController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evenement>>> GetEvenement()
    {
        if (_context.Evenements == null)
        {
            return NotFound();
        }

        return await _context.Evenements.ToListAsync();
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<Evenement>> GetEvenement(int id)
    {
        if (_context.Evenements == null)
        {
            return NotFound();
        }

        var evenement = await _context.Evenements.FindAsync(id);

        if (evenement == null)
        {
            return NotFound();
        }

        return evenement;
    }

   
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvenement(int id, Evenement evenement)
    {
        if (id != evenement.idEvent)
        {
            return BadRequest();
        }

        _context.Entry(evenement).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EvenementExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

   
    [HttpPost]
    public async Task<ActionResult<Evenement>> PostEvenement(Evenement evenement)
    {
        if (_context.Evenements == null)
        {
            return Problem("Entity set 'AppDbContext.Evenement' is null.");
        }

        _context.Evenements.Add(evenement);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEvenement", new { id = evenement.idEvent }, evenement);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvenement(int id)
    {
        if (_context.Evenements == null)
        {
            return NotFound();
        }

        var evenement = await _context.Evenements.FindAsync(id);
        if (evenement == null)
        {
            return NotFound();
        }

        _context.Evenements.Remove(evenement);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EvenementExists(int id)
    {
        return (_context.Evenements?.Any(e => e.idEvent == id)).GetValueOrDefault();
    }
}
