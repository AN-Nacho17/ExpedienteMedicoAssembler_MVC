using ExpedienteMedico.Data;
using ExpedienteMedico.Repository.IRepository;

namespace ExpedienteMedico.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ISpecialtyRepository Specialty { get; private set; }
        public IPhysicianRepository Physician { get; private set; }

        public IUserRepository User { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Specialty = new SpecialtyRepository(_db);
            Physician = new PhysicianRepository(_db);
            User = new UserRepository(_db);
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
