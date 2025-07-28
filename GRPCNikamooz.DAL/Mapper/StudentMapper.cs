using GRPCNikamooz.DAL.Entities;
using GRPCNikamooz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GRPCNikamooz.DAL.Mapper
{
    public static class StudentMapper
    {

        public static StudentModel ToModel(this Student student)
        {
            return new StudentModel
            {
                Description = student.Description,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Id = student.Id,
                StudentNumber = student.StudentNumber,
                PhoneNumbers = student.PhoneNumbers.Select(x => x.Value).ToList(),
            };
        }
    }
}
