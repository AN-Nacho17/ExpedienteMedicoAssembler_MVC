namespace ExpedienteMedico.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISpecialtyRepository Specialty { get; }
        IPhysicianRepository Physician { get; }
        IUserRepository User { get; }

        IPhysicianSpecialty PhysicianSpecialty { get; }

        void Save();
    }
}
