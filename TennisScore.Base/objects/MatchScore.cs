using System;
using System.Collections.Generic;
using osu.Framework.Logging;

namespace TennisUwU.objects {
    public class MatchScore {

        private Match Match;
        private Dictionary<Player, Score> Scores; //0=0;1=15;2=30;3=40
        private Dictionary<Player, Score> Sets;
        private Dictionary<Player, Score> Gems;
        private bool Overtime = false;
        private bool Finished = false;
        
        public MatchScore(Match match) {
            this.Match = match;
            Scores = new Dictionary<Player, Score>();
            Sets = new Dictionary<Player, Score>();
            Gems = new Dictionary<Player, Score>();
            Scores.Add(match.LeftPlayer, new Score());
            Scores.Add(match.RightPlayer, new Score());
            Sets.Add(match.LeftPlayer, new Score());
            Sets.Add(match.RightPlayer, new Score());
            Gems.Add(match.LeftPlayer, new Score());
            Gems.Add(match.RightPlayer, new Score());
        }

        public void Score(Player player)
        {

            if (Scores.ContainsKey(player)) Scores[player].Value++;
            if (Scores[player].Value == 3 && Scores[Match.GetOpponent(player)].Value == 3) {
                Overtime = true;
                return;
            }


            if (Overtime) {
                int difference = Scores[player].Value - Scores[Match.GetOpponent(player)].Value;
                if (difference == 2 || difference == -2)
                {
                    Gem(player);
                }
                return;
            }

            if (Scores[player].Value == 4) {
                Gem(player);
            }
            
        }

        public String getDisplayScore(Player player) {

            int difference = Scores[player].Value - Scores[Match.GetOpponent(player)].Value;

            if (Overtime) {
                if (difference == 1) return "AD";
                if (difference == -1) return "40";
                if (difference == 0) return "40";
            }

            if (Scores[player].Value == 1) return "15";
            if (Scores[player].Value == 2) return "30";
            if (Scores[player].Value == 3) return "40";

            return "0";

        }
        
        //Score -> Gems -> Sets

        public String getDisplaySet(Player player) {
            
            int difference = Sets[player].Value - Sets[Match.GetOpponent(player)].Value;
            
            if (Sets[player].Value == 2) {
                Finished = true;
                return "Winner";
            }
            
            return Sets[player].Value + "";
        }

        public String getDisplayGems(Player player)
        {

            return Gems[player].Value + "";

        }
        
        private void Gem(Player player)
        {
            if (Gems.ContainsKey(player)) Gems[player].Value++;
            if (Gems[player].Value == 6)
            {
                Set(player);
                Gems[player].Reset();
                Gems[Match.GetOpponent(player)].Reset();
            }

            Scores[player].Reset();
            Scores[Match.GetOpponent(player)].Reset();
            Overtime = false;
        }

        public void Set(Player player) {
            if (Scores.ContainsKey(player)) Sets[player].Value++;

            Gems[player].Reset();
            Gems[Match.GetOpponent(player)].Reset();
            Scores[player].Reset();
            Scores[Match.GetOpponent(player)].Reset();
        }

        public int GetScore(Player player) {
            return Scores[player].Value;
        }

        public int GetSet(Player player) {
            return Sets[player].Value;
        }

    }
}