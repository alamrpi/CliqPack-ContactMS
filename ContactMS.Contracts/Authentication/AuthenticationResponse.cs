namespace ContactMS.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string Name,
        string Email,
        string PhoneNumber,
        string Token);
}
