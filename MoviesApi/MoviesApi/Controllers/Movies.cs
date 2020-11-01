using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Movies : ControllerBase
    {
        private readonly ILogger<Movies> _logger;

        public Movies()
        {
        }

    }
}
