using System.Net;

namespace BnBEats.application;

public class DuplicateEmailException : Exception,IDuplicateEmailException
{
    public DuplicateEmailException()
    {
    }

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email Already Exists";
}
