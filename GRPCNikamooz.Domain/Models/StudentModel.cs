using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCNikamooz.Domain.Models
{
    public record class StudentModel
    {
        public int Id { get; set; }

        public string StudentNumber { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Description { get; init; }

        public List<string> PhoneNumbers { get; init; }
    }
}
