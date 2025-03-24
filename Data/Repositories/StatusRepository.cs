using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context), IStatusRepository
{
 

}
