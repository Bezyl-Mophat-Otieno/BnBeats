﻿namespace BnBEats.domain;

public class User
{
    public Guid UserId {get;set;}
    public string FirstName {get;set;} = null!;
    public string LastName {get;set;} = null!;
    public string Password {get;set;} = null!;
    public string Email {get;set;} = null!;

}
