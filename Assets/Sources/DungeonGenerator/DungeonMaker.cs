//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;

//public class DungeonMaker
//{
//    private string[,] _Map;
//    private List<Structs.Rect> _Rooms;
//    private List<Structs.Rect> _Exits;
//    private DungeonOptions  _options;



//    public string Generator(DungeonOptions options)
//    {
//        _Map = new string[options.MaxMapWidth, options.MaxMapHeight];

//        DungeonOptions _options = new DungeonOptions();
//        _options = options;

//        for (int y = 0; y < options.MaxMapHeight; y++)
//        {
//            for (int x = 0; x < options.MaxMapWidth; x++)
//            {
//                _Map[x, y] = Symbols.Unused;
//            }

//        }

//        _Rooms = new List<Structs.Rect>();
//        _Exits = new List<Structs.Rect>();





//        // place the first room in the center
//        if (!MakeRoom(_options.MaxMapWidth / 2, _options.MaxMapHeight / 2, Utl.Random(4), true))
//        {
//            Debug.Log("Unable to place the first room.");
       
//        }

//        // we already placed 1 feature (the first room)
//        for (int i = 1; i < _options.MaxFeatures; ++i)
//        {
//            if (!CreateFeature())
//            {
//                Debug.Log("Unable to place more features (placed " + i + ").");
//                break;
//            }
//        }

//        if (_options.UpStairs)
//            if (!PlaceObject(Room.UpStrairs))
//            {
//                Debug.Log("Unable to place up stairs.");

//            }

//        if (_options.DownStairs)
//            if (!PlaceObject(Room.DownStairs))
//            {
//                Debug.Log("Unable to place down stairs.");

//            }


//        for (int i = 1; i < _options.Traps; ++i)
//            if (!PlaceObject(Room.Trap))
//            {
//                Debug.Log("Unable to place Traps.");

//            }

//        for (int i = 1; i < _options.SpawnPoints; ++i)
//            if (!PlaceObject(Room.SpawnPoint))
//            {
//                Debug.Log("Unable to place Spawn Points.");
//            }

//        for (int y = 0; y < _options.MaxMapHeight; y++)
//        {
//            for (int x = 0; x < _options.MaxMapWidth; x++)
//            {


//                if (_Map[x, y] == Symbols.Unused)
//                    _Map[x, y] = Symbols.Floor;
//                else if (_Map[x, y] == Symbols.Floor || _Map[x, y] == Symbols.Corridoor)
//                    _Map[x, y] = Symbols.Unused;
//            }
//        }

        


//        return InvertedMap();
//    }



//    public string Map()
//    {
//        StringBuilder map = new StringBuilder();
//        for (int y = 0; y < _options.MaxMapHeight; ++y)
//        {
//            for (int x = 0; x < _options.MaxMapWidth; ++x)
//                map.Append(_Map[x, y]);
//        }
//        return map.ToString();
//    }

//    public string TextMap()
//    {
//        StringBuilder _map = new StringBuilder();
//        for (int y = 0; y < _options.MaxMapHeight; ++y)
//        {
//            for (int x = 0; x < _options.MaxMapWidth; ++x)
//                _map.Append(_Map[x, y]);

//            _map.AppendLine();
//        }
//        return _map.ToString();
//    }

//    public string InvertedMap()
//    {
//        StringBuilder _map = new StringBuilder();
//        int k = _options.MaxMapHeight;

//        for (int y = 0; y < _options.MaxMapHeight; y++)
//        {

//            for (int x = 0; x < _options.MaxMapWidth; x++)
//            {

//                _map.Append(_Map[x, (k - 1) - y]);

//            }
//        }
//        return _map.ToString();
//    }



//    private bool CreateFeature()
//    {
//        for (int i = 0; i < 1000; ++i)
//        {
//            if (_Exits.Count == 0)
//                break;

