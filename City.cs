using System;

internal class City : Settlement {

        public City(Settlement settlement) 
            : base(settlement.HexArray[0], settlement.HexArray[1], settlement.HexArray[2])
        {
            _hexes = settlement.HexArray;
            settlement = null;
        }//END CONSTRUCTOR

        new public int Multiplier {
            get {return 2;}
        }


        new public string GetLocationsToString() {
            string locations = "";
            foreach (Location location in _hexes) {
                if (location != null) {
                    locations += $"{location.Token}-{location.Resource}; ";
                }
            }//END LOOP
            return locations;
        }//END METHOD

    }//END CLASS
