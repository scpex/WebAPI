using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/school")]
    public class SchoolController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            string[] data = { "" };
            return Json(data);
        }

        [Route("api/school/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic School(string input)
        {
            var data = db.SCHOOLs.Where(w => w.SchoolName.Contains(input)).Select(s => new { s.SchoolID, s.SchoolName, s.SubDistrict, s.District, s.Province, s.PostCode, s.SchoolType, s.Department, s.Telephone, s.Fax, s.Website, s.Email, s.Latitude, s.Longitude }).ToList();
            return Json(data);
        }
    }
}