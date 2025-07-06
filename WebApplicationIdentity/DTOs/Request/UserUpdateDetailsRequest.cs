namespace WebApplicationIdentity.DTOs.Request
{
    public class UserUpdateDetailsRequest
    {
        public DateOnly? DateOfBirth {  get; set; }
        public string? Nationality { get; set; } 
    }
}
