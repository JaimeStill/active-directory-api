﻿using System.DirectoryServices.AccountManagement;
using System.Runtime.Versioning;

[assembly:SupportedOSPlatform("windows")]
namespace DomainTools.Models;
public class DomainUser
{
    public DomainUser() { }

    public DomainUser(UserPrincipal principal)
    {
        Guid = principal.Guid;
        Description = principal.Description;
        DisplayName = principal.DisplayName;
        DistinguishedName = principal.DistinguishedName;
        EmailAddress = principal.EmailAddress;
        Name = principal.Name;
        SamAccountName = principal.SamAccountName;
        UserPrincipalName = principal.UserPrincipalName;
        Enabled = principal.Enabled;        
    }

    public Guid? Guid { get; set; }
    public string Description { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string DistinguishedName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string SamAccountName { get; set; } = string.Empty;
    public string UserPrincipalName { get; set; } = string.Empty;
    public bool? Enabled { get; set; }

    public override string ToString() =>
        $"{SamAccountName} - {Guid}";
}
