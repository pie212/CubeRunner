using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBackground : MonoBehaviour
{
    public MusicLightsMultipleObjects lightScript;
    public GameObject cubePrefab; // The prefab of the cube to instantiate
    public int numberOfCubes = 10; // Number of cubes to spawn
    public float rotationSpeed = 20f; // Speed at which the cubes rotate\
    public float distance = 1300f;

    [Header("Networked Properties")]
    public Material red;
    public Material blue;
    public Material green;

    void Start()
    {
        // Spawn cubes
        for (int i = 0; i < numberOfCubes; i++)
        {
            SpawnCube();
        }
        lightScript.cubesPlaced();
    }

    void Update()
    {
        // Rotate and check visibility for each cube
        foreach (Transform cube in transform)
        {
            cube.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * (Random.Range(100,300)/100));

            // Check if cube is outside the camera's view
            if (!IsInView(cube.position))
            {
                Destroy(cube.gameObject);
            }
        }
    }

    void SpawnCube()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 35f), Random.Range(5f, distance));
        Quaternion spawnRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        GameObject newCube = Instantiate(cubePrefab, spawnPosition, spawnRotation, transform);
        int color = Random.Range(0,3);
        if (color == 0){newCube.GetComponent<Renderer>().material = red;}
        if (color == 1){newCube.GetComponent<Renderer>().material = blue;}
        if (color == 2){newCube.GetComponent<Renderer>().material = green;}
        
        lightScript.cubes.Add(newCube);
    }

    bool IsInView(Vector3 position)
    {
        Camera mainCamera = Camera.main;
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(position);
        return viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0;
    }
}
