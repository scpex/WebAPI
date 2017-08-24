using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/district")]
    public class DistrictController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            string[] data = { "AM_ID", "AMPHOE_T", "AMPHOE_E", "CH_ID", "CHANGWAT_T", "CHANGWAT_E" };
            return Json(data);
        }
        [Route("api/district/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic District(string input)
        {
            var data = db.TAMBONs.Where(w => w.AMPHOE_T.Contains(input)).Select(s => new { s.AM_ID, s.AMPHOE_T, s.AMPHOE_E, s.CH_ID, s.CHANGWAT_T, s.CHANGWAT_E }).Take(1).ToList();
            return Json(data);
        }
    }
}