using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{

    public HexCell HexCellPrefab;
    public HexMesh Mesh;

    private int _width = 6;
    private int _height = 6;

    HexCell[] _hexCells;
    HexMesh _hexMesh;
    
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

    private void Start()
    {
        Mesh.Triangulate(_hexCells);
    }

    private void CreateCell(int x, int z, int i)
    {
        Vector3 pos;

        pos.x = (x + z *0.5f - z/2) * (HexMatrics.InnerRad * 2.0f);
        pos.y = 0;
        pos.z = z * (HexMatrics.OuterRad * 1.5f);

        HexCell cell = Instantiate<HexCell>(HexCellPrefab);
        _hexCells[i] = cell;

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = pos;
    }


}
