using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleLoginApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
