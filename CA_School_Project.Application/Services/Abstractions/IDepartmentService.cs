using CA_School_Project.Domain.Entities;

namespace CA_School_Project.Application.Services.Abstractions;

public interface IDepartmentService
{

   Task<Department> GetByIdWithIncludeAsync(int id);
   Task<Department> GetByIdAsync(int id);
   Task<bool> IsDepartmentIdExistsAsync(int id);

}
