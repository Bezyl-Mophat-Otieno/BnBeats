using System.Net;

namespace BnBEats.domain;

public class DuplicateEmailException:Exception
{
    public HttpStatusCode httpStatusCode => HttpStatusCode.Conflict;

    public  string ErrorMessage => "Email Already Exists";

}
