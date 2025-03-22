using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context), IStatusRepository
{
    /*
    public override async Task<StatusEntity?> GetAsync(Expression<Func<StatusEntity, bool>> expression)
    {
        var entity = await _context.Statuses
            .Include(x => x.Projects)
            .FirstOrDefaultAsync(expression);
        return entity;
    }
    */

}
