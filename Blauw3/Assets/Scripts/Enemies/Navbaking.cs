using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navbaking : MonoBehaviour
{
    public NavMeshSurface navmesh;
    // Start is called before the first frame update
    void Start()
    {
        navmesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
