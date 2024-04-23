using app.core.EntityAndDtoStructure.DtoStructure;
using App.web.JwtServices;

namespace App.web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ApiController<TEntity, TCreateDto, TShowDto> : ControllerBase
    where TEntity : Entity where TCreateDto : Dto where TShowDto : Dto

{
    private readonly IService<TEntity> _service;

    public ApiController(IService<TEntity> service) { _service = service; }

    [HttpGet/*, Permissions*/]
    public virtual async Task<IActionResult> Get(int id)
        => Ok(await _service.GetByIdAsync<TShowDto>(id));

    [HttpPost, Permissions]
    public virtual async Task<IActionResult> Create(TCreateDto customerDto)
        => Ok(await _service.CreateAsync(customerDto));
    [HttpDelete, Permissions]
    public virtual async Task<IActionResult> Delete(int id)
        => Ok(await _service.DeleteByIdAsync<TShowDto>(id));

}





