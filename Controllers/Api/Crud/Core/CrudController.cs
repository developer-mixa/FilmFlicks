using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Entities.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFlicks.Controllers.Api.Crud.Core;

[Authorize("AdminPolicy")]
public class CrudController<T>(IBaseRepository<T, long> crudRepository) : Controller
where T: IdEntity
{
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] T entity)
    {
        await crudRepository.Create(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] T entity)
    {
        if (id != entity.Id)
            return BadRequest();

        
        await crudRepository.Update(entity);
        return Ok(entity);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var entity = await crudRepository.Get(id);
        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    [HttpGet]
    public async Task<IActionResult> Select()
    {
        var entities = await crudRepository.Select();
        return Ok(entities);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var entity = await crudRepository.Get(id);
        if (entity == null)
            return NotFound();

        await crudRepository.Delete(entity);
        return NoContent();
    }
}