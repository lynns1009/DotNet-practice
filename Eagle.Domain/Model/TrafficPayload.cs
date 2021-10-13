using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Eagle.Domain
{
    public class TrafficPayload
    {
        [DataMember(Name = "id")]
        public Guid EagleBotId { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "roadName")]
        public String RoadName { get; set; }

        [DataMember(Name = "direct")]
        public String Direction { get; set; }

        [DataMember(Name = "rate")]
        public decimal Rate { get; set; }

        [DataMember(Name = "averageSpeed")]
        public decimal AverageSpeed { get; set; }

    }
}
