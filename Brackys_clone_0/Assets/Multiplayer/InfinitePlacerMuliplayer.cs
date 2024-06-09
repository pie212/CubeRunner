using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlacerMuliplayer : MonoBehaviour
{

    public GameObject[] Tiles;
    public Vector3 NextSpawnPoint;
    public int AmountOfTiles = 10;
    int i;

    void PlaceTile()
    {
        GameObject temp = Instantiate(Tiles[Random.Range(0, Tiles.Length)], NextSpawnPoint - new Vector3(0f,0f,1f), Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    private void Start()
    {
        while(i != AmountOfTiles)
        {
            PlaceTile();
            i += 1;
        }
    }
}
