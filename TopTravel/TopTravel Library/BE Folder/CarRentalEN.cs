using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class CarRentalEN
    {
        public CarRentalEN(int id, string l, int maxP, int minP, string vehicle)
        {
            rentalID = id;
            location = l;
            maxPrice = maxP;
            minPrice = minP;
            car = vehicle;
        }

        public void add_CarRental()
		{
			m_cc = new CarRentalCAD();
			m_cc.add_CarRental(this);
		}

        public void update_CarRental()
		{
			m_cc = new CarRentalCAD();
			m_cc.update_CarRental(this);
		}

        public void delete_CarRental()
		{
			m_cc = new CarRentalCAD();
			m_cc.delete_CarRental(this);
		}

        public void search_CarRental()
		{
			m_cc = new CarRentalCAD();
			m_cc.search_CarRental(this);
		}

        // PROPERTIES
        public int rentalID { get; set; }
        public string location { get; set; }
        public int maxPrice { get; set; }
        public int minPrice { get; set; }
        public string car { get; set; }

        //Data
        private CarRentalCAD m_cc;
    }
}
