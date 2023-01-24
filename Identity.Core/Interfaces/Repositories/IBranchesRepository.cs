using Identity.Core.Entities;

namespace Identity.Core.Interfaces.Repositories
{
    public interface IBranchesRepository
    {
        List<Branche?> GetAll();
        Branche? GetByUserCode(string code);
        Branche? GetById(int id);
    }
}