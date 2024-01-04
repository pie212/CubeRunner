
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlacerTerrain : MonoBehaviour
{
    private Terrain terrain;
    public float yoffset = 0f;
    public GameObject treecollider;

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();

        foreach(TreeInstance tree in terrain.terrainData.treeInstances)
        {
            Vector3 treeworldPoint = TerrainPointToWorld(tree.position, terrain);

            Instantiate(treecollider, new Vector3(treeworldPoint.x, treeworldPoint.y - yoffset, treeworldPoint.z), Quaternion.identity);
        }
    }

    public Vector3 TerrainPointToWorld(Vector3 terrainPoint, Terrain terrain)
    {
        Vector3 worldPoint = terrainPoint;
        worldPoint.x *= terrain.terrainData.size.x;
        worldPoint.y *= terrain.terrainData.size.y;
        worldPoint.z *= terrain.terrainData.size.z;

        worldPoint += terrain.GetPosition();

        return worldPoint;
    }
} 


