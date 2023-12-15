using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = mesh; 
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        { 
            new Vector3(0.0f, 0.0f, 0.0f), //0 bottom left
            new Vector3(0.0f, 0.0f, 1.0f), //1 top left
            new Vector3(1.0f, 0.0f, 0.0f), //2 top right
            new Vector3(1.0f, 0.0f, 1.0f), //3 bottom right
            new Vector3(0.5f, 0.0f, 1.0f), //4 top coordinate
        };

        triangles = new int[]
        {
        2,1,0,
        1,2,3,
        0,2,4,
        2,3,4,
        3,1,4,
        1,0,4
        };

    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

    }
}

