using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace TopTravel
{
    class SpaceTravelEN
    {
        public SpaceTravelEN(int i, string dD, string aD, string dC, string p)
        {
            Id = i;
            departureDate = dD;
            arrivalDate = aD;
            departureCity = dC;
            PreparationCenter = p;
        }

        public void add_SpaceTravel()
        {
            SpaceTravelCAD c = new SpaceTravelCAD();
            c.add_SpaceTravel(this);
        }

        public void delete_SpaceTravel()
        {
            SpaceTravelCAD c = new SpaceTravelCAD();
            c.delete_SpaceTravel(this);
        }

        public void update_SpaceTravel()
        {
            SpaceTravelCAD c = new SpaceTravelCAD();
            c.update_SpaceTravel(this);
        }

        public ArrayList search_SpaceTravel()
        {
            ArrayList a = new ArrayList();
            SpaceTravelCAD c = new SpaceTravelCAD();
            a = c.search_SpaceTravel(this);
            return a;
        }
        public ArrayList show_SpaceTravel()
        {
            ArrayList a = new ArrayList();
            SpaceTravelCAD c = new SpaceTravelCAD();
            a = c.show_SpaceTravel();
            return a;
        }

        // PROPERTIES
        public int Id { get; set; }
        public string departureDate { get; set; }
        public string arrivalDate { get; set; }
        public string departureCity { get; set; }
        public string PreparationCenter { get; set; }
    }
}
