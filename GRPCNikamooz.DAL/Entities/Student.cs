using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCNikamooz.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentNumber { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Description { get; init; }

        public List<PhoneNumber> PhoneNumbers { get; init; } = new List<PhoneNumber>();
    }

    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
