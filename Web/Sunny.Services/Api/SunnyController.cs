using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sunny.Services.Data;

namespace Sunny.Services.Api
{
    [RoutePrefix("api/Sunny")]
    public class SunnyController : ApiController
    {
        private SunnyDatabaseContext db = new SunnyDatabaseContext();


    }
}
