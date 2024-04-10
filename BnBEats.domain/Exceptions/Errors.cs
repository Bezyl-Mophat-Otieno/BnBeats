using ErrorOr;

namespace BnBEats.domain;

public static partial class Errors
{

    public  static class Authentication 
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "Auth:DuplicateEmail",
            description: "Email Already Exists");
        public static Error UserNotFound => Error.NotFound(
            code: "Auth:UserNotFound",
            description: "User with the provided Email does not Exist");
         public static Error IncorrectPassword => Error.NotFound(
            code: "Auth:IncorrectPassword",
            description: "Password provided is incorrect");
    }

}
