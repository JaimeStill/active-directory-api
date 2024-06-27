using System.DirectoryServices.AccountManagement;
using System.Runtime.Versioning;
using DomainTools.Models;

[assembly:SupportedOSPlatform("windows")]
namespace DomainTools.Services;

public class DomainToolsService
{
    public List<DomainUser> GetAdUsers(int limit = 10)
    {
        PrincipalContext context = new(ContextType.Domain);
        UserPrincipal principal = new(context)
        {
            Enabled = true
        };

        return SearchPrincipals(principal, limit)
            .Select(x => new DomainUser(x))
            .ToList();
    }

    public List<DomainUser> FindAdUsers(string search, int limit = 10)
    {
        PrincipalContext context = new(ContextType.Domain);

        UserPrincipal principal = new(context)
        {
            Enabled = true,
            SamAccountName = $"{search}*"
        };

        return SearchPrincipals(principal, limit)
            .Select(x => new DomainUser(x))
            .ToList();
    }

    public DomainUser FindAdUser(string account) =>
        new(GetUserPrincipal(account));

    public List<DomainGroup> GetAdUserGroups(string account) =>
        GetUserPrincipal(account)
            .GetGroups()
            .Cast<GroupPrincipal>()
            .Select(x => new DomainGroup(x))
            .ToList();

    static UserPrincipal GetUserPrincipal(string account) =>
        UserPrincipal.FindByIdentity(
            new PrincipalContext(ContextType.Domain),
            IdentityType.SamAccountName,
            account
        );

    static IEnumerable<T> SearchPrincipals<T>(T principal, int limit = 10)
    where T : Principal =>
        new PrincipalSearcher(principal)
            .FindAll()
            .Take(limit)
            .Cast<T>();
}
