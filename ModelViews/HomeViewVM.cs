using System.Collections.Generic;
using System;
using TravelFinalProject.Models;
namespace TravelFinalProject.ModelViews
{
    public class HomeViewVM
    {
        public List<DboNews> News { get; set; }
        public List<ServiceHomeVM> Flights { get; set; }

        public List<ServiceHomeVM> Tours { get; set; }
        public List<ServiceHomeVM> Hotels { get; set; }
        public List<ServiceHomeVM> Transports { get; set; }
    }
}
