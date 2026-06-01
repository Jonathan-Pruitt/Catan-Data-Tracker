namespace CatanCompanion.models {
    internal class RoundModel {
        //LOG EACH PLAYERS VIC POINTS PER ROUND, WHO IS LONGEST/LARGEST, TOTAL RESOURCES EARNED

        /* CONSIDER STORING THE ENTIRE PLAYER AT THIS POINT IF FUTURE ADDITIONAL DATA IS DESIRED */
        /////////////////////
        private TimeSpan _currentGameTime;
        private TimeSpan _roundTime;
        private PlayerModel _longestPlayer;
        private PlayerModel[] _tiedLongest;
        private PlayerModel _largestPlayer;
        private PlayerModel[] _tiedLargest;
        private PlayerModel _vicPointLeader;
        private PlayerModel[] _tiedPointLead;
        private int _longRoadCount;
        private int _largeArmyCount;
        private int _vicPountCount;

        public RoundModel(PlayerModel[] players, TimeSpan gameTime, TimeSpan roundTime) {
            _currentGameTime = gameTime;
            _roundTime = roundTime;

            //CODE HERE TO STRAIN OUT SPECIFIC/LEADERSHIP DATA
            SetLongest(players);
            SetLargest(players);
            SetLeader(players);

        }//END CONSTRUCTOR

        #region PROPERTIES [GAMETIME, ROUNDTIME, LONGESTROAD, LARGESTARMY, POINTLEADER]
        public TimeSpan GameTime {
            get { return _currentGameTime; }
        }

        //TO UPDATE THE ROUND TIME, IN GAMEBOARD CHECK IF THE 'ROUND' ARRAY IS EMPTY, IF YES - ROUNDTIME = GAMETIME; IF NO, ROUNDTIME = (GAMETIME) - LAST ROUND IN ARRAY.GAMETIME
        public TimeSpan RoundTime {
            get { return _roundTime; } 
        }

        public PlayerModel[] LongestRoad {
            get { 
                return _longestPlayer != null ? new PlayerModel[]{_longestPlayer } : _tiedLongest;
            }
        }

        public PlayerModel[] LargestArmy {
            get { 
                return _largestPlayer != null ? new PlayerModel[]{_largestPlayer } : _tiedLargest;
            }
        }

        public PlayerModel[] PointLeader {
            get { 
                return _vicPointLeader != null ? new PlayerModel[]{_vicPointLeader } : _tiedPointLead;
            }
        }

        public int TopRoad {
            get {return _longRoadCount;}
        }

        public int TopKnight {
            get {return _largeArmyCount;}
        }

        public int TopVicPoint {
            get {return _vicPountCount;}
        }

        #endregion

        private void SetLongest(PlayerModel[] _players) {
            int longestFound = 0;
            PlayerModel longestPlayer = CheckLongest(_players, out longestFound);
            _longRoadCount = longestFound;

            if (longestPlayer != null) {
                _longestPlayer = longestPlayer;
            } else {
                int index = 0;
                for (int i = 0; i < _players.Length; i++) {
                    if (_players[i].LongestRoad == longestFound) {
                        index++;
                    }
                }//END LOOP
                
                PlayerModel[] longBoys = new PlayerModel[index];
                index = 0;
                for (int i = 0; i < _players.Length;i++) {
                    if (_players[i].LongestRoad == longestFound) {
                        longBoys[index++] = _players[i];
                    }
                }//END LOOP
                _tiedLongest = longBoys;
            }//END IF
        }//END METHOD
        private PlayerModel CheckLongest(PlayerModel[] _players, out int longest) {
            longest = 0;
            foreach (PlayerModel player in _players) {
                if (player.HasLongestRoad) {
                    longest = player.LongestRoad;
                    return player;
                }
            }//END LOOP
            bool isTied = false;
            
            PlayerModel p = null;
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i].LongestRoad > longest) {
                    isTied = false;
                    longest = _players[i].LongestRoad;
                    p = _players[i];
                } else if (_players[i].LongestRoad == longest) {
                    isTied = true;
                }
            }//END LOOP
            return isTied ? null : p;
        }//END METHOD

        private void SetLargest(PlayerModel[] _players) {
            int largestFound;
            PlayerModel largestPlayer = CheckLargest(_players, out largestFound);
            _largeArmyCount = largestFound;

            if (largestPlayer != null) {
                _largestPlayer = largestPlayer;
            } else {
                int index = 0;
                for (int i = 0; i < _players.Length; i++) {
                    if (_players[i].Knight == largestFound) {
                        index++;
                    }
                }//END LOOP
                
                PlayerModel[] largeBoys = new PlayerModel[index];
                index = 0;
                for (int i = 0; i < _players.Length;i++) {
                    if (_players[i].Knight == largestFound) {
                        largeBoys[index++] = _players[i];
                    }
                }//END LOOP
                _tiedLargest = largeBoys;
            }//END IF
        }//END METHOD
        private PlayerModel CheckLargest(PlayerModel[] _players, out int largest) {
            largest = 0;
            foreach (PlayerModel player in _players) {
                if (player.HasLargestArmy) {
                    largest = player.Knight;
                    return player;
                }
            }//END LOOP
            bool isTied = false;
            
            PlayerModel p = null;
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i].Knight > largest) {
                    isTied = false;
                    largest = _players[i].Knight;
                    p = _players[i];
                } else if (_players[i].Knight == largest) {
                    isTied = true;
                }
            }//END LOOP
            return isTied ? null : p;
        }//END METHOD

        private void SetLeader(PlayerModel[] _players) {
            int topVP;
            PlayerModel leader = CheckLeader(_players, out topVP);
            _vicPountCount = topVP;

            if (leader != null) {
                _vicPointLeader = leader;
            } else {
                int index = 0;
                for (int i = 0; i < _players.Length; i++) {
                    if (_players[i].VictoryPoints == topVP) {
                        index++;
                    }
                }//END LOOP
                PlayerModel[] leadBoys = new PlayerModel[index];
                index = 0;
                for (int i = 0; i < _players.Length;i++) {
                    if (_players[i].VictoryPoints == topVP) {
                        leadBoys[index++] = _players[i];
                    }
                }//END LOOP
                _tiedPointLead = leadBoys;
            }//END IF
        }//END METHOD
        private PlayerModel CheckLeader(PlayerModel[] _players, out int highest) {
            highest = 0;
            
            bool isTied = false;
            
            PlayerModel p = null;
            for (int i = 0; i < _players.Length; i++) {
                if (_players[i].VictoryPoints > highest) {
                    isTied = false;
                    highest = _players[i].VictoryPoints;
                    p = _players[i];
                } else if (_players[i].VictoryPoints == highest) {
                    isTied = true;
                }
            }//END LOOP
            return isTied ? null : p;
        }//END METHOD

    }//END CLASS
}
