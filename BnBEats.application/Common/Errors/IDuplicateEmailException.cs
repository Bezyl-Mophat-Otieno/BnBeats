using System.Net;

namespace BnBEats.application;

public interface IDuplicateEmailException
{
    public HttpStatusCode StatusCode {get;}
    public string ErrorMessage {get;}

}
