using System;

namespace TennisUwU.objects {
    public class Player {

        private string name;
        private string displayName;
        private string flagCode;

        public string Name {
            get => name;
            set => name = value;
        }

        public string FlagCode {
            get => flagCode;
            set => flagCode = value;
        }

        public string DisplayName {
            get => displayName;
            set => displayName = value;
        }
    }
}