using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetJson (int? id, string msg)
        {
            await Task.Delay(10000);

            return Json(new
            {
                Message = $"Response ({id ?? -1 }): {msg ?? "<null>"}",
                ServerTime = DateTime.Now
            });

        }

        public async Task <IActionResult> GetTestView()
        {
            await Task.Delay(10000);
            return PartialView("Partial/DataView", DateTime.Now);
        }

    }
}