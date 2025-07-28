using GRPCNikamooz.Domain.Models;
using GRPCNikamooz.Domain.Repositories;
using GRPCNikamooz.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCNikamooz.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }
        public async Task<int> CreateAsync(StudentModel studentForCreate)
        {
            var result = await _studentRepository.CreateAsync(studentForCreate);
            _logger.LogDebug("Student Created {StudentId}", result);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _studentRepository.DeleteAsync(id);
            return result == 1;
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<StudentModel> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(StudentForUpdateModel studentForUpdate)
        {
            var result = await _studentRepository.UpdateAsync(studentForUpdate);
            return result == 1;
        }
    }

}
