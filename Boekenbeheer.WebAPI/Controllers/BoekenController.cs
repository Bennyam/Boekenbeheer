using Boekenbeheer.Application.Services;
using Boekenbeheer.Domain.Entities;
using Boekenbeheer.WebAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Boekenbeheer.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoekenController : ControllerBase
{
  private readonly BoekService _service;

  public BoekenController(BoekService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<BoekDto>>> GetAlle()
  {
    var boeken = await _service.GetAllBoekenAsync();

    var resultaat = boeken.Select(boek => new BoekDto
    {
      Id = boek.Id,
      Titel = boek.Titel,
      Auteur = boek.Auteur,
      ISBN = boek.ISBN,
      AantalPaginas = boek.AantalPaginas,
      PublicatieDatum = boek.PublicatieDatum,
      IsUitgeleend = boek.IsUitgeleend
    }).ToList();

    return Ok(resultaat);
  }

  [HttpPost]
  public async Task<ActionResult> VoegToe(CreateBoekDto dto)
  {
    var boek = new Boek(dto.Titel, dto.Auteur, dto.ISBN, dto.AantalPaginas, dto.PublicatieDatum);
    await _service.AddBoekAsync(boek);

    return CreatedAtAction(nameof(GetAlle), null);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<BoekDto>> GetById(Guid id)
  {
    var boek = await _service.GetBoekByIdAsync(id);
    if (boek == null)
    {
      return NotFound();
    }

    var dto = new BoekDto
    {
      Id = boek.Id,
      Titel = boek.Titel,
      Auteur = boek.Auteur,
      ISBN = boek.ISBN,
      AantalPaginas = boek.AantalPaginas,
      PublicatieDatum = boek.PublicatieDatum,
      IsUitgeleend = boek.IsUitgeleend
    };

    return Ok(dto);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(Guid id)
  {
    var bestaandBoek = await _service.GetBoekByIdAsync(id);
    if (bestaandBoek == null)
    {
      return NotFound();
    }

    await _service.DeleteBoekAsync(id);
    return NoContent();
  }

  [HttpPut("{id}/toggle-uitgeleend")]
  public async Task<ActionResult> ToggleUitgeleend(Guid id)
  {
    var boek = await _service.GetBoekByIdAsync(id);
    if (boek == null)
    {
      return NotFound();
    }

    await _service.ToggleUitgeleendStatusAsync(id);
    return NoContent();
  }
}
