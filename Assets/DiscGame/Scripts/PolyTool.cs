using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyTool : MonoBehaviour
{
    public MeshFilter meshFilter;
    public VertexHandle vertexHandlePrefab;
    public MidpointHandle midpointHandlePrefab;

    private Dictionary<Vector3,VertexHandle> vertexHandleDictionary = new Dictionary<Vector3,VertexHandle>();

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Vector3 vertex in meshFilter.mesh.vertices)
        {
            if(!vertexHandleDictionary.ContainsKey(vertex))
            {
                VertexHandle vertexHandle = Instantiate(vertexHandlePrefab,meshFilter.transform.TransformPoint(vertex),Quaternion.identity,transform);
                vertexHandle.vertexIndices.Add(i);
                vertexHandle.meshFilter = meshFilter;
                vertexHandleDictionary.Add(vertex,vertexHandle);
            }
            else
            {
                vertexHandleDictionary[vertex].vertexIndices.Add(i);
            }
            i++;
        }
        /*
        for(int i = 0; i < meshFilter.mesh.triangles.Length; i += 3)
        {
            Vector3 point1 = meshFilter.mesh.vertices[meshFilter.mesh.triangles[i]];
            Vector3 point2 = meshFilter.mesh.vertices[meshFilter.mesh.triangles[i+1]];
            Vector3 point3 = meshFilter.mesh.vertices[meshFilter.mesh.triangles[i+2]];
            Vector3 midpoint1 = Vector3.Lerp(point1,point2,0.5f);
            Vector3 midpoint2 = Vector3.Lerp(point2,point3,0.5f);
            Vector3 midpoint3 = Vector3.Lerp(point3,point1,0.5f);
            
            Instantiate(midpointHandlePrefab,meshFilter.transform.TransformPoint(midpoint1),Quaternion.identity);
            Instantiate(midpointHandlePrefab,meshFilter.transform.TransformPoint(midpoint2),Quaternion.identity);
            Instantiate(midpointHandlePrefab,meshFilter.transform.TransformPoint(midpoint3),Quaternion.identity);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
