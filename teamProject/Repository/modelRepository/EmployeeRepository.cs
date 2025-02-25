using teamProject.Models;
using teamProject.Repository.ImodelRepository;

namespace teamProject.Repository.modelRepository
{
    public class EmployeeRepository : RepositoryGeneric<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TeamContext context) : base(context)
        {
        }
    }
}
