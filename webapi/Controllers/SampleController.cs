using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webapi.Controllers
{
    public class SampleController : ApiController
    {
        /// <summary>
        /// Get time
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public string GetTime([FromUri] Time t)
        {
            return string.Format("Received Time: {0}:{1}.{2}", t.Hour, t.Minute, t.Second);
        }
    }


    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
}
