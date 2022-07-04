using ExpedienteMedico.Data;
using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;

namespace ExpedienteMedico.Repository
{
    public class PhysicianRepository : Repository<Physician>, IPhysicianRepository
    {
        private ApplicationDbContext _db;

        public PhysicianRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Physician obj)
        {
            _db.Physicians.Update(obj);
        }
    }
}
