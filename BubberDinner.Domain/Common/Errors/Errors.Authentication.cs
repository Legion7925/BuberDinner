using ErrorOr;

namespace BubberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredintials => Error.Validation(
            "auth.InvalidCredintials",
            "Invalid credintials");
    }
}
