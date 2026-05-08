using System;

internal class City : Settlement {

        public City(Settlement settlement) {
            Location[] hexes = settlement.HexArray;
            _hexes = hexes;
            settlement = null;
        }//END CONSTRUCTOR

        public int Multiplier {
            get {return 2;}
        }


        public string GetLocationsToString() {
            string locations = "";
            foreach (Location location in _hexes) {
                if (location != null) {
                    locations += $"{location.Token}-{location.Resource}; ";
                }
            }//END LOOP
            return locations;
        }//END METHOD

        public string[] GetLocationsToStringArray() {
            string[] locations = new string[3];
            for (int i = 0; i < _hexes.Length; i++) {
                if (locations != null) {
                    locations[i] = $"{_hexes[i].Token}-{_hexes[i].Resource}";
                }
            }//END LOOP           
            return locations;
        }//END METHOD

    }//END CLASS
