﻿namespace PlainMinimalApi.Entities;

public class User
{
    public string? Name { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public string? Image { get; set; }
    
    public Guid? Recovery { get; set; }
}