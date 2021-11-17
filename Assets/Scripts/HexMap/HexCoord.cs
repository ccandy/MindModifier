using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCoord
{
    private int _x, _z;

    public int X
    {
        set
        {
            _x = value;
        }

        get
        {
            return _x;
        }
    }

    public int Z
    {
        set
        {
            _z = value;
        }

        get
        {
            return _x;
        }
    }

    public HexCoord(int x, int z)
    {
        _x = x;
        _z = z;
    }
    
    public static HexCoord FromOffsetCoord(int x, int z)
    {

    }

}
