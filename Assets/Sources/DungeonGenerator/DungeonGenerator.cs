using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGenerator
{
    //private string[,] _Map;
    //private List<RectComponent> _Rooms;
    //private List<RectComponent> _Exits;

    //public DungeonGenerator()
    //{
    //    DungeonOptionsComponent _options = new DungeonOptionsComponent();
    //    DungeonGenerator(_options);
    //}

    //public string[,] DungeonGenerator(DungeonOptionsComponent options)
    //{
    //    _Map = new string[options.MaxMapWidth, options.MaxMapHeight];

    //    for (int y = 0; y < options.MaxMapHeight; y++)
    //    {
    //        for (int x = 0; x < options.MaxMapWidth; x++)
    //        {
    //          _Map[x,y] = new RoomTypeComponent().Unused;
    //        }
  
    //    }

    //    _Rooms = new List<RectComponent>();
    //    _Exits = new List<RectComponent>();




    //    return _Map;
    //}


    //// Placing a Object in Room.
    //bool PlaceObject(RoomTypeComponent room)
    //{
    //    if (_Rooms.Count == 0) 
    //        return false;

    //    Utilities _utilities = new Utilities();

    //    int r = new Utilities().Random(_Rooms.Count);
    //    int x = new Utilities().Random(_Rooms[r].x + 1, _Rooms[r].width - 2);
    //    int y = new Utilities().Random(_Rooms[r].y + 1, _Rooms[r].height - 2);

        
    //    if (_Map[x, y] == new RoomTypeComponent().Floor)
    //    {
    //        _Map[x, y] = room.Floor;
    //        _Rooms.RemoveAt(r);

    //        return true;
    //    }

    //    return false;
    //}
}
