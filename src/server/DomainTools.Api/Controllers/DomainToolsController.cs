using System.Runtime.Versioning;
using DomainTools.Services;
using Microsoft.AspNetCore.Mvc;

[assembly:SupportedOSPlatform("windows")]
namespace DomainTools.Api.Controllers;

[Route("[controller]")]
public class DomainToolsController(DomainToolsService svc) : ControllerBase
{
    readonly DomainToolsService svc = svc;

    [HttpGet("[action]")]
    public IActionResult GetAdUsers([FromQuery]int limit = 10) =>
        Ok(svc.GetAdUsers(limit));

    [HttpGet("[action]/{search}")]
    public IActionResult FindAdUsers([FromRoute]string search, [FromQuery]int limit = 10) =>
        Ok(svc.FindAdUsers(search, limit));

    [HttpGet("[action]/{account}")]
    public IActionResult FindAdUser([FromRoute]string account) =>
        Ok(svc.FindAdUser(account));

    [HttpGet("[action]/{account}")]
    public IActionResult GetAdUserGroups([FromRoute]string account) =>
        Ok(svc.GetAdUserGroups(account));
}