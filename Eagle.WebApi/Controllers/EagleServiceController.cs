using Eagle.Domain.Repositories;
using Eagle.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eagle.Domain.Models;
using Eagle.Application.Interfaces;
using System;

namespace Eagle.Controllers
{
    [ApiController]
    [Route("/eagle")]
    public class EagleServiceController : ControllerBase
    {
        private readonly IEagleService _eagleService;
        public EagleServiceController(IEagleService eagleService)
        {
            _eagleService = eagleService ?? throw new ArgumentNullException(nameof(eagleService)); ;
        }

        [HttpGet]
        public async Task<IEnumerable<TrafficPayload>> Get()
        {
            return await _eagleService.GetAll();
        }

        [HttpPost]
        public async Task Save([FromBody] TrafficPayload trafficPayload)
        {
            await _eagleService.Save(trafficPayload);
        }
    }
}
