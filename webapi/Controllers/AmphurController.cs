using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.ADO;
namespace webapi.Controllers
{
    [Route("api/amphur")]
    public class AmphurController : ApiController
    {
        private thailandEntities1 db = new thailandEntities1();
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get()
        {
            var data = db.amphurs.Select(s => new { s.AMPHUR_CODE, s.AMPHUR_NAME, s.AMPHUR_NAME_ENG, s.PROVINCE_ID }).Take(100).ToList();
            return Json(data);
        }
        [Route("api/amphur/{input}")]
        [HttpGet]
        [AllowAnonymous]
        public dynamic Amphur(string input)
        {
            string pro_code = input.Substring(0, 2);
            var q = from a in db.amphurs
                    join p in db.provinces on pro_code equals p.PROVINCE_CODE
                    select new
                    {
                        amphur_code = a.AMPHUR_CODE,
                        amphur_name = a.AMPHUR_NAME,
                        amphur_name_eng = a.AMPHUR_NAME_ENG,
                        province_name = p.PROVINCE_NAME,
                        province_name_eng = p.PROVINCE_NAME_ENG
                    };
            var data = q.Where(w => w.amphur_code == input).Select(s => new { s.amphur_code, s.amphur_name, s.amphur_name_eng, s.province_name, s.province_name_eng }).ToList();
            //var data = db.amphurs.Where(w => w.AMPHUR_CODE == input).Select(s => new { s.AMPHUR_CODE, s.AMPHUR_NAME, s.AMPHUR_NAME_ENG, s.PROVINCE_ID }).ToList();
            return Json(data);
        }
    }
}