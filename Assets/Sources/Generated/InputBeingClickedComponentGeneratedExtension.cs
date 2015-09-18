namespace Entitas {
    public partial class Entity {
        static readonly InputBeingClickedComponent inputBeingClickedComponent = new InputBeingClickedComponent();

        public bool isInputBeingClicked {
            get { return HasComponent(ComponentIds.InputBeingClicked); }
            set {
                if (value != isInputBeingClicked) {
                    if (value) {
                        AddComponent(ComponentIds.InputBeingClicked, inputBeingClickedComponent);
                    } else {
                        RemoveComponent(ComponentIds.InputBeingClicked);
                    }
                }
            }
        }

        public Entity IsInputBeingClicked(bool value) {
            isInputBeingClicked = value;
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherInputBeingClicked;

        public static AllOfMatcher InputBeingClicked {
            get {
                if (_matcherInputBeingClicked == null) {
                    _matcherInputBeingClicked = new Matcher(ComponentIds.InputBeingClicked);
                }

                return _matcherInputBeingClicked;
            }
        }
    }
}
