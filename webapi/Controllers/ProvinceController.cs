using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc.Routing;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/province")]
    public class ProvinceController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            string[] data = { "CH_ID", "CHANGWAT_T", "CHANGWAT_E" };
            return Json(data);
        }
        [Route("api/province/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic Province(string input)
        {
            var data = db.TAMBONs.Where(w => w.CHANGWAT_T.Contains(input)).Select(s => new { s.CH_ID, s.CHANGWAT_T, s.CHANGWAT_E }).Take(1).ToList();
            return Json(data);
        }
    }
}