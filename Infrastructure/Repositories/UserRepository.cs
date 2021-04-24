using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}
