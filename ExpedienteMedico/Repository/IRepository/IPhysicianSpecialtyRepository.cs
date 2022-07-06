using ExpedienteMedico.Models;

namespace ExpedienteMedico.Repository.IRepository
{
    public interface IPhysicianSpecialty : IRepository<PhysicianSpecialty>
    {
        void Update(PhysicianSpecialty obj);
    }
}
