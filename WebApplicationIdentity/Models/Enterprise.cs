namespace WebApplicationIdentity.Models
{
    public class Enterprise
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string OwnerId { get; set; } = default!;
        public User Owner { get; set; } = default!;

        public Enterprise()
        {
        }

        public Enterprise(string name, string ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }
    }
}
