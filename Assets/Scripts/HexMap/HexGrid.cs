using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{

    public HexCell HexCellPrefab;

    private int _width = 6;
    private int _height = 6;

    HexCell[] _hexCells;

    private void Awake()
    {
        _hexCells = new HexCell[_height * _width];
        int cellIndex = 0;
        for(int z = 0; z < _height; z++)
        {
            for(int x = 0; x < _width; x++)
            {
                CreateCell(x, z, cellIndex++);
            }
        }
    }

    private void CreateCell(int x, int z, int i)
    {
        Vector3 pos;

        pos.x = x * 10f;
        pos.y = 0;
        pos.z = z * 10f;

        HexCell cell = Instantiate<HexCell>(HexCellPrefab);
        _hexCells[i] = cell;

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = pos;
    }
}
