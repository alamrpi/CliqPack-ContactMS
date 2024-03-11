namespace ContactMS.Domain.Entities
{
    public class Contact : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public static Guid MakeId()
        {
            return Guid.NewGuid();
        }
    }
}
