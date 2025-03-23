using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Material mat;

    private Vector3[] vertical = new Vector3[4];
    private Vector2[] uv = new Vector2[4];
    private int[] triangles = new int[6];

    Mesh mesh;
    GameObject meshObject;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMeshData();

        mesh = new Mesh();
        mesh.name = "new_Mesh";

        meshObject = new GameObject("Mesh Object", typeof(MeshRenderer), typeof(MeshFilter));

        meshObject.GetComponent<MeshFilter>().mesh = mesh;
        meshObject.GetComponent<MeshRenderer>().material = mat;

        mesh.vertices = vertical;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private void GenerateMeshData()
    {
        vertical[0] = new Vector3(0,0,0);
        vertical[1] = new Vector3(0,1,0);
        vertical[2] = new Vector3(1,1,0);
        vertical[3] = new Vector3(1,0,0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        uv[0] = new Vector2(0,0);
        uv[1] = new Vector2(0,1);
        uv[2] = new Vector2(1,1);
        uv[3] = new Vector2(1,0);
    }

    // Update is called once per frame
    void Update()
    {
        vertical[2] = new Vector3(1.5f + Mathf.Sin(Time.time)/3, 1 + Mathf.Sin(Time.time) / 3,0);
        vertical[2] = new Vector3(1.5f + Mathf.Sin(Time.time)/3, 0 + Mathf.Sin(Time.time) / 3,0);
    }
}
