using UnityEngine;

public class timeplacerAN : MonoBehaviour
{
    public GameObject objectToSpawn; // The object you want to spawn
    public AudioSource audioSource; // The audio source to analyze
    public float spawnTime = 10f; // The time in seconds to spawn the object
    public Animator animation;    
    private bool hasSpawnedObject;

    private void Start()
    {
        hasSpawnedObject = false;
    }

    private void Update()
    {
        if (!hasSpawnedObject && audioSource.time >= spawnTime)
        {
            StartCoroutine(SpawnObjectDelayed());            //function called through time or something
            hasSpawnedObject = true;          
        }
    }

    private System.Collections.IEnumerator SpawnObjectDelayed() // dont know what this does but it works
    {
        yield return new WaitForEndOfFrame();   //makes things work

        // Spawn the object at the desired position
        animation.SetBool("Start", true);
        //Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}



