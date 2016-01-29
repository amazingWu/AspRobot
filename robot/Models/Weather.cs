using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace robot.Models
{
    public class WeatherMessage
    {
        [DataMember]
        public String error { get; set; }
        [DataMember]
        public String status { get; set; }
        [DataMember]
        public String date { get; set; }
        [DataMember]
        public WeatherModel[] results { get; set; }

    }
    public class WeatherModel
    {
        [DataMember]
        public String currentCity { get; set; }
        [DataMember]
        public String pm25 { get; set; }
        [DataMember]
        public Weather_data[] weather_data { get; set; }
    }
    public class Weather_data
    {
        public String date { get; set; }
        public String dayPictureUrl { get; set; }
        public String nightPictureUrl { get; set; }
        public String weather { get; set; }
        public String wind { get; set; }
        public String temperature { get; set; }
    }
}