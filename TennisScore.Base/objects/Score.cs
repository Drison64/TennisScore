namespace TennisUwU.objects {
    public class Score {

        private int ScoreValue;

        public Score() {
            ScoreValue = 0;
        }

        public Score(int value) {
            ScoreValue = value;
        }

        public int Value {
            get => ScoreValue;
            set => ScoreValue = value;
        }

        public void Reset() {
            ScoreValue = 0;
        }
        
    }
}