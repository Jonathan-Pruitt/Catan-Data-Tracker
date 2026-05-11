using System.Diagnostics;

namespace CatanCompanion {
    internal class GameBoard {
        private int _gameType = 0; //0-Standard ; 1- Seafarers

        private int _currentRound = 1;
        private int[] _rollCounter = new int[11];
        private int _blockedNumber = 0;
        private string _blockedResource = "";
        private Stopwatch _gameClock = new Stopwatch();
        private Stopwatch _turnClock = new Stopwatch();        
        private Player _hasLargestArmy;
        private Player _hasLongestRoad;
        private Player _winner;
        private Round[] _rounds;

        private Location[] _hexArray;
        private Location _blockedLocation;


        #region UPDATED GAMEBOARD PROPS AND METHODS
        public GameBoard(Location[] hexArray, int gameType = 0) {
            _gameType = gameType;
            _hexArray = new Location[hexArray.Length + 1];
            for (int i = 0; i < hexArray.Length; i++) {
                _hexArray[i] = hexArray[i];
            }
            //END TEST
            for (int i = 0; i < hexArray.Length + 1; i++) {
                for (int v = i + 1; v < hexArray.Length; v++) {
                    if (_hexArray[i].LocationToString() == _hexArray[v].LocationToString()) {
                        if (_hexArray[i].ID != "b") {
                            for (int f = v + 1; f < hexArray.Length; f++) {
                                if (_hexArray[v].LocationToString() == _hexArray[f].LocationToString()) {
                                    _hexArray[f].IsDuplicate = true;
                                    _hexArray[f].ID = "c";
                                }
                            }
                            _hexArray[i].IsDuplicate = _hexArray[v].IsDuplicate = true;
                            _hexArray[v].ID = "b";
                        }
                    }
                }
            }
            _hexArray[hexArray.Length] = new Location(0, "DESERT");
        }//END CONSTRUCTOR

        public Location[] GetDuplicatesByToken(int token) { 
            Location[] temp = GetLocationsByToken(token);
            int index = 0;
            for (int i = 0; i < temp.Length; i++) {
                if (temp[i].IsDuplicate) {
                    index++;
                }
            }
            Location[] final = new Location[index];
            index = 0;
            for (int i = 0; i < temp.Length; i++) {
                if (temp[i].IsDuplicate) {
                    final[index++] = temp[i];
                }
            }
            return final;
        }//END METHOD

        public Location GetLocationByStringComparison(string fullLocationString) { 
            for (int i = 0; i < _hexArray.Length; i++) {
                if (_hexArray[i].LocationToString() == fullLocationString) {
                    return _hexArray[i];
                }
            }
            return null;
        }

        public int GameType { get { return _gameType; } }

        public string GameTypeString { 
            get {
                string[] gameTypeArray = {"Catan", "Seafarers"};
                return gameTypeArray[_gameType];
            }
        }

        public Round[] Rounds { get { return _rounds; } }

        public int RoundsCount { get { return _rounds != null ? _rounds.Length : 0; } }
        
        public Stopwatch GameClock {
            get { return _gameClock; }
        }

        public Stopwatch TurnClock {
            get {return _turnClock; } 
        }

        public Player Winner {
            get {return _winner; } set {_winner = value;} 
        }

        public void AddRound(Player[] players, TimeSpan gameTime) {
            if (_rounds != null) {
                Round[] update = new Round[_rounds.Length + 1];
                int index = 0;
                while (index < _rounds.Length) {
                    update[index] = _rounds[index];
                    index++;
                }//END LOOP
                update[index] = new Round(players, gameTime, gameTime - _rounds[index - 1].GameTime);
                _rounds = update;
            } else {
                _rounds = new Round[]{new Round(players, gameTime, gameTime)};
            }
        }//END METHOD

        public Location[] GetLocationsByToken(int token) {
            Location[] locations = null;
            int count = 0;
            for (int i = 0; i < _hexArray.Length; i++) {
                if (_hexArray[i].Token == token) {
                    count++;
                }
            }//END LOOP
            locations = new Location[count];
            int index = 0;
            for (int i = 0; i < _hexArray.Length; i++) {
                if (_hexArray[i].Token == token) {
                    locations[index++] = _hexArray[i];
                }
            }//END LOOP
            return locations;
        }//END METHOD

        public string[] GetResourcesByToken(int token) {
            Location[] locations = GetLocationsByToken(token);
            string[] resources = new string[locations.Length];
            for (int i = 0; i < resources.Length; i++) {
                resources[i] = locations[i].Resource;
            }//END LOOP
            return resources;            
        }//END METHOD

        public bool Exists(int token, string resource) {
            for (int i = 0; i < _hexArray.Length; i++) {
                if ( _hexArray[i].Token == token && _hexArray[i].Resource == resource) {
                    return true;
                }
            }
            return false;
        }//END METHOD

        public Location GetLocation(int token, string resource) {
            Location location = null;
            for (int i = 0; i < _hexArray.Length; i++) {
                if (_hexArray[i].Token == token && _hexArray[i].Resource == resource) {
                    location = _hexArray[i];
                }
            }
            return location;
        }//END METHOD

        public void BlockLocation(int token, string resource) {
            if (resource != "Unknown" && resource != "") {
                _blockedLocation = GetLocation(token, resource);
            }
        }//END METHOD
        public void BlockLocation(Location target) {
            if (target != null) {
                _blockedLocation = target;
            }
        }//END METHOD

        public Location Blocked {
            get {return _blockedLocation; } set { _blockedLocation = value; }
        }        

        public void StartGameTimer() {
            _gameClock.Start();
            _turnClock.Start();
        }//END METHOD

        public TimeSpan EndTurnTimer() {
            _turnClock.Stop();
            TimeSpan turn = _turnClock.Elapsed;
            _turnClock.Reset();
            _turnClock.Start();
            return turn;
        } 

        public void StopGameTimer() {
            _gameClock.Stop();
            _turnClock.Stop();
        }//END METHOD

        public TimeSpan GetGameTime() {
            return _gameClock.Elapsed;
        }//END METHOD

        public TimeSpan GetTurnTime() {
            return _turnClock.Elapsed;
        }

        #endregion 

        public int Round {
            set { _currentRound = value; }
            get { return _currentRound; }
        }

        public int[] RollCounter {
            get { return _rollCounter; }
        }

        public int BlockedNumber {
            get { return _blockedNumber; } set { _blockedNumber = value; }
        }

        public string BlockedResource {
            get { return _blockedResource;} set { _blockedResource = value; }
        }

        public Player LargestArmy {
            get { return _hasLargestArmy; } set { _hasLargestArmy = value; }
        }

        public Player LongestRoad {
            get { return _hasLongestRoad; } set { _hasLongestRoad = value; }
        }

        public int GetRollCount(int roll) {
            int index = roll - 2;
            return _rollCounter[index];
        }//END METHOD

        public void AddRoll(int roll) {
            int index = roll - 2;
            _rollCounter[index] += 1;
        }        
        
        private string CheckArray(int[] resourceArray, int target, string resourceName) {
            string resources = "";
            for (int i = 0; i < resourceArray.Length; i++) {
                resources += target == resourceArray[i] ? $"{resourceName} " : "";
            }
            return resources;
        }
    }//END CLASS

}
