
using Microsoft.AspNetCore.Mvc;
using Projet.Models;

using Microsoft.EntityFrameworkCore;
using Projet.Data;

namespace ProjetSortieOrganise.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ActiviteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ActiviteController(ApplicationDbContext context)
    {
        _context = context;
    }

   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activite>>> GetActivite()
    {
        if (_context.Activites == null)
        {
            return NotFound();
        }

        return await _context.Activites.ToListAsync();
    }

  
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Activite>> GetActivite(int id)
    {
        if (_context.Activites == null)
        {
            return NotFound();
        }

        var activite = await _context.Activites.FindAsync(id);

        if (activite == null)
        {
            return NotFound();
        }

        return activite;
    }

   
    [HttpPut("{id}")]
    public async Task<IActionResult> PutActivite(int id, Activite activite)
    {
        if (id != activite.idActivite)
        {
            return BadRequest();
        }

        _context.Entry(activite).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ActiviteExists(id))
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
    public async Task<ActionResult<Activite>> PostActivite(Activite activite)
    {
        if (_context.Activites == null)
        {
            return Problem("Entity set 'AppDbContext.Activite' is null.");
        }

        _context.Activites.Add(activite);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetActivite", new { id = activite.idActivite }, activite);
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivite(int id)
    {
        if (_context.Activites == null)
        {
            return NotFound();
        }

        var activite = await _context.Activites.FindAsync(id);
        if (activite == null)
        {
            return NotFound();
        }

        _context.Activites.Remove(activite);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ActiviteExists(int id)
    {
        return (_context.Activites?.Any(e => e.idActivite == id)).GetValueOrDefault();
    }

}