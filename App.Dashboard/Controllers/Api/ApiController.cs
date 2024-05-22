using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;

namespace App.Dashboard.Controllers.Api;


public class ApiController<TEntity, TCreateDto, TShowDto> : BaseController<TEntity>
    where TEntity : Entity where TCreateDto : Dto where TShowDto : Dto

{
    public ApiController(IService<TEntity> service) : base(service)
    {
    }

    [HttpGet/*, Permissions* /]
    public virtual async Task<IActionResult> Get(int id)
        => Ok(await _service.GetByIdAsync<TShowDto>(id));

    [HttpPost, /*Permissions*/]
    public virtual async Task<IActionResult> Create(TCreateDto customerDto)
        => Ok(await _service.CreateAsync(customerDto));
    [HttpDelete, /*Permissions*/]
    public virtual async Task<IActionResult> Delete(int id)
        => Ok(await _service.DeleteByIdAsync<TShowDto>(id));

}


public class BaseController<TEntity> : ShareController
    where TEntity : Entity

{
    protected readonly IService<TEntity> _service;

    public BaseController(IService<TEntity> service) { _service = service; }


}


[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ShareController : ControllerBase
{


}

