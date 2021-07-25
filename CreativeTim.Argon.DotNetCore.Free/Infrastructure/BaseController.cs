using Microsoft.AspNetCore.Mvc;

namespace Ookgewoon.Web.Infrastructure
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController : Controller
    {
    }
}
