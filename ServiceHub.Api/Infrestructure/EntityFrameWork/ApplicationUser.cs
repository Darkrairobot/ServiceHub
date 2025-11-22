using Microsoft.AspNetCore.Identity;
using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Infrestructure.Entity;

public class ApplicationUser : IdentityUser
{
    
    public string Name { get; set; }
    
}