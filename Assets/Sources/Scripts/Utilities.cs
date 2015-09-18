using UnityEngine;
using System.Collections;

public class Utilities
{
    public int Random(int exclusive)
    {
        return UnityEngine.Random.Range(0, exclusive);
    }

    public int Random(int min, int max)
    {
        if (max < min)
            return min;

        return UnityEngine.Random.Range(min, max + 1);
    }

    public bool RandomBool()
    {
        if (Random(0, 1) == 1)
            return true;
        else
            return false;
    }
}
