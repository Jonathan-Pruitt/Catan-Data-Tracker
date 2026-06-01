using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace CatanCompanion.models
{
    internal class Game
    {
        private int _gameType = 0; //0-Standard ; 1- Seafarers
        private int _currentRound = 1;
        private int[] _rollCounter = new int[11];
        private Stopwatch _gameClock = new Stopwatch();
        private Stopwatch _turnClock = new Stopwatch();
        
        //private GameBoard _board = new GameBoard();
        
        private PlayerModel _hasLargestArmy;
        private PlayerModel _hasLongestRoad;
        private PlayerModel _winner;
        private RoundModel[] _rounds;
        
        public Game()
        {

        }

        public int GameType { get { return _gameType; } }

        public string GameTypeString { 
            get {
                string[] gameTypeArray = {"Catan", "Seafarers"};
                return gameTypeArray[_gameType];
            }
        }

        public RoundModel[] Rounds { get { return _rounds; } }

        public int RoundsCount { get { return _rounds != null ? _rounds.Length : 0; } }
        
        public Stopwatch GameClock {
            get { return _gameClock; }
        }

        public Stopwatch TurnClock {
            get {return _turnClock; } 
        }

        public PlayerModel Winner {
            get {return _winner; } set {_winner = value;} 
        }

        public void AddRound(PlayerModel[] players, TimeSpan gameTime) {
            if (_rounds != null) {
                RoundModel[] update = new RoundModel[_rounds.Length + 1];
                int index = 0;
                while (index < _rounds.Length) {
                    update[index] = _rounds[index];
                    index++;
                }//END LOOP
                update[index] = new RoundModel(players, gameTime, gameTime - _rounds[index - 1].GameTime);
                _rounds = update;
            } else {
                _rounds = new RoundModel[]{new RoundModel(players, gameTime, gameTime)};
            }
        }//END METHOD

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

        public int Round {
            set { _currentRound = value; }
            get { return _currentRound; }
        }

        public int[] RollCounter {
            get { return _rollCounter; }
        }

        public PlayerModel LargestArmy {
            get { return _hasLargestArmy; } set { _hasLargestArmy = value; }
        }

        public PlayerModel LongestRoad {
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
        }//M
    }//C
}//F
