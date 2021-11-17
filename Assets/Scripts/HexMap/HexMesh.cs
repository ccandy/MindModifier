using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    // Start is called before the first frame update

    Mesh _hexMesh;
    List<Vector3> _vertices;
    List<int> _triangles;
    private void Awake()
    {
        _hexMesh = new Mesh();

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = _hexMesh;

        _vertices = new List<Vector3>();
        _triangles = new List<int>();

    }

    public void Triangulate(HexCell[] cells)
    {
        _hexMesh.Clear();
        _vertices.Clear();
        _triangles.Clear();

        for(int n = 0; n < cells.Length; n++)
        {
            HexCell c = cells[n];
            TriangulateCell(c);
        }

        _hexMesh.vertices = _vertices.ToArray();
        _hexMesh.triangles = _triangles.ToArray();
        _hexMesh.RecalculateNormals();

    }
    private void TriangulateCell(HexCell cells)
    {
        Vector3 center = cells.transform.localPosition;
        for(int n = 0; n < 6; n++)
        {
            AddTriangle(center,
                center + HexMatrics.Corners[n],
                center + HexMatrics.Corners[n+1]);
        }
    }

    private void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = _vertices.Count;

        _vertices.Add(v1);
        _vertices.Add(v2);
        _vertices.Add(v3);

        _triangles.Add(vertexIndex);
        _triangles.Add(vertexIndex + 1);
        _triangles.Add(vertexIndex + 2);
    }

}
