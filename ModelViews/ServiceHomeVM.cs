using System.Collections.Generic;
using TravelFinalProject.Models;

namespace TravelFinalProject.ModelViews
{
    public class ServiceHomeVM
    {
        public DboCategoriesFlight categoryFlight { get; set; }
        public List<DboFlight> lsFlights { get; set; }
        public DboCategoriesTour categoryTour { get; set; }
        public List<DboTour> lsTours { get; set; }
        public DboCategoriesHotel categoryHotel { get; set; }
        public List<DboHotel> lsHotels { get; set; }
        public DboCategoriesTra categoryTra { get; set; }
        public List<DboTransport> lsTras { get; set; }
        public List<DboNews> lsNews { get; set; }
    }
}
