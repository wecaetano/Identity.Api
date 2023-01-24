using Identity.Core.Entities;
using Identity.Core.Interfaces.Repositories;

namespace Identity.Infrastructure.Data.Repositories
{
    public class BranchesRepository : IBranchesRepository
    {
        private readonly ISqlServerRepository<Branche?> _brancheRepository;

        public BranchesRepository(ISqlServerRepository<Branche?> branchRepository)
        {
            _brancheRepository = branchRepository;
        }

        public List<Branche?> GetAll()
        {
            return _brancheRepository.Find().ToList();
        }

        public Branche? GetById(int id)
        {
            return _brancheRepository.GetById(id);
        }

        public Branche? GetByUserCode(string code)
        {
            return _brancheRepository.Get(u => u.Code == code);
        }

    }
}
