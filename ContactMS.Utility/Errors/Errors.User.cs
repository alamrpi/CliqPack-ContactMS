using ErrorOr;

namespace ContactMS.Utility.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail = Error.Validation(code: "User.Duplicate Email", description: "Email is exists.");
        }
    }
}
