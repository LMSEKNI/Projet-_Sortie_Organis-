using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet.Data;

namespace ProjetSortieOrganise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonneController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonneController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Personne>>> GetPersonne()
    {
        if (_context.Personnes == null)
        {
            return NotFound();
        }

        return await _context.Personnes.ToListAsync();
    }

   
    [HttpGet("{cin}")]
    public async Task<ActionResult<Personne>> GetPersonne(String cin)
    {
        if (_context.Personnes == null)
        {
            return NotFound();
        }

        var personne = await _context.Personnes.FindAsync(cin);

        if (personne == null)
        {
            return NotFound();
        }

        return personne;
    }

   
    [HttpPut("{Cin}")]
    public async Task<IActionResult> PutPersonne(String cin, Personne personne)
    {
        if (cin != personne.cin)
        {
            return BadRequest();
        }

        _context.Entry(personne).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonneExists(cin))
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
    public async Task<ActionResult<Personne>> PostPersonne(Personne personne)
    {
        if (_context.Personnes == null)
        {
            return Problem("Entity set 'AppDbContext.Personne' is null.");
        }

        _context.Personnes.Add(personne);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPersonne", new { cin = personne.cin }, personne);
    }

   
    [HttpDelete("{cin}")]
    public async Task<IActionResult> DeletePersonne(String cin)
    {
        if (_context.Personnes == null)
        {
            return NotFound();
        }

        var personne = await _context.Personnes.FindAsync(cin);
        if (personne == null)
        {
            return NotFound();
        }

        _context.Personnes.Remove(personne);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PersonneExists(String cin)
    {
        return (_context.Personnes?.Any(e => e.cin == cin)).GetValueOrDefault();
    }
}
