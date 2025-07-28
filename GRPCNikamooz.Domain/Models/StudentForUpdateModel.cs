namespace GRPCNikamooz.Domain.Models
{
    public record StudentForUpdateModel
    {
        public int Id { get; set; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Description { get; init; }
    }
}
