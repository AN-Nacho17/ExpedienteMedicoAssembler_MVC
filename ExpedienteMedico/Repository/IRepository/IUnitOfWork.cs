namespace ExpedienteMedico.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISpecialtyRepository Specialty { get; }

        void Save();
    }
}
