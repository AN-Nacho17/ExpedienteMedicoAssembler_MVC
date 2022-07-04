using ExpedienteMedico.Data;
using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;

namespace ExpedienteMedico.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User obj)
        {
            _db.Users.Update(obj);
        }
    }
}
