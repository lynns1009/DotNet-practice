using Eagle.Application.Interfaces;
using Eagle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Eagle.Application
{
    public class EagleService : IEagleService
    {
        private readonly IEagleRedisService _eagleRedisService;
        private readonly IEagleMessageQueueService _eagleMessageQueueService;
        public EagleService(IEagleRedisService eagleRedisService, IEagleMessageQueueService eagleMessageQueueService)
        {
            _eagleRedisService = eagleRedisService ?? throw new ArgumentNullException(nameof(eagleRedisService));
            _eagleMessageQueueService = eagleMessageQueueService ?? throw new ArgumentNullException(nameof(eagleMessageQueueService));
        }

        public async void SendMessage(TrafficPayload trafficPayload)
        {
            var saveResult = await _eagleRedisService.Save(trafficPayload);
            if (saveResult)
            {
                _eagleMessageQueueService.SendMessage(JsonSerializer.Serialize(trafficPayload));
            }
        }
    }
}
