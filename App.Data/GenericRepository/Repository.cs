using app.core.EntityAndDtoStructure;
using app.core.EntityAndDtoStructure.DtoStructure;
using app.core.EntityAndDtoStructure.EntityStructure;
using App.core.EntityAndDtoStructure.Auditables;
using App.core.Helpers;
using App.core.InjectionHelper;
using App.Data.EFCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Muslim.Filter.FilterInterface;
using System.Linq.Expressions;

namespace App.Data.GenericRepository;


public class Repository<TEntity> : IRepository<TEntity>, IAutoInjection
    where TEntity : Entity
{
    #region ctor
    private readonly IConfigurationProvider _mapperConfig;
    private readonly EfDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;
    protected DbSet<TEntity> Table;
    public IQueryable<TEntity> Query => Table.AsQueryable();



    public Repository(EfDbContext context, IMapper mapper, ICurrentUser currentUser)
    {
        _context = context;
        _mapper = mapper;
        _currentUser = currentUser;
        Table = context.Set<TEntity>();
        _mapperConfig = mapper.ConfigurationProvider;
    }

    #endregion


    #region GetById

    public TEntity GetById(int id)
    {
        try
        {
            return Table.Find(id)!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public TMap GetById<TMap>(int id) where TMap : IDto
    {
        try
        {
            return Table.ProjectTo<TMap>(_mapperConfig).SingleOrDefault(x => x.Id == id)!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        try
        {
            return (await Table.FindAsync(id))!;
        }
        catch (Exception e)
        {
            //look at this 
        }
        return default!;
    }

    public async Task<TMap> GetByIdAsync<TMap>(int id) where TMap : IDBase
    {
        try
        {
            return (await Table.ProjectTo<TMap>(_mapperConfig).SingleOrDefaultAsync(x => x.Id == id))!;
        }
        catch (Exception e)
        {
            //look at this 
        }
        return default!;
    }



    #endregion


    #region GetAll

    public List<TEntity> GetAll()
    {
        try
        {
            return Table.ToList();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public List<TMap> GetAll<TMap>() where TMap : IDto
    {
        try
        {

            return Table.ProjectTo<TMap>(_mapperConfig).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        try
        {
            return await Table.ToListAsync();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return await Table.AsNoTracking().Where(condition).ToListAsync();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<List<TMap>> GetAllAsync<TMap>() where TMap : IDto
    {
        try
        {

            return await Table.ProjectTo<TMap>(_mapperConfig).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    #endregion


    #region Find
    public List<TEntity> Find(IFilter<TEntity> filter)
    {
        try
        {
            return filter.Apply(Table).ToList();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public List<TEntity> Find(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return Table.Where(condition).ToList();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public List<TMap> Find<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter
    {
        try
        {
            return filter.Apply(Table.ProjectTo<TMap>(_mapperConfig)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public List<TMap> Find<TMap>(IFilter<TEntity> filter) where TMap : IDto
    {
        try
        {
            return filter.Apply(Table).ProjectTo<TMap>(_mapperConfig).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public List<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TMap>> selector = default!)
    {
        try
        {
            if (selector == default!)
                return Table.Where(condition).ProjectTo<TMap>(_mapperConfig).ToList();
            return Table.Where(condition).Select(selector).ToList();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public List<TMap> Find<TMap>(Expression<Func<TMap, bool>> condition, Expression<Func<TEntity, TMap>> selector)
    {
        try
        {
            return Table.Select(selector).Where(condition).ToList();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }




    public async Task<List<TEntity>> FindAsync(IFilter<TEntity> filter)
    {
        try
        {
            return await filter.Apply(Table).ToListAsync();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return await Table.Where(condition).ToListAsync();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<List<TMap>> FindAsync<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter
    {
        try
        {
            return await filter.Apply(Table.ProjectTo<TMap>(_mapperConfig)).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<TMap>> FindAsync<TMap>(IFilter<TEntity> filter) where TMap : IDto
    {
        try
        {
            return await filter.Apply(Table).ProjectTo<TMap>(_mapperConfig).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TMap>> selector = default!)
    {
        try
        {
            if (selector == default)
                return await Table.Where(condition).ProjectTo<TMap>(_mapperConfig).ToListAsync();
            return await Table.Where(condition).Select(selector).ToListAsync();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<List<TMap>> FindAsync<TMap>(Expression<Func<TMap, bool>> condition, Expression<Func<TEntity, TMap>> selector)
    {
        try
        {
            return await Table.Select(selector).Where(condition).ToListAsync();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }



    #endregion


    #region FirstOrDefault

    public TEntity FirstOrDefault()
    {
        try
        {
            return Table.FirstOrDefault()!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public TMap FirstOrDefault<TMap>() where TMap : IDto
    {
        try
        {
            return Table.ProjectTo<TMap>(_mapperConfig).FirstOrDefault()!;
        }
        catch (Exception e)
        {
            //look at this

        }
        return default!;

    }
    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return Table.FirstOrDefault(condition)!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public TMap FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            return Table.Where(condition).ProjectTo<TMap>(_mapperConfig).FirstOrDefault()!;
        }
        catch (Exception e)
        {
            //look at this

        }
        return default!;

    }

    public TMap FirstOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            return Table.ProjectTo<TMap>(_mapperConfig).FirstOrDefault(condition)!;
        }
        catch (Exception e)
        {
            //look at this

        }
        return default!;

    }


    public TMap FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TMap>> selector)
    {
        try
        {
            return Table.Where(condition).Select(selector).FirstOrDefault()!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }



    public async Task<TEntity> FirstOrDefaultAsync()
    {
        try
        {
            return (await Table.FirstOrDefaultAsync())!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<TMap> FirstOrDefaultAsync<TMap>() where TMap : IDto
    {
        try
        {
            return (await Table.ProjectTo<TMap>(_mapperConfig).FirstOrDefaultAsync())!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return (await Table.FirstOrDefaultAsync(condition))!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TMap> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            return (await Table.Where(condition).ProjectTo<TMap>(_mapperConfig).FirstOrDefaultAsync())!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TMap> FirstOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            return (await Table.ProjectTo<TMap>(_mapperConfig).FirstOrDefaultAsync(condition))!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TMap> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TMap>> selector)
    {
        try
        {
            return (await Table.AsNoTracking().Where(condition).Select(selector).FirstOrDefaultAsync())!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    #endregion


    #region SingleOrDefault

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return Table.SingleOrDefault(condition)!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public TMap SingleOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            return Table.Where(condition).ProjectTo<TMap>(_mapperConfig).SingleOrDefault()!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public TMap SingleOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            return Table.ProjectTo<TMap>(_mapperConfig).SingleOrDefault(condition)!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }


    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
    {
        try
        {
            return (await Table.SingleOrDefaultAsync(condition))!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<TMap> SingleOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto
    {
        try
        {
            return (await Table.Where(condition).ProjectTo<TMap>(_mapperConfig).SingleOrDefaultAsync())!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<TMap> SingleOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto
    {
        try
        {
            return (await Table.ProjectTo<TMap>(_mapperConfig).SingleOrDefaultAsync(condition))!;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    #endregion



    #region Create

    #region entity


    public TEntity Create(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        return Table.Add(entity).Entity;
    }
    public TMap Create<TMap>(TEntity entity) where TMap : IDto
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        return _mapper.Map<TMap>(Table.Add(entity).Entity);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        return (await Table.AddAsync(entity)).Entity;
    }
    public async Task<TMap> CreateAsync<TMap>(TEntity entity) where TMap : IDto
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        return _mapper.Map<TMap>((await Table.AddAsync(entity)).Entity);
    }


    public TEntity SaveCreate(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        var entityEntity = Table.Add(entity);
        Save();
        return entityEntity.Entity;
    }
    public TMap SaveCreate<TMap>(TEntity entity) where TMap : IDto
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        var entityEntity = Table.Add(entity);
        Save();
        return _mapper.Map<TMap>(entityEntity.Entity);
    }


    public async Task<TEntity> SaveCreateAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        var entityEntity = await Table.AddAsync(entity);
        await SaveAsync();
        return entityEntity.Entity;
    }
    public async Task<TMap> SaveCreateAsync<TMap>(TEntity entity) where TMap : IDto
    {
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = _currentUser.UserId.ToString();
        var entityEntity = await Table.AddAsync(entity);
        await SaveAsync();
        return _mapper.Map<TMap>(entityEntity.Entity);
    }

    public async Task<TEntity> SaveCreateAsync(TEntity entity, int o = 1)
    {
        var entityEntity = await Table.AddAsync(entity);
        await SaveAsync();
        return entityEntity.Entity;
    }


    public List<TEntity> CreateRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        var addRange = entities.ToList();
        Table.AddRange(addRange);
        return addRange;
    }
    public List<TMap> CreateRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        var addRange = entities.ToList();
        Table.AddRange(addRange);
        return _mapper.Map<List<TMap>>(addRange);
    }



    public async Task<List<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        var addRange = entities.ToList();
        await Table.AddRangeAsync(addRange);
        return addRange;
    }
    public async Task<List<TMap>> CreateRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        var addRange = entities.ToList();
        await Table.AddRangeAsync(addRange);
        return _mapper.Map<List<TMap>>(addRange);
    }


    public List<TEntity> SaveCreateRange(IEnumerable<TEntity> entities)
    {
        var addRange = entities.ToList();

        foreach (var entity in addRange)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        Table.AddRange(addRange);
        Save();
        return addRange;
    }
    public List<TMap> SaveCreateRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        var addRange = entities.ToList();

        foreach (var entity in addRange)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }
        Table.AddRange(addRange);
        Save();
        return _mapper.Map<List<TMap>>(addRange);
    }

    public async Task<List<TEntity>> SaveCreateRangeAsync(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        var addRange = entities.ToList();
        await Table.AddRangeAsync(addRange);
        await SaveAsync();
        return addRange;
    }
    public async Task<List<TMap>> SaveCreateRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
        }

        var addRange = entities.ToList();
        await Table.AddRangeAsync(addRange);
        await SaveAsync();
        return _mapper.Map<List<TMap>>(addRange);
    }

    public async Task SaveCreateRangeAsync(IEnumerable<TEntity> entities, int o = 1)
    {
        await Table.AddRangeAsync(entities);
        await SaveAsync();
    }


    #endregion

    #region dto


    public TEntity Create<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            return Table.Add(entity).Entity;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public Tresult Create<Tresult, TMap>(TMap dto)
        where TMap : IDto
        where Tresult : IDto

    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            return _mapper.Map<Tresult>(Table.Add(entity).Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TEntity> CreateAsync<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            return (await Table.AddAsync(entity)).Entity;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public async Task<Tresult> CreateAsync<Tresult, TMap>(TMap dto)
        where TMap : IDto
        where Tresult : IDto
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            return _mapper.Map<Tresult>((await Table.AddAsync(entity)).Entity);
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }



    public List<TEntity> CreateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            Table.AddRange(entities);
            return entities;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public List<TResult> CreateRange<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            Table.AddRange(entities);
            return _mapper.Map<List<TResult>>(entities);
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }


    public async Task<List<TEntity>> CreateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            await Table.AddRangeAsync(entities);
            return entities;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public async Task<List<TResult>> CreateRangeAsync<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            await Table.AddRangeAsync(entities);
            return _mapper.Map<List<TResult>>(entities);
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }



    public TEntity SaveCreate<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            var result = Table.Add(entity).Entity;
            Save();
            return result;

        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public TResult SaveCreate<TResult, TMap>(TMap dto)
        where TMap : IDto
        where TResult : IDto

    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            var result = _mapper.Map<TResult>(Table.Add(entity).Entity);
            Save();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<TEntity> SaveCreateAsync<TMap>(TMap dto) where TMap : IDto
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            var result = (await Table.AddAsync(entity)).Entity;
            Save();
            return result;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public async Task<TResult> SaveCreateAsync<TResult, TMap>(TMap dto)
        where TMap : IDto
        where TResult : IDto
    {
        try
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = _currentUser.UserId.ToString();
            var result = _mapper.Map<TResult>((await Table.AddAsync(entity)).Entity);
            Save();
            return result;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }


    public List<TEntity> SaveCreateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            Table.AddRange(entities);
            Save();
            return entities;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public List<TResult> SaveCreateRange<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            Table.AddRange(entities);
            Save();
            return _mapper.Map<List<TResult>>(entities);
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }


    public async Task<List<TEntity>> SaveCreateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            await Table.AddRangeAsync(entities);
            await SaveAsync();
            return entities;
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }
    public async Task<List<TResult>> SaveCreateRangeAsync<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto
    {
        try
        {
            var entities = _mapper.Map<List<TEntity>>(dtos);

            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = _currentUser.UserId.ToString();
            }

            await Table.AddRangeAsync(entities);
            await SaveAsync();
            return _mapper.Map<List<TResult>>(entities);
        }
        catch (Exception e)
        {
            //look at this
            throw;
        }
    }





    #endregion

    #endregion

    #region Delete

    public TEntity Delete(TEntity entity)
    {
        try
        {
            return Table.Remove(entity).Entity;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;

    }

    public TMap Delete<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            return _mapper.Map<TMap>(Table.Remove(entity).Entity);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;

    }

    public TEntity SaveDelete(TEntity entity)
    {
        try
        {
            var _entity = Table.Remove(entity).Entity;
            Save();
            return _entity;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public TMap SaveDelete<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            var _entity = Table.Remove(entity).Entity;
            Save();
            return _mapper.Map<TMap>(_entity);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }


    public TEntity DeleteById(int id)
    {
        try
        {
            return Table.Remove(Table.Find(id)!).Entity;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public TMap DeleteById<TMap>(int id) where TMap : IDto
    {
        try
        {
            return _mapper.Map<TMap>(Table.Remove(Table.Find(id)!).Entity);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public TEntity SaveDeleteById(int id)
    {
        try
        {
            var _entity = Table.Remove(Table.Find(id)!).Entity;
            Save();
            return _entity;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public TMap SaveDeleteById<TMap>(int id) where TMap : IDto
    {
        try
        {
            var _entity = Table.Remove(Table.Find(id)!).Entity;
            Save();
            return _mapper.Map<TMap>(_entity);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
    {
        try
        {
            var entitiesList = entities.ToList();
            Table.RemoveRange(entitiesList);
            return entitiesList;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public IEnumerable<TMap> DeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var entitiesList = entities.ToList();
            Table.RemoveRange(entitiesList);
            return _mapper.Map<List<TMap>>(entitiesList);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public IEnumerable<TEntity> SaveDeleteRange(IEnumerable<TEntity> entities)
    {
        try
        {
            var entitiesList = entities.ToList();
            Table.RemoveRange(entitiesList);
            Save();
            return entitiesList;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public IEnumerable<TMap> SaveDeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var entitiesList = entities.ToList();
            Table.RemoveRange(entitiesList);
            Save();
            return _mapper.Map<List<TMap>>(entitiesList);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }




    public async Task<TMap> DeleteByIdAsync<TMap>(int id) where TMap : IDto
    {
        try
        {
            return _mapper.Map<TMap>(Table.Remove((await Table.FindAsync(id))!).Entity);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TEntity> SaveDeleteAsync(TEntity entity)
    {
        try
        {
            var result = Table.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TMap> SaveDeleteAsync<TMap>(TEntity entity) where TMap : IDto
    {
        try
        {
            var result = _mapper.Map<TMap>(Table.Remove(entity).Entity);
            await _context.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TEntity> SaveDeleteByIdAsync(int id)
    {
        try
        {
            var entity = await Table.FindAsync(id);
            var result = Table.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<TMap> SaveDeleteByIdAsync<TMap>(int id) where TMap : IDto
    {
        try
        {
            var entity = await Table.FindAsync(id);
            var result = _mapper.Map<TMap>(Table.Remove(entity).Entity);
            await _context.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<IEnumerable<TEntity>> SaveDeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            var entitiesList = entities.ToList();
            Table.RemoveRange(entitiesList);
            await _context.SaveChangesAsync();
            return entitiesList;
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }

    public async Task<IEnumerable<TMap>> SaveDeleteRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto
    {
        try
        {
            var entitiesList = entities.ToList();
            Table.RemoveRange(entitiesList);
            await _context.SaveChangesAsync();
            return _mapper.Map<List<TMap>>(entitiesList);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }







    #endregion


    #region Soft Delete


    public TEntity SoftDelete(TEntity entity)
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        return entity;
    }
    public TMap SoftDelete<TMap>(TEntity entity) where TMap : IDto
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        return _mapper.Map<TMap>(entity);
    }
    public TEntity SaveSoftDelete(TEntity entity)
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        Save();
        return entity;
    }
    public TMap SaveSoftDelete<TMap>(TEntity entity) where TMap : IDto
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        Save();
        return _mapper.Map<TMap>(entity);
    }
    public TEntity SoftDeleteById(int id)
    {
        var entity = Table.Find(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        return entity;
    }
    public TMap SoftDeleteById<TMap>(int id) where TMap : IDto
    {
        var entity = Table.Find(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        return _mapper.Map<TMap>(entity);
    }
    public TEntity SaveSoftDeleteById(int id)
    {
        var entity = Table.Find(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        Save();
        return entity;
    }
    public TMap SaveSoftDeleteById<TMap>(int id) where TMap : IDto
    {
        var entity = Table.Find(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        Save();
        return _mapper.Map<TMap>(entity);
    }



    public async Task<TEntity> SaveSoftDeleteAsync(TEntity entity)
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        await SaveAsync();
        return entity;
    }
    public async Task<TMap> SaveSoftDeleteAsync<TMap>(TEntity entity) where TMap : IDto
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        await SaveAsync();
        return _mapper.Map<TMap>(entity);
    }

    public async Task<TEntity> SoftDeleteByIdAsync(int id)
    {
        var entity = await Table.FindAsync(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        return entity;
    }

    public async Task<TMap> SoftDeleteByIdAsync<TMap>(int id) where TMap : IDto
    {
        var entity = await Table.FindAsync(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        return _mapper.Map<TMap>(entity);
    }

    public async Task<TEntity> SaveSoftDeleteByIdAsync(int id)
    {
        var entity = await Table.FindAsync(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        await SaveAsync();
        return entity;
    }

    public async Task<TMap> SaveSoftDeleteByIdAsync<TMap>(int id) where TMap : IDto
    {
        var entity = await Table.FindAsync(id);
        entity!.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = _currentUser.UserId.ToString();
        Table.Update(entity);
        await SaveAsync();
        return _mapper.Map<TMap>(entity);
    }


    #endregion



    #region Update

    private TEntity AudiUpdate(TEntity entity)
    {
        try
        {
            var auditable = Table.Select(x => new Auditable
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdateBy = x.UpdateBy,
                UpdateDate = x.UpdateDate,
                DeletedBy = x.DeletedBy,
                DeletedDate = x.DeletedDate,
                IsDeleted = x.IsDeleted
            }).FirstOrDefault(x => x.Id == entity.Id);

            entity.CreatedBy = auditable!.CreatedBy;
            entity.CreatedDate = auditable.CreatedDate;
            entity.UpdateBy = _currentUser.UserId.ToString();
            entity.UpdateDate = DateTime.Now;
            entity.DeletedBy = auditable.DeletedBy;
            entity.DeletedDate = auditable.DeletedDate;
            entity.IsDeleted = auditable.IsDeleted;
            return entity;

        }
        catch (Exception e)
        {
            return default!;
        }
    }

    private async Task<TEntity> AudiUpdateAsync(TEntity entity)
    {
        try
        {
            var auditable = await Table.AsNoTracking().Select(x => new Auditable
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdateBy = x.UpdateBy,
                UpdateDate = x.UpdateDate,
                DeletedBy = x.DeletedBy,
                DeletedDate = x.DeletedDate,
                IsDeleted = x.IsDeleted
            }).FirstOrDefaultAsync(x => x.Id == entity.Id);

            entity.CreatedBy = auditable!.CreatedBy;
            entity.CreatedDate = auditable.CreatedDate;
            entity.UpdateBy = _currentUser.UserId.ToString();
            entity.UpdateDate = DateTime.Now;
            entity.DeletedBy = auditable.DeletedBy;
            entity.DeletedDate = auditable.DeletedDate;
            entity.IsDeleted = auditable.IsDeleted;

            return entity;

        }
        catch (Exception e)
        {
            return default!;
        }
    }
    public void Update(TEntity entity)
    {
        Table.Update(AudiUpdate(entity));
    }
    public void SaveUpdate(TEntity entity)
    {


        Table.Update(AudiUpdate(entity));
        Save();
    }
    public async Task SaveUpdateAsync(TEntity entity)
    {

        Table.Update(await AudiUpdateAsync(entity));
        await SaveAsync();
    }
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        entities.Select(entity => AudiUpdate(entity));
        Table.UpdateRange(entities);
    }
    public void SaveUpdateRange(IEnumerable<TEntity> entities)
    {
        entities.Select(entity => AudiUpdate(entity));
        Table.UpdateRange(entities);
        Save();
    }
    public async Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            await AudiUpdateAsync(entity);
        }
        Table.UpdateRange(entities);
        await SaveAsync();
    }


    public void Update<TMap>(TMap dto) where TMap : IDto
    {
        var entity = _mapper.Map<TEntity>(dto);

        Table.Update(AudiUpdate(entity));
    }

    public void SaveUpdate<TMap>(TMap dto) where TMap : IDto
    {
        var entity = _mapper.Map<TEntity>(dto);
        Table.Update(AudiUpdate(entity));
        Save();
    }
    public async Task SaveUpdateAsync<TMap>(TMap dto) where TMap : IDto
    {
        var entity = _mapper.Map<TEntity>(dto);
        Table.Update(await AudiUpdateAsync(entity));
        await SaveAsync();
    }
    public void UpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        var entities = _mapper.Map<List<TEntity>>(dtos);

        foreach (var entity in entities)
        {
            AudiUpdate(entity);
        }
        Table.UpdateRange(entities);
    }
    public void SaveUpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {

        var entities = _mapper.Map<List<TEntity>>(dtos);

        foreach (var entity in entities)
        {
            AudiUpdate(entity);
        }
        Table.UpdateRange(entities);
        Save();
    }
    public async Task SaveUpdateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto
    {
        var entities = _mapper.Map<List<TEntity>>(dtos);

        foreach (var entity in entities)
        {
            await AudiUpdateAsync(entity);
        }
        Table.UpdateRange(entities);
        await SaveAsync();
    }

    #endregion


    #region Any

    public bool Any(Expression<Func<TEntity, bool>> condition) => Table.Any(condition);

    public bool Any() => Table.Any();


    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition) => await Table.AnyAsync(condition);
    public async Task<bool> AnyAsync() => await Table.AnyAsync();
    #endregion


    #region Count

    public int Count() => Table.Count();
    public async Task<int> CountAsync() => await Table.CountAsync();

    public int Count(Expression<Func<TEntity, bool>> condition) =>
        Table.Count(condition);


    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition)
        => await Table.CountAsync(condition);


    #endregion

    #region other share

    public int Save() => _context.SaveChanges();
    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql)
    {
        try
        {
            return Table.FromSqlInterpolated(sql).ToList();
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public void IgnoreUpdateProperty(TEntity entity, Expression<Func<TEntity, object>> propertyExpression)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Modified;
        entry.Property(propertyExpression).IsModified = false;
    }
    public void Dispose()
    {
        try
        {
            _context.Dispose();
        }
        catch (Exception e)
        {
            //look at this
        }
    }
    public async Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql)
    {
        try
        {
            return await _context.Database.ExecuteSqlInterpolatedAsync(sql);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public int ExecuteSqlInterpolated(FormattableString sql)
    {
        try
        {
            return _context.Database.ExecuteSqlInterpolated(sql);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public int ExecuteSqlRaw(string sql, params object[] parameters)
    {
        try
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }
    public async Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters)
    {
        try
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
        catch (Exception e)
        {
            //look at this
        }
        return default!;
    }



    #endregion


    private Auditable Auditable(int id)
    {
        try
        {
            var entity = Table.Select(x => new Auditable
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdateBy = x.UpdateBy,
                UpdateDate = x.UpdateDate,
                DeletedBy = x.DeletedBy,
                DeletedDate = x.DeletedDate,
                IsDeleted = x.IsDeleted
            }).FirstOrDefault(x => x.Id == id);

            return entity!;
        }
        catch (Exception e)
        {
            return default!;
        }
    }

}




public interface IRepository<TEntity> : IAutoInjection
    where TEntity : Entity
{
    public IQueryable<TEntity> Query { get; }

    #region GetById

    TEntity GetById(int id);

    TMap GetById<TMap>(int id) where TMap : IDto;

    Task<TEntity> GetByIdAsync(int id);

    Task<TMap> GetByIdAsync<TMap>(int id) where TMap : IDBase;



    #endregion

    #region GetAll

    List<TEntity> GetAll();
    List<TMap> GetAll<TMap>() where TMap : IDto;

    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition);
    Task<List<TMap>> GetAllAsync<TMap>() where TMap : IDto;


    #endregion



    #region Find

    List<TEntity> Find(IFilter<TEntity> filter);
    List<TEntity> Find(Expression<Func<TEntity, bool>> condition);

    List<TMap> Find<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter;

    List<TMap> Find<TMap>(IFilter<TEntity> filter) where TMap : IDto;
    List<TMap> Find<TMap>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TMap>> selector = default!);
    List<TMap> Find<TMap>(Expression<Func<TMap, bool>> condition, Expression<Func<TEntity, TMap>> selector);




    Task<List<TEntity>> FindAsync(IFilter<TEntity> filter);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition);

    Task<List<TMap>> FindAsync<TMap>(IFilter<TMap> filter) where TMap : class, IHaveFilter;

    Task<List<TMap>> FindAsync<TMap>(IFilter<TEntity> filter) where TMap : IDto;

    Task<List<TMap>> FindAsync<TMap>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TMap>> selector = default!);
    Task<List<TMap>> FindAsync<TMap>(Expression<Func<TMap, bool>> condition, Expression<Func<TEntity, TMap>> selector);



    #endregion

    #region FirstOrDefault


    TEntity FirstOrDefault();
    TMap FirstOrDefault<TMap>() where TMap : IDto;

    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> condition);

    TMap FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto;


    TMap FirstOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto;


    TMap FirstOrDefault<TMap>(Expression<Func<TEntity, bool>> condition,
        Expression<Func<TEntity, TMap>> selector);



    Task<TEntity> FirstOrDefaultAsync();
    Task<TMap> FirstOrDefaultAsync<TMap>() where TMap : IDto;
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition);

    Task<TMap> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto;

    Task<TMap> FirstOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto;

    Task<TMap> FirstOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition,
        Expression<Func<TEntity, TMap>> selector);
    #endregion

    #region SingleOrDefault

    TEntity SingleOrDefault(Expression<Func<TEntity, bool>> condition);
    TMap SingleOrDefault<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto;

    TMap SingleOrDefault<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto;


    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> condition);
    Task<TMap> SingleOrDefaultAsync<TMap>(Expression<Func<TEntity, bool>> condition) where TMap : IDto;
    Task<TMap> SingleOrDefaultAsync<TMap>(Expression<Func<TMap, bool>> condition) where TMap : IDto;

    #endregion



    #region Create

    #region entity

    TEntity Create(TEntity entity);
    TMap Create<TMap>(TEntity entity) where TMap : IDto;
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TMap> CreateAsync<TMap>(TEntity entity) where TMap : IDto;

    TEntity SaveCreate(TEntity entity);

    TMap SaveCreate<TMap>(TEntity entity) where TMap : IDto;

    Task<TEntity> SaveCreateAsync(TEntity entity);

    Task<TMap> SaveCreateAsync<TMap>(TEntity entity) where TMap : IDto;

    List<TEntity> CreateRange(IEnumerable<TEntity> entities);


    List<TMap> CreateRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;

    Task<List<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities);

    Task<List<TMap>> CreateRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;

    List<TEntity> SaveCreateRange(IEnumerable<TEntity> entities);

    List<TMap> SaveCreateRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;
    Task<List<TEntity>> SaveCreateRangeAsync(IEnumerable<TEntity> entities);

    Task<List<TMap>> SaveCreateRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;

    #endregion

    #region dto

    public TEntity Create<TMap>(TMap dto) where TMap : IDto;
    TResult Create<TResult, TMap>(TMap dto) where TMap : IDto where TResult : IDto;


    Task<TEntity> CreateAsync<TMap>(TMap dto) where TMap : IDto;
    Task<TResult> CreateAsync<TResult, TMap>(TMap dto) where TMap : IDto where TResult : IDto;



    List<TEntity> CreateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;
    List<TResult> CreateRange<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto;


    Task<List<TEntity>> CreateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;

    Task<List<TResult>> CreateRangeAsync<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto;




    TEntity SaveCreate<TMap>(TMap dto) where TMap : IDto;
    TResult SaveCreate<TResult, TMap>(TMap dto) where TMap : IDto where TResult : IDto;


    Task<TEntity> SaveCreateAsync<TMap>(TMap dto) where TMap : IDto;
    Task<TResult> SaveCreateAsync<TResult, TMap>(TMap dto) where TMap : IDto where TResult : IDto;
    Task<TEntity> SaveCreateAsync(TEntity entity, int o = 1);

    List<TEntity> SaveCreateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;
    List<TResult> SaveCreateRange<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto;


    Task<List<TEntity>> SaveCreateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;
    Task<List<TResult>> SaveCreateRangeAsync<TResult, TMap>(IEnumerable<TMap> dtos) where TMap : IDto where TResult : IDto;

    Task SaveCreateRangeAsync(IEnumerable<TEntity> dtos, int o = 1);

    #endregion

    #endregion

    #region Delete

    TEntity Delete(TEntity entity);

    TMap Delete<TMap>(TEntity entity) where TMap : IDto;

    TEntity SaveDelete(TEntity entity);

    TMap SaveDelete<TMap>(TEntity entity) where TMap : IDto;


    TEntity DeleteById(int id);

    TMap DeleteById<TMap>(int id) where TMap : IDto;

    TEntity SaveDeleteById(int id);

    TMap SaveDeleteById<TMap>(int id) where TMap : IDto;
    IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);

    IEnumerable<TMap> DeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;

    IEnumerable<TEntity> SaveDeleteRange(IEnumerable<TEntity> entities);

    IEnumerable<TMap> SaveDeleteRange<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;


    Task<TMap> DeleteByIdAsync<TMap>(int id) where TMap : IDto;

    Task<TEntity> SaveDeleteAsync(TEntity entity);

    Task<TMap> SaveDeleteAsync<TMap>(TEntity entity) where TMap : IDto;

    Task<TEntity> SaveDeleteByIdAsync(int id);

    Task<TMap> SaveDeleteByIdAsync<TMap>(int id) where TMap : IDto;

    Task<IEnumerable<TEntity>> SaveDeleteRangeAsync(IEnumerable<TEntity> entities);

    Task<IEnumerable<TMap>> SaveDeleteRangeAsync<TMap>(IEnumerable<TEntity> entities) where TMap : IDto;






    #endregion

    #region Soft Delete


    TEntity SoftDelete(TEntity entity);
    TMap SoftDelete<TMap>(TEntity entity) where TMap : IDto;
    TEntity SaveSoftDelete(TEntity entity);
    TMap SaveSoftDelete<TMap>(TEntity entity) where TMap : IDto;
    TEntity SoftDeleteById(int id);
    TMap SoftDeleteById<TMap>(int id) where TMap : IDto;
    TEntity SaveSoftDeleteById(int id);
    TMap SaveSoftDeleteById<TMap>(int id) where TMap : IDto;



    Task<TEntity> SaveSoftDeleteAsync(TEntity entity);
    Task<TMap> SaveSoftDeleteAsync<TMap>(TEntity entity) where TMap : IDto;

    Task<TEntity> SoftDeleteByIdAsync(int id);

    Task<TMap> SoftDeleteByIdAsync<TMap>(int id) where TMap : IDto;


    Task<TEntity> SaveSoftDeleteByIdAsync(int id);

    Task<TMap> SaveSoftDeleteByIdAsync<TMap>(int id) where TMap : IDto;




    #endregion

    #region Update

    void Update(TEntity entity);
    Task SaveUpdateAsync(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void SaveUpdateRange(IEnumerable<TEntity> entities);
    Task SaveUpdateRangeAsync(IEnumerable<TEntity> entities);


    void Update<TMap>(TMap dto) where TMap : IDto;

    void SaveUpdate<TMap>(TMap dto) where TMap : IDto;
    Task SaveUpdateAsync<TMap>(TMap dto) where TMap : IDto;
    void UpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;
    void SaveUpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;
    Task SaveUpdateRangeAsync<TMap>(IEnumerable<TMap> dtos) where TMap : IDto;

    #endregion

    #region Any

    bool Any(Expression<Func<TEntity, bool>> condition);
    bool Any();

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition);
    Task<bool> AnyAsync();
    #endregion

    #region Count

    int Count();
    Task<int> CountAsync();

    int Count(Expression<Func<TEntity, bool>> condition);


    Task<int> CountAsync(Expression<Func<TEntity, bool>> condition);


    #endregion

    #region other share

    IEnumerable<TEntity> FromSqlInterpolated(FormattableString sql);

    int Save();
    Task SaveAsync();

    void IgnoreUpdateProperty(TEntity entity, Expression<Func<TEntity, object>> propertyExpression);

    void Dispose();

    Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql);

    int ExecuteSqlInterpolated(FormattableString sql);

    int ExecuteSqlRaw(string sql, params object[] parameters);

    Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);


    #endregion

}