//            // choose a random side of a random room or corridor
//            int r = Utl.Random(_Exits.Count);
//            int x = Utl.Random(_Exits[r].x, _Exits[r].x + _Exits[r].width - 1);
//            int y = Utl.Random(_Exits[r].y, _Exits[r].y + _Exits[r].height - 1);



//            // north, south, west, east

//            for (int j = 0; j < 4; ++j)
//            {
//                if (CreateFeature(x, y, j))
//                {
//                    _Exits.RemoveAt(r);
//                    //_exits.erase(_exits.begin() + r);
//                    return true;
//                }
//            }
//        }

//        return false;
//    }

    
//    private bool CreateFeature(int x, int y, int direction)
//    {
//        int dx = 0;
//        int dy = 0;

//        if (direction == Direction.North)
//            dy = 1;
//        else if (direction == Direction.South)
//            dy = -1;
//        else if (direction == Direction.West)
//            dx = 1;
//        else if (direction == Direction.East)
//            dx = -1;

//        if (_Map[x + dx, y + dy] != Symbols.Floor &&
//            _Map[x + dx, y + dy] != Symbols.Corridoor)
//            return false;

//        if (Utl.Random(100) < _options.RoomSpawnChance)
//        {
//            if (MakeRoom(x, y, direction))
//            {
//                _Map[x, y] = Symbols.ClosedDoor;
//                return true;
//            }
//        }
//        else
//        {
//            if (MakeCorridor(x, y, direction))
//            {
//                if (_Map[x + dx, y + dy] == Symbols.Floor)
//                    _Map[x, y] = Symbols.ClosedDoor;
//                else // don't place a door between corridors
//                    _Map[x, y] = Symbols.Corridoor;

//                return true;
//            }
//        }

//        return false;
//    }

//    bool MakeRoom(int x, int y, int direction)
//    {
//        return MakeRoom(x, y, direction, false);
//    }

//    bool MakeRoom(int x, int y, int direction, bool firstroom)
//    {


//        Structs.Rect _room = new Structs.Rect(0, 0,
//        Utl.Random(_options.MinRoomSize, _options.MaxRoomSize),
//        Utl.Random(_options.MinRoomSize, _options.MaxRoomSize));

//        if (direction == Direction.North)
//        {
//            _room.x = x - _room.width / 2;
//            _room.y = y - _room.height;
//        }

//        else if (direction == Direction.South)
//        {
//            _room.x = x - _room.width / 2;
//            _room.y = y + 1;
//        }

//        else if (direction == Direction.West)
//        {
//            _room.x = x - _room.width;
//            _room.y = y - _room.height / 2;
//        }

//        else if (direction == Direction.East)
//        {
//            _room.x = x + 1;
//            _room.y = y - _room.height / 2;
//        }

//        if (PlaceRect(ref _room, Room.Floor))
//        {
//            // Dont know what this dose, fuck it.
//            //_Rooms.emplace_back(room); _Exits.emplace_bac
//            _Rooms.Add(_room);

//            if (direction != Direction.South || firstroom) // north side
//                _Exits.Add(new Structs.Rect(_room.x, _room.y - 1, _room.width, 1));
//            if (direction != Direction.North || firstroom) // south side
//                _Exits.Add(new Structs.Rect(_room.x, _room.y + _room.height, _room.width, 1));
//            if (direction != Direction.East || firstroom)  // west side
//                _Exits.Add(new Structs.Rect(_room.x - 1, _room.y, 1, _room.height));
//            if (direction != Direction.West || firstroom)  // east side
//                _Exits.Add(new Structs.Rect(_room.x + _room.width, _room.y, 1, _room.height));

//            return true;
//        }

//        return false;
//    }

//    bool MakeCorridor(int x, int y, int direction)
//    {


//        Structs.Rect corridor = new Structs.Rect(x, y, 0, 0);
     

//        var _MinCorridorLength = _options.MinCorridorLength;
//        var _MaxCorridorLength = _options.MaxCorridorLength;

//        if (Utl.RandomBool()) // horizontal corridor
//        {
//            corridor.width = Utl.Random(_MinCorridorLength, _MaxCorridorLength);
//            corridor.height = 1;

