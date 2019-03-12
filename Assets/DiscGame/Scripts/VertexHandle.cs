using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexHandle : MonoBehaviour
{
    public MeshFilter meshFilter;
    public List<int> vertexIndices = new List<int>();

    private List<Vector3> vertexBuffer = new List<Vector3>();
    private Vector3 lastLocalPosition;
 
// call this if the mesh has been modified and you want to get the vertices.

    // Start is called before the first frame update
    void Start()
    {
        lastLocalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition != lastLocalPosition)
        {
            vertexBuffer.Clear();
            meshFilter.mesh.GetVertices(vertexBuffer);
            foreach(int vertexIndex in vertexIndices)
            {
                vertexBuffer[vertexIndex] = transform.localPosition;
            }
            meshFilter.mesh.SetVertices(vertexBuffer);
            meshFilter.mesh.RecalculateNormals();
            MeshCollider collider = meshFilter.GetComponent<MeshCollider>();
            if(collider)
            {
                collider.sharedMesh = meshFilter.sharedMesh;
            }
            lastLocalPosition = transform.localPosition;
        }
    }
}
