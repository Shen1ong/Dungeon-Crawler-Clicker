using UnityEngine;
using System.Collections;

public class Utl
{
    public static int Random(int exclusive)
    {
        return UnityEngine.Random.Range(0, exclusive);
    }

    public static int Random(int min, int max)
    {
        if (max < min)
            return min;

        return UnityEngine.Random.Range(min, max + 1);
    }

    public static bool RandomBool()
    {
        if (Random(0, 1) == 1)
            return true;
        else
            return false;
    }

    public static string IndexToSymbol(int index)
    {
        switch (index)
        {
            case Room.Unused:
                return Symbols.Unused;
            case Room.Floor:
                return Symbols.Floor;
            case Room.Corridoor:
                return Symbols.Corridoor;
            case Room.Wall:
                return Symbols.Wall;
            case Room.ClosedDoor:
                return Symbols.ClosedDoor;
            case Room.OpenDoor:
                return Symbols.OpenDoor;
            case Room.UpStrairs:
                return Symbols.UpStrairs;
            case Room.DownStairs:
                return Symbols.DownStairs;
            case Room.SpawnPoint:
                return Symbols.SpawnPoint;
            case Room.EntryDoor:
                return Symbols.EntryDoor;
            case Room.Trap:
                return Symbols.Trap;
            default:
                return Symbols.Unused;
        }

    }

    public static bool isFloorUnderneath(int index)
    {
        if (    index == Room.Unused ||
                index == Room.Floor ||
                index == Room.ClosedDoor ||
                index == Room.OpenDoor ||
                index == Room.UpStrairs ||  // Only Used for Debug  Need 3D models Made
                index == Room.DownStairs || // Only Used for Debug  Need 3D models Made
                index == Room.SpawnPoint ||
                index == Room.Trap   // Only Used for Debug,  Need 3D models Made
            )

            return true;

        return false;
    }
}
