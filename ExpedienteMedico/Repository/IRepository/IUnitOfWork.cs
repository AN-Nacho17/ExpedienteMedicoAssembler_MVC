namespace ExpedienteMedico.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISpecialtyRepository Specialty { get; }
        IPhysicianRepository Physician { get; }

        void Save();
    }
}
