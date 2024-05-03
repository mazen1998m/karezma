using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.Data.GenericRepository;
using Muslim.Filter.FilterInterface;



namespace App.Application.GenericService;


public class Service<TEntity> : IAutoInjection, IService<TEntity> where TEntity : Entity

{
    #region ctor
    private readonly IRepository<TEntity> _repository;


    public Service(IRepository<TEntity> _repository)
    {
        this._repository = _repository;
    }

    #endregion



    #region GetById

    public virtual Result<TEntity> GetById(int id)
    {
        try
        {
            var entity = _repository.GetById(id);
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }

    }

    public virtual async Task<Result<TEntity>> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }


    public virtual Result<TMap> GetById<TMap>(int id) where TMap : IDto
    {
        try
        {
            var dto = _repository.GetById<TMap>(id);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : IDto
    {
        try
        {
            var dto = await _repository.GetByIdAsync<TMap>(id);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    #endregion

    #region GetAll


    public virtual Result<List<TEntity>> GetAll()
    {
        try
        {
            var entities = _repository.GetAll();
            return Result<List<TEntity>>.Success(entities);
        }
        catch (Exception e)
        {
            return Result<List<TEntity>>.Exception(e);
        }
    }

    public virtual async Task<Result<List<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            return Result<List<TEntity>>.Success(entities);
        }
        catch (Exception e)
        {
            return Result<List<TEntity>>.Exception(e);
        }

    }

    public virtual Result<List<TMap>> GetAll<TMap>() where TMap : IDto
    {
        try
        {
            var dtos = _repository.GetAll<TMap>();
            return Result<List<TMap>>.Success(dtos);
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }

    public virtual async Task<Result<List<TMap>>> GetAllAsync<TMap>() where TMap : IDto
    {
        try
        {
            var dtos = await _repository.GetAllAsync<TMap>();
            return Result<List<TMap>>.Success(dtos);
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }

    }



    #endregion

    #region Find

    public virtual Result<List<TEntity>> Find(IFilter<TEntity> filter)
    {
        try
        {
            var entities = _repository.Find(filter);
            var count = filter.ApplyFilterOnly(_repository.Query).Count();
            return Result<List<TEntity>>.Success(entities, count, filter.PageSize);

        }
        catch (Exception e)
        {
            return Result<List<TEntity>>.Exception(e);
        }
    }

    public virtual Result<List<TMap>> Find<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter
    {
        try
        {
            var dtos = _repository.Find(filter);
            //var count = filter.ApplyFilterOnly((IQueryable<TMap>)(_repository.Query)).Count();
            var count = dtos.Count();
            return Result<List<TMap>>.Success(dtos, count, filter.PageSize);

        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }
    public virtual Result<List<TMap>> Find<TMap>(IFilter<TEntity> filter) where TMap : IDto
    {
        try
        {
            var dtos = _repository.Find<TMap>(filter);
            var count = filter.ApplyFilterOnly(_repository.Query).Count();
            return Result<List<TMap>>.Success(dtos, count, filter.PageSize);

        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }
    public virtual Result<List<TEntity>> Find(Expression<Func<TEntity, bool>> condition, int pageSize = 0)
    {
        try
        {
            var entities = _repository.Find(condition);
            var count = _repository.Query.Where(condition).Count();
            return Result<List<TEntity>>.Success(entities, count, pageSize);

        }
        catch (Exception e)
        {
            return Result<List<TEntity>>.Exception(e);
        }

    }

    public virtual Result<List<TMap>> Find<TMap>(Expression<Func<TEntity, bool>> condition, int pageSize = 0, Expression<Func<TEntity, TMap>> selector = default!)
    {
        try
        {
            var dto = _repository.Find(condition, selector);
            var count = _repository.Query.Where(condition).Count();
            return Result<List<TMap>>.Success(dto, count, pageSize);

        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }

    }

    public virtual Result<List<TMap>> Find<TMap>(Expression<Func<TMap, bool>> condition,
        Expression<Func<TEntity, TMap>> selector, int pageSize = 0)
    {
        try
        {
            var dto = _repository.Find(condition, selector);
            return Result<List<TMap>>.Success(dto, dto.Count, pageSize);
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }


    public virtual async Task<Result<List<TEntity>>> FindAsync(IFilter<TEntity> filter)
    {
        try
        {
            var entities = await _repository.FindAsync(filter);
            var count = await _repository.CountAsync();
            return Result<List<TEntity>>.Success(entities, count, filter.PageSize);
        }
        catch (Exception e)
        {
            return Result<List<TEntity>>.Exception(e);
        }
    }
    public virtual async Task<Result<List<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> condition, int pageSize = 0)
    {
        try
        {
            var entities = await _repository.FindAsync(condition);
            var count = await _repository.CountAsync();
            return Result<List<TEntity>>.Success(entities, count, pageSize);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public virtual async Task<Result<List<TMap>>> FindAsync<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter
    {
        try
        {
            var dtos = await _repository.FindAsync(filter);
            var count = await _repository.CountAsync();
            return Result<List<TMap>>.Success(dtos, count, filter.PageSize);
        }
        catch (Exception e)
        {

            return Result<List<TMap>>.Exception(e);
        }
    }
    public virtual async Task<Result<List<TMap>>> FindAsync<TMap>(IFilter<TEntity> filter) where TMap : IDto
    {
        try
        {
            var dtos = await _repository.FindAsync<TMap>(filter);
            var count = await _repository.CountAsync();
            return Result<List<TMap>>.Success(dtos, count, filter.PageSize);
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }
    public virtual async Task<Result<List<TMap>>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition, int pageSize = 0, Expression<Func<TEntity, TMap>> selector = default!)
    {
        try
        {
            var dtos = await _repository.FindAsync(condition, selector);
            var count = await _repository.CountAsync();
            return Result<List<TMap>>.Success(dtos, count, pageSize);
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }
    public virtual async Task<Result<List<TMap>>> FindAsync<TMap>(Expression<Func<TMap, bool>> condition, Expression<Func<TEntity, TMap>> selector, int pageSize = 0)
    {
        try
        {
            var dtos = await _repository.FindAsync(condition, selector);
            var count = await _repository.CountAsync();
            return Result<List<TMap>>.Success(dtos, count, pageSize);
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }


    #endregion

    #region FirstOrDefault


    public virtual Result<TEntity> FirstOrDefault()
    {
        try
        {
            var entity = _repository.FirstOrDefault();
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }

    public virtual Result<TMap> FirstOrDefault<TMap>() where TMap : IDto
    {
        try
        {
            var dto = _repository.FirstOrDefault<TMap>();
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual Result<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            var entity = _repository.FirstOrDefault(condition);
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }



    public virtual Result<TMap> FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = _repository.FirstOrDefault<TMap>(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual Result<TMap> FirstOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = _repository.FirstOrDefault(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }

    }

    public virtual Result<TMap> FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition,
        Expression<Func<TEntity, TMap>> selector)
    {
        try
        {
            var dto = _repository.FirstOrDefault(condition, selector);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual async Task<Result<TEntity>> FirstOrDefaultAsync()
    {
        try
        {
            var entity = await _repository.FirstOrDefaultAsync();
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> FirstOrDefaultAsync<TMap>() where TMap : IDto
    {
        try
        {
            var dto = await _repository.FirstOrDefaultAsync<TMap>();
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            var entity = await _repository.FirstOrDefaultAsync(condition);
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = await _repository.FirstOrDefaultAsync<TMap>(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> FirstOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = await _repository.FirstOrDefaultAsync(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition,
        Expression<Func<TEntity, TMap>> selector)
    {
        try
        {
            var dto = await _repository.FirstOrDefaultAsync(condition, selector);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }




    #endregion

    #region SingleOrDefault

    public virtual Result<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            var entity = _repository.SingleOrDefault(condition);
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }

    public virtual Result<TMap> SingleOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = _repository.SingleOrDefault<TMap>(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual Result<TMap> SingleOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = _repository.SingleOrDefault(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TEntity>> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            var entity = await _repository.SingleOrDefaultAsync(condition);
            return Result<TEntity>.Success(entity);
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> SingleOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = await _repository.SingleOrDefaultAsync<TMap>(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> SingleOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            var dto = await _repository.SingleOrDefaultAsync(condition);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }
    #endregion

    #region Create
    public virtual Result<TMap> Create<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var validatorError = ValidateResult.Errors(dto, out var isValid);


            if (!isValid) return Result<TMap>.ValidatorFail(validatorError);

            dto = _repository.SaveCreate<TMap, TMap>(dto);
            return Result<TMap>.Success(dto);


        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }

    }

    public virtual Result<TResult> Create<TResult, TMap>(TMap dto)
        where TMap : IDto
        where TResult : IDto
    {
        try
        {
            var validatorError = ValidateResult.Errors(dto, out var isValid);


            if (!isValid) return Result<TResult>.ValidatorFail(validatorError);

            var result = _repository.SaveCreate<TResult, TMap>(dto);

            return Result<TResult>.Success(result);


        }
        catch (Exception e)
        {
            return Result<TResult>.Exception(e);
        }

    }

    public virtual Result<List<TMap>> CreateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        dtos = dtos.ToList();
        var validatorErrors = new List<ValidatorError>();
        var isValid = true;
        foreach (var dto in dtos)
        {
            var errors = ValidateResult.Errors(dto, out var _isValid);
            if (_isValid) continue;

            validatorErrors.AddRange(errors);
            isValid = isValid && _isValid;
        }

        if (!isValid) return Result<List<TMap>>.ValidatorFail(validatorErrors);

        var entities = _repository.SaveCreateRange<TMap, TMap>(dtos);

        return Result<List<TMap>>.Success(entities);


    }

    public virtual async Task<Result<TMap>> CreateAsync<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var validatorError = ValidateResult.Errors(dto, out var isValid);

            if (!isValid)
            {
                var result = Result<TMap>.ValidatorFail(validatorError);
                result.Response = dto;
                return result;
            }

            dto = await _repository.SaveCreateAsync<TMap, TMap>(dto);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TEntity>> CreateAsync(TEntity entity)
    {
        try
        {
            return Result<TEntity>.Success(await _repository.SaveCreateAsync(entity, 0));
        }
        catch (Exception e)
        {
            return Result<TEntity>.Exception(e);
        }
    }
    public virtual async Task<Result<TResult>> CreateAsync<TResult, TMap>(TMap dto)
        where TMap : IDto
        where TResult : IDto
    {
        try
        {
            var validatorError = ValidateResult.Errors(dto, out var isValid);

            if (!isValid) return Result<TResult>.ValidatorFail(validatorError);

            var result = await _repository.SaveCreateAsync<TResult, TMap>(dto);

            return Result<TResult>.Success(result);
        }
        catch (Exception e)
        {
            return Result<TResult>.Exception(e);
        }
    }

    public virtual async Task<Result<List<TMap>>> CreateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        dtos = dtos.ToList();
        var validatorErrors = new List<ValidatorError>();
        var isValid = true;
        foreach (var dto in dtos)
        {
            var errors = ValidateResult.Errors(dto, out var _isValid);
            if (_isValid) continue;

            validatorErrors.AddRange(errors);
            isValid = isValid && _isValid;
        }

        if (!isValid) return Result<List<TMap>>.ValidatorFail(validatorErrors);

        var entities = await _repository.SaveCreateRangeAsync<TMap, TMap>(dtos);

        return Result<List<TMap>>.Success(entities);


    }

    #endregion

    #region Delete

    public virtual Result<TMap> Delete<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            var dto = _repository.SaveDelete<TMap>(entity);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }
    public virtual Result<TMap> DeleteById<TMap>(int id) where TMap : IDto
    {
        try
        {
            var dto = _repository.SaveDeleteById<TMap>(id);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual Result<IEnumerable<TMap>> DeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var dtos = _repository.SaveDeleteRange<TMap>(entities);
            return Result<IEnumerable<TMap>>.Success(dtos);
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }
    public virtual Result<IEnumerable<TMap>> DeleteRangeByIds<TMap>(IEnumerable<int> id) where TMap : IDto
    {
        try
        {
            var results = id.Select(i => _repository.SaveDeleteById<TMap>(i)).ToList();
            return Result<IEnumerable<TMap>>.Success(results);
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }


    public virtual async Task<Result<TMap>> DeleteAsync<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            var dto = await _repository.SaveDeleteAsync<TMap>(entity);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }
    public virtual async Task<Result<TMap>> DeleteByIdAsync<TMap>(int id) where TMap : IDto
    {
        try
        {
            var dto = await _repository.SaveDeleteByIdAsync<TMap>(id);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<IEnumerable<TMap>>> DeleteRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var dtos = await _repository.SaveDeleteRangeAsync<TMap>(entities);
            return Result<IEnumerable<TMap>>.Success(dtos);
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }
    public virtual async Task<Result<List<TMap>>> DeleteRangeByIdsAsync<TMap>(IEnumerable<int> id) where TMap : IDto
    {
        try
        {
            var result = Result<List<TMap>>.Create();
            result.Response = new List<TMap>();

            foreach (var i in id)
            {
                try
                {
                    var dto = await _repository.SaveDeleteByIdAsync<TMap>(i);
                    result.Response.Add(dto);
                }
                catch (Exception e)
                {
                    result.AddError(e.Message);
                    continue;
                }

            }

            return result;
        }
        catch (Exception e)
        {
            return Result<List<TMap>>.Exception(e);
        }
    }




    #endregion

    #region softDelete

    public virtual Result<TMap> SoftDelete<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            var dto = _repository.SaveSoftDelete<TMap>(entity);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual Result<TMap> SoftDeleteById<TMap>(int id) where TMap : IDto
    {
        try
        {
            var dto = _repository.SaveSoftDeleteById<TMap>(id);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual Result<IEnumerable<TMap>> SoftDeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var result = Result<IEnumerable<TMap>>.Create();
            result.Response = new List<TMap>();
            result.IsSuccess = true;

            foreach (var entity in entities)
            {
                try
                {
                    var dto = _repository.SaveSoftDelete<TMap>(entity);
                    result.Response.Append(dto);
                }
                catch (Exception e)
                {
                    result.AddError(e.Message);
                    result.IsSuccess = false;
                    continue;
                }
            }

            return result;
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }
    public virtual Result<IEnumerable<TMap>> SoftDeleteRangeByIds<TMap>(IEnumerable<int> id) where TMap : IDto
    {

        try
        {
            var result = Result<IEnumerable<TMap>>.Create();
            result.Response = new List<TMap>();
            result.IsSuccess = true;

            foreach (var i in id)
            {
                try
                {
                    var dto = _repository.SaveSoftDeleteById<TMap>(i);
                    result.Response.Append(dto);
                }
                catch (Exception e)
                {
                    result.AddError(e.Message);
                    result.IsSuccess = false;
                    continue;
                }
            }

            return result;
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }




    public virtual async Task<Result<TMap>> SoftDeleteAsync<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            var dto = await _repository.SaveSoftDeleteAsync<TMap>(entity);
            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> SoftDeleteByIdAsync<TMap>(int id) where TMap : IDto
    {
        try
        {
            var dto = await _repository.SaveSoftDeleteByIdAsync<TMap>(id);

            return Result<TMap>.Success(dto);
        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual async Task<Result<IEnumerable<TMap>>> SoftDeleteRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var result = Result<IEnumerable<TMap>>.Create();
            result.Response = new List<TMap>();
            result.IsSuccess = true;

            foreach (var entity in entities)
            {
                try
                {
                    var dto = await _repository.SaveSoftDeleteAsync<TMap>(entity);
                    result.Response.Append(dto);
                }
                catch (Exception e)
                {
                    result.AddError(e.Message);
                    result.IsSuccess = false;
                    continue;
                }
            }

            return result;
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }
    public virtual async Task<Result<IEnumerable<TMap>>> SoftDeleteRangeByIdsAsync<TMap>(IEnumerable<int> id) where TMap : IDto
    {

        try
        {
            var result = Result<IEnumerable<TMap>>.Create();
            result.Response = new List<TMap>();
            result.IsSuccess = true;

            foreach (var i in id)
            {
                try
                {
                    var dto = await _repository.SaveSoftDeleteByIdAsync<TMap>(i);
                    result.Response.Append(dto);
                }
                catch (Exception e)
                {
                    result.AddError(e.Message);
                    result.IsSuccess = false;
                    continue;
                }
            }

            return result;
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }




    #endregion


    #region Update



    public virtual Result<TMap> Update<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var validatorError = ValidateResult.Errors(dto, out var isValid);

            if (!isValid) return Result<TMap>.ValidatorFail(validatorError);

            _repository.SaveUpdate(dto);
            return Result<TMap>.Success(dto);

        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);

        }
    }

    public virtual Result<IEnumerable<TMap>> UpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        try
        {
            var validatorErrors = new List<ValidatorError>();
            var isValid = true;
            foreach (var dto in dtos)
            {
                var errors = ValidateResult.Errors(dto, out var _isValid);
                if (_isValid) continue;

                validatorErrors.AddRange(errors);
                isValid = isValid && _isValid;
            }

            if (!isValid) return Result<IEnumerable<TMap>>.ValidatorFail(validatorErrors);

            _repository.SaveUpdateRange(dtos);
            return Result<IEnumerable<TMap>>.Success(dtos);
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }

    public virtual async Task<Result<TMap>> UpdateAsync<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var validatorError = ValidateResult.Errors(dto, out var isValid);

            if (!isValid)
            {
                var result = Result<TMap>.ValidatorFail(validatorError);
                result.Response = dto;
                return result;
            }

            await _repository.SaveUpdateAsync(dto);
            return Result<TMap>.Success(dto);

        }
        catch (Exception e)
        {
            return Result<TMap>.Exception(e);
        }
    }


    public virtual async Task<Result<IEnumerable<TMap>>> UpdateRangeAsync<TMap>(IEnumerable<TMap> dtos)
        where TMap : IDto
    {
        try
        {
            var validatorErrors = new List<ValidatorError>();
            var isValid = true;
            foreach (var dto in dtos)
            {
                var errors = ValidateResult.Errors(dto, out var _isValid);
                if (_isValid) continue;

                validatorErrors.AddRange(errors);
                isValid = isValid && _isValid;
            }

            if (!isValid) return Result<IEnumerable<TMap>>.ValidatorFail(validatorErrors);

            await _repository.SaveUpdateRangeAsync(dtos);
            return Result<IEnumerable<TMap>>.Success(dtos);
        }
        catch (Exception e)
        {
            return Result<IEnumerable<TMap>>.Exception(e);
        }
    }


    #endregion

    #region other

    public virtual int Any(Expression<Func<TEntity, bool>> condition)
    {

        try
        {
            return _repository.Any(condition) ? 1 : 0;
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual bool Any()
    {

        try
        {
            return _repository.Any();
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual async Task<int> AnyAsync(Expression<Func<TEntity, bool>> condition)
    {

        try
        {
            return await _repository.AnyAsync(condition) ? 1 : 0;
        }
        catch (Exception e)
        {

            return -1;
        }
    }

    public virtual async Task<bool> AnyAsync()
    {

        try
        {
            return await _repository.AnyAsync();
        }
        catch (Exception)
        {

            return false;
        }
    }

    public virtual int Count()
    {

        try
        {
            return _repository.Count();
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual async Task<int> CountAsync()
    {

        try
        {
            return await _repository.CountAsync();
        }
        catch (Exception e)
        {

            return -1;
        }
    }

    public virtual int Count(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return _repository.Count(condition);
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return await _repository.CountAsync(condition);
        }
        catch (Exception e)
        {
            return -1;
        }
    }


    public virtual async Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql)
    {

        try
        {
            return await _repository.ExecuteSqlInterpolatedAsync(sql);
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual int ExecuteSqlInterpolated(FormattableString sql)
    {
        try
        {
            return _repository.ExecuteSqlInterpolated(sql);
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual int ExecuteSqlRaw(string sql, params object[] parameters)
    {
        try
        {
            return _repository.ExecuteSqlRaw(sql, parameters);
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual async Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters)
    {
        try
        {
            return await _repository.ExecuteSqlRawAsync(sql, parameters);
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public virtual IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
    {
        try
        {
            return _repository.FromSqlInterpolated(sql);
        }
        catch (Exception e)
        {
            return default!;
        }
    }



    #endregion
}

public interface IService<TEntity> : IAutoInjection where TEntity : Entity
{
    #region GetById

    Result<TEntity> GetById(int id);

    Task<Result<TEntity>> GetByIdAsync(int id);


    Result<TMap> GetById<TMap>(int id) where TMap : IDto;

    Task<Result<TMap>> GetByIdAsync<TMap>(int id) where TMap : IDto;


    #endregion

    #region GetAll


    Result<List<TEntity>> GetAll();

    Task<Result<List<TEntity>>> GetAllAsync();

    Result<List<TMap>> GetAll<TMap>() where TMap : IDto;

    Task<Result<List<TMap>>> GetAllAsync<TMap>() where TMap : IDto;



    #endregion

    #region Find

    Result<List<TEntity>> Find(IFilter<TEntity> filter);

    Result<List<TMap>> Find<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter;
    Result<List<TMap>> Find<TMap>(IFilter<TEntity> filter) where TMap : IDto;
    Result<List<TEntity>> Find(Expression<Func<TEntity, bool>> condition, int pageSize = 0);

    Result<List<TMap>> Find<TMap>(Expression<Func<TEntity, bool>> condition, int pageSize = 0,
        Expression<Func<TEntity, TMap>> selector = default!);

    Result<List<TMap>> Find<TMap>(Expression<Func<TMap, bool>> condition,
        Expression<Func<TEntity, TMap>> selector, int pageSize = 0);


    Task<Result<List<TEntity>>> FindAsync(IFilter<TEntity> filter);

    Task<Result<List<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> condition,
        int pageSize = 0);

    //Task<Result<List<TMap>>> FindAsync<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter;
    Task<Result<List<TMap>>> FindAsync<TMap>(IFilter<TEntity> filter) where TMap : IDto;

    Task<Result<List<TMap>>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition,
       int pageSize = 0, Expression<Func<TEntity, TMap>> selector = default!);

    Task<Result<List<TMap>>> FindAsync<TMap>(Expression<Func<TMap, bool>> condition,
        Expression<Func<TEntity, TMap>> selector, int pageSize = 0);


    #endregion

    #region FirstOrDefault

    Result<TEntity> FirstOrDefault();

    Result<TMap> FirstOrDefault<TMap>() where TMap : IDto;

    Result<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> condition);

    Result<TMap> FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto;

    Result<TMap> FirstOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto;

    Result<TMap> FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition,
       Expression<Func<TEntity, TMap>> selector);

    Task<Result<TEntity>> FirstOrDefaultAsync();

    Task<Result<TMap>> FirstOrDefaultAsync<TMap>() where TMap : IDto;

    Task<Result<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition);

    Task<Result<TMap>> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition)
       where TMap : IDto;

    Task<Result<TMap>> FirstOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition)
       where TMap : IDto;

    Task<Result<TMap>> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition,
       Expression<Func<TEntity, TMap>> selector);



    #endregion

    #region SingleOrDefault

    Result<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> condition);

    Result<TMap> SingleOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto;
    Result<TMap> SingleOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto;
    Task<Result<TEntity>> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> condition);

    Task<Result<TMap>> SingleOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition)
       where TMap : IDto;
    Task<Result<TMap>> SingleOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition)
       where TMap : IDto;
    #endregion

    #region Create

    Result<TMap> Create<TMap>(TMap dto) where TMap : IDto;


    Result<TResult> Create<TResult, TMap>(TMap dto) where TMap : IDto where TResult : IDto;

    Result<List<TMap>> CreateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;

    Task<Result<TMap>> CreateAsync<TMap>(TMap dto) where TMap : IDto;
    Task<Result<TEntity>> CreateAsync(TEntity entity);


    Task<Result<TResult>> CreateAsync<TResult, TMap>(TMap dto)
    where TMap : IDto
    where TResult : IDto;

    Task<Result<List<TMap>>> CreateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;

    #endregion

    #region Delete

    Result<TMap> Delete<TMap>(TEntity entity) where TMap : IDto;
    Result<TMap> DeleteById<TMap>(int id) where TMap : IDto;


    Result<IEnumerable<TMap>> DeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;
    Result<IEnumerable<TMap>> DeleteRangeByIds<TMap>(IEnumerable<int> id) where TMap : IDto;


    Task<Result<TMap>> DeleteAsync<TMap>(TEntity entity) where TMap : IDto;
    Task<Result<TMap>> DeleteByIdAsync<TMap>(int id) where TMap : IDto;

    Task<Result<IEnumerable<TMap>>> DeleteRangeAsync<TMap>(IEnumerable<TEntity> entities)
        where TMap : IDto;

    Task<Result<List<TMap>>> DeleteRangeByIdsAsync<TMap>(IEnumerable<int> id) where TMap : IDto;




    #endregion

    #region softDelete

    Result<TMap> SoftDelete<TMap>(TEntity entity) where TMap : IDto;

    Result<TMap> SoftDeleteById<TMap>(int id) where TMap : IDto;

    Result<IEnumerable<TMap>> SoftDeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;
    Result<IEnumerable<TMap>> SoftDeleteRangeByIds<TMap>(IEnumerable<int> id) where TMap : IDto;




    Task<Result<TMap>> SoftDeleteAsync<TMap>(TEntity entity) where TMap : IDto;
    Task<Result<TMap>> SoftDeleteByIdAsync<TMap>(int id) where TMap : IDto;

    Task<Result<IEnumerable<TMap>>> SoftDeleteRangeAsync<TMap>(IEnumerable<TEntity> entities)
       where TMap : IDto;

    Task<Result<IEnumerable<TMap>>> SoftDeleteRangeByIdsAsync<TMap>(IEnumerable<int> id)
        where TMap : IDto;



    #endregion


    #region Update



    Result<TMap> Update<TMap>(TMap dto) where TMap : IDto;

    Result<IEnumerable<TMap>> UpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;

    Task<Result<TMap>> UpdateAsync<TMap>(TMap dto) where TMap : IDto;


    Task<Result<IEnumerable<TMap>>> UpdateRangeAsync<TMap>(IEnumerable<TMap> dtos)
       where TMap : IDto;


    #endregion

    #region other

    int Any(Expression<Func<TEntity, bool>> condition);

    bool Any();

    Task<int> AnyAsync(Expression<Func<TEntity, bool>> condition);
    Task<bool> AnyAsync();

    int Count();

    Task<int> CountAsync();

    int Count(Expression<Func<TEntity, bool>> condition);

    Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);


    Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql);

    int ExecuteSqlInterpolated(FormattableString sql);

    int ExecuteSqlRaw(string sql, params object[] parameters);

    Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);

    IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);



    #endregion
}