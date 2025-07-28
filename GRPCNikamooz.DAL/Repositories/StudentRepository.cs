using GRPCNikamooz.DAL.Entities;
using GRPCNikamooz.DAL.Mapper;
using GRPCNikamooz.Domain.Models;
using GRPCNikamooz.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCNikamooz.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext ctx;

        public StudentRepository(StudentContext studentContext)
        {
            this.ctx = studentContext;
        }
        public async Task<int> CreateAsync(StudentModel studentForCreate)
        {
           Student student = new Student
               {
               Description = studentForCreate.Description,
               FirstName = studentForCreate.FirstName,
               LastName = studentForCreate.LastName,    
               StudentNumber = studentForCreate.StudentNumber
           };

            foreach (var item in studentForCreate.PhoneNumbers)
            {
                student.PhoneNumbers.Add(new PhoneNumber { Value = item });
            }

            await ctx.AddAsync(student);    
            await ctx.SaveChangesAsync();
            return student.Id;  
        }

        public async Task<int> DeleteAsync(int id)
        {
           Student student = new Student { Id = id };   
            ctx.Students.Remove(student);
            var result = await ctx.SaveChangesAsync();  
            return result;
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
        return  await ctx.Students.Include(x => x.PhoneNumbers).Select(c=>c.ToModel()).ToListAsync();   
        }

        public async Task<StudentModel> GetByIdAsync(int id)
        {
            return (await ctx.Students.Include(x => x.PhoneNumbers).AsNoTracking().Where(c=>c.Id == id).FirstOrDefaultAsync()).ToModel();   
        }

        public async Task<int> UpdateAsync(StudentForUpdateModel studentForUpdate)
        {
            Student student = new Student 
            { Id = studentForUpdate.Id,
            Description = studentForUpdate.Description,
            FirstName = studentForUpdate.FirstName,
            LastName = studentForUpdate.LastName
            
            };

            ctx.Entry(student).Property(c=>c.FirstName).IsModified = true;
            ctx.Entry(student).Property(c => c.LastName).IsModified = true;
            ctx.Entry(student).Property(c => c.Description).IsModified = true;

           var result = await ctx.SaveChangesAsync();
            return result;
        }
    }
}
