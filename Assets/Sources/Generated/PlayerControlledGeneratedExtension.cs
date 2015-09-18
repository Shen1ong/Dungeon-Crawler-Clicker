namespace Entitas {
    public partial class Entity {
        static readonly PlayerControlled playerControlledComponent = new PlayerControlled();

        public bool isPlayerControlled {
            get { return HasComponent(ComponentIds.PlayerControlled); }
            set {
                if (value != isPlayerControlled) {
                    if (value) {
                        AddComponent(ComponentIds.PlayerControlled, playerControlledComponent);
                    } else {
                        RemoveComponent(ComponentIds.PlayerControlled);
                    }
                }
            }
        }

        public Entity IsPlayerControlled(bool value) {
            isPlayerControlled = value;
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherPlayerControlled;

        public static AllOfMatcher PlayerControlled {
            get {
                if (_matcherPlayerControlled == null) {
                    _matcherPlayerControlled = new Matcher(ComponentIds.PlayerControlled);
                }

                return _matcherPlayerControlled;
            }
        }
    }
}
