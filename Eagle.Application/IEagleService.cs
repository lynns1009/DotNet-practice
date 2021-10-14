using Eagle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eagle.Application
{
    public interface IEagleService
    {
        public void SendMessage(TrafficPayload trafficPayload);
    }
}
