using GRPCNikamooz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCNikamooz.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>> GetAllAsync();
        Task<StudentModel> GetByIdAsync(int id);
        Task<int> CreateAsync(StudentModel studentForCreate);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(StudentForUpdateModel studentForUpdate);
    }
}
