using System;

namespace TennisUwU.objects {
    public class Match {
        private bool locked;
        private bool finished;
        
        private Player leftPlayer;
        private Player rightPlayer;

        private MatchScore scoring;

        public Match() {
            
            locked = false;

        }

        public Player LeftPlayer {
            set {
                if (!locked) leftPlayer = value;
            }
            get => leftPlayer;
        }

        public Player RightPlayer {
            set {
                if (!locked) rightPlayer = value;
            }
            get => rightPlayer;
        }

        public Player GetOpponent(Player player) {
            if (!(player == leftPlayer || player == rightPlayer)) return null;

            if (player == leftPlayer) return rightPlayer;
            return leftPlayer;

        }

        public MatchScore MatchScore {
            get => scoring;
            set => scoring = value;
        }
        
        public bool Locked {
            get => locked;
            set => locked = value;
        }

        public bool Finished {
            get => finished;
            set => finished = value;
        }
    }
}