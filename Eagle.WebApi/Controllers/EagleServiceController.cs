using Eagle.Domain.Repositories;
using Eagle.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eagle.Domain.Models;
using Eagle.Application.Interfaces;
using System;
using Eagle.Application;

namespace Eagle.Controllers
{
    [ApiController]
    [Route("/eagle")]
    public class EagleServiceController : ControllerBase
    {
        private readonly IEagleRedisService _eagleRedisService;
        private readonly IEagleService _eagleService;
        public EagleServiceController(IEagleRedisService eagleRedisService, IEagleService eagleService)
        {
            _eagleRedisService = eagleRedisService ?? throw new ArgumentNullException(nameof(eagleRedisService));
            _eagleService = eagleService ?? throw new ArgumentNullException(nameof(eagleService));
        }

        [HttpGet]
        public async Task<IEnumerable<TrafficPayload>> Get()
        {
            return await _eagleRedisService.GetAll();
        }

        [HttpPost]
        public async Task Save([FromBody] TrafficPayload trafficPayload)
        {
            _eagleService.SendMessage(trafficPayload);
        }
    }
}
