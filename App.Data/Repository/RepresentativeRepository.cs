using App.core.Helpers;
using App.Data.EFCore;
using App.Data.GenericRepository;
using App.Domain.Representatives;
using AutoMapper;

namespace App.Data.Repository;

internal class RepresentativeRepository : Repository<Representative>, IRepresentativeRepository
{
    public RepresentativeRepository(EfDbContext context, IMapper mapper, ICurrentUser currentUser) : base(context, mapper, currentUser)
    {
    }


}

public interface IRepresentativeRepository : IRepository<Representative>
{
}



