using ErrorOr;

namespace ContactMS.Utility.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials = Error.Conflict(code: "Auth.InvalidCredential",
                description: "Invalid Credentials");
        }
    }
}
