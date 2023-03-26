using ErrorOr;

namespace CS.Auth.Domain.Errors;

public static class DomainErrors
{
    public static class UserErrors
    {
        public static Error DuplicateEmailError 
            = Error.Conflict("User.Email.Conflict", "Email already exists");
        public static Error DuplicateUserNameError 
            = Error.Conflict("User.UserName.Conflict", "UserName already exists");
        public static Error UserNotFound 
            = Error.NotFound("User.NotFound", "User not found");
        public static Error InvalidUserOrPassword 
            = Error.NotFound("User.UserNameOrPassword", "Invalid UserName Or Password");
        public static Error AccountLocked 
            = Error.Custom(403,"User.AccountLocked", "Account Locked");
    }
    
}