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
            var data = db.provinces.Select(s => new { s.PROVINCE_CODE, s.PROVINCE_NAME, s.PROVINCE_NAME_ENG, s.GEO_ID }).Take(100).ToList();
            return Json(data);
        }
        [Route("api/province/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic Province(string input)
        {
            var data = db.provinces.Where(w => w.PROVINCE_CODE == input).Select(s => new { s.PROVINCE_CODE, s.PROVINCE_NAME, s.PROVINCE_NAME_ENG, s.GEO_ID }).ToList();
            return Json(data);
        }
    }
}