public static class ComponentIds {
    public const int Direction = 0;
    public const int DungeonOptions = 1;
    public const int InputBeingClicked = 2;
    public const int Input = 3;
    public const int Interactive = 4;
    public const int Movable = 5;
    public const int PlayerControlled = 6;
    public const int Position = 7;
    public const int Rect = 8;
    public const int Room = 9;
    public const int RoomType = 10;

    public const int TotalComponents = 11;

    static readonly string[] components = {
        "Direction",
        "DungeonOptions",
        "InputBeingClicked",
        "Input",
        "Interactive",
        "Movable",
        "PlayerControlled",
        "Position",
        "Rect",
        "Room",
        "RoomType"
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

namespace Entitas {
    public partial class Matcher : AllOfMatcher {
        public Matcher(int index) : base(new [] { index }) {
        }

        public override string ToString() {
            return ComponentIds.IdToString(indices[0]);
        }
    }
}