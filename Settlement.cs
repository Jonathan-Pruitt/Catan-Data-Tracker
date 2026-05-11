internal class Settlement {
    protected Location[] _hexes = new Location[3];

    public Settlement(Location location1, Location location2 = null, Location location3 = null) {
        _hexes[0] = location1;
        _hexes[1] = location2;
        _hexes[2] = location3;
    }

    public Location[] HexArray {
        get {return new Location[3]{_hexes[0], _hexes[1], _hexes[2]}; }
    }

    public int ActiveLocations {
        get {
            int active = 0;
            active += _hexes[0] == null ? 0 : 1;
            active += _hexes[1] == null ? 0 : 1;
            active += _hexes[2] == null ? 0 : 1;
            return active;
        }
    }
    public int Multiplier {
        get {return 1;}
    }

    public int GetPipValue() {
        int pipValue = 0;
        foreach (Location hex in _hexes) {
            if (hex !=  null) {
                pipValue += hex.GetPipInfo();
            }
        }//END FOR
        return pipValue;
    }//END METHOD

    public string GetUniqueResourcesToString() {
        string uniqueResources = "";
        foreach (Location hex in _hexes) {
            if (hex != null) {
                if (!uniqueResources.Contains(hex.Resource)) {
                    uniqueResources += $"{hex.Resource} ";
                }
            }
        }
        return uniqueResources;
    }//END METHOD

    public string GetResource(int token) {
        string resource = "";
        foreach (Location location in _hexes) {
            if (location != null) {
                if (location.Token == token) {
                    resource += $"{location.Resource} ";
                }
            }
        }//END LOOP
        resource += resource == "" ? null : "\b";
            
        return resource;
    }//END METHOD

    public string GetLocationsToString() { 
        string locations = "";
        foreach (Location location in _hexes) {
            if (location != null) {
                locations += $"{location.LocationToString()}; ";
            }
        }//END LOOP
        return locations;
    }//END METHOD

    public string GetLocationsToStringSeparatedByPlus() { 
        string locations = "";
        foreach (Location location in _hexes) {
            if (location != null) {
                locations += $"{location.LocationToString()} + ";
            }
        }//END LOOP
        char[] resourcesBrokenUp = locations.ToCharArray();
        locations = "";
        for (int chrctr = 0; chrctr < resourcesBrokenUp.Length - 3; chrctr++) {
            locations += resourcesBrokenUp[chrctr];
        }//END LOOP
        return locations;
    }//END METHOD

    public Location[] GetLocations() {
        Location[] findings = new Location[ActiveLocations];
        for (int i = 0; i < findings.Length; i++) {
            findings[i] = _hexes[i];
        }
        return findings;
    }//END METHOD

    public int[] GetTokensArray() {
        int[] tokens = new int[ActiveLocations];
        for (int i = 0; i < tokens.Length; i++) {
            tokens[i] = _hexes[i].Token;
        }//END LOOP

        return tokens;
    }//END METHOD

    public bool HasLocation(Location target) {
        foreach (Location loc in GetLocations()) {
            if (target.LocationToString() == loc.LocationToString()) {
                return true;
            }
        }
        return false;
    }
}//END CLASS