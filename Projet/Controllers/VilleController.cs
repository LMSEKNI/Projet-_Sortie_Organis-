using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet.Data;
using Projet.Models;

namespace ProjetSortieOrganise.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VilleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VilleController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ville>>> GetVille()
    {
        if (_context.Villes == null)
        {
            return NotFound();
        }

        return await _context.Villes.ToListAsync();
    }

   
    [HttpGet("{id}")]
    public async Task<ActionResult<Ville>> GetVille(int id)
    {
        if (_context.Villes == null)
        {
            return NotFound();
        }

        var ville = await _context.Villes.FindAsync(id);

        if (ville == null)
        {
            return NotFound();
        }

        return ville;
    }

  
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVille(int id, Ville ville)
    {
        if (id != ville.idVille)
        {
            return BadRequest();
        }

        _context.Entry(ville).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VilleExists(id))
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
    public async Task<ActionResult<Ville>> PostVille(Ville ville)
    {
        if (_context.Villes == null)
        {
            return Problem("Entity set 'AppDbContext.Ville' is null.");
        }

        _context.Villes.Add(ville);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVille", new { id = ville.idVille }, ville);
    }

    // DELETE: api/Ville/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVille(int id)
    {
        if (_context.Villes == null)
        {
            return NotFound();
        }

        var ville = await _context.Villes.FindAsync(id);
        if (ville == null)
        {
            return NotFound();
        }

        _context.Villes.Remove(ville);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VilleExists(int id)
    {
        return (_context.Villes?.Any(e => e.idVille == id)).GetValueOrDefault();
    }
}