//            if (direction == Direction.North)
//            {
//                corridor.y = y - 1;

//                if (Utl.RandomBool()) // west
//                    corridor.x = x - corridor.width + 1;
//            }

//            else if (direction == Direction.South)
//            {
//                corridor.y = y + 1;

//                if (Utl.RandomBool()) // west
//                    corridor.x = x - corridor.width + 1;
//            }

//            else if (direction == Direction.West)
//                corridor.x = x - corridor.width;

//            else if (direction == Direction.East)
//                corridor.x = x + 1;
//        }

//        else // vertical corridor
//        {
//            corridor.width = 1;
//            corridor.height = Utl.Random(_MinCorridorLength, _MaxCorridorLength);

//            if (direction == Direction.North)
//                corridor.y = y - corridor.height;

//            else if (direction == Direction.South)
//                corridor.y = y + 1;

//            else if (direction == Direction.West)
//            {
//                corridor.x = x - 1;

//                if (Utl.RandomBool()) // north
//                    corridor.y = y - corridor.height + 1;
//            }

//            else if (direction == Direction.East)
//            {
//                corridor.x = x + 1;

//                if (Utl.RandomBool()) // north
//                    corridor.y = y - corridor.height + 1;
//            }
//        }

//        if (PlaceRect(ref corridor, Room.Floor))
//        {
//            var _rect = new Structs.Rect();
           
//            if (direction != Direction.South && corridor.width != 1) // north side
//                _Exits.Add(new Structs.Rect(corridor.x, corridor.y - 1, corridor.width, 1));
//            if (direction != Direction.North && corridor.width != 1) // south side
//                _Exits.Add(new Structs.Rect(corridor.x, corridor.y + corridor.height, corridor.width, 1));
//            if (direction != Direction.East && corridor.height != 1) // west side
//                _Exits.Add(new Structs.Rect(corridor.x - 1, corridor.y, 1, corridor.height));
//            if (direction != Direction.West && corridor.height != 1) // east side
//                _Exits.Add(new Structs.Rect(corridor.x + corridor.width, corridor.y, 1, corridor.height));
//            return true;
//        }

//        return false;
//    }

//   private bool PlaceRect(ref Structs.Rect rect, int room)
//   {
//       int _width = _options.MaxMapWidth;
//       int _height = _options.MaxMapHeight;


//       if ( rect.x < 1 || rect.y < 1 || rect.x + rect.width > _width - 1 || rect.y + rect.height > _height - 1)
//            return false;

//        for (int y = rect.y; y < rect.y + rect.height; ++y)
//            for (int x = rect.x; x < rect.x + rect.width; ++x)
//            {
//                if (_Map[x,y] != Symbols.Unused)
//                    return false; // the area already used
//            }

//        for (int y = rect.y - 1; y < rect.y + rect.height + 1; ++y)
//            for (int x = rect.x - 1; x < rect.x + rect.width + 1; ++x)
//            {
//                if (x == rect.x - 1 || y == rect.y - 1 || x == rect.x + rect.width || y == rect.y + rect.height)
//                    _Map[x,y] = Symbols.Wall;
//                else
//                    _Map[x,y] = Utl.IndexToSymbol(room);
//            }

//        return true;
//    }

   

//    // Placing a Object in Room.
//    private bool PlaceObject(int Room)
//    {
//        if (_Rooms.Count == 0)
//            return false;

       

//        int r = Utl.Random(_Rooms.Count);
//        int x = Utl.Random(_Rooms[r].x + 1, _Rooms[r].width - 2);
//        int y = Utl.Random(_Rooms[r].y + 1, _Rooms[r].height - 2);


//        if (_Map[x, y] == Symbols.Floor)
//        {
//            _Map[x, y] = Utl.IndexToSymbol(Room);
//            _Rooms.RemoveAt(r);
//            return true;
//        }

//        return false;
//    }
//}
