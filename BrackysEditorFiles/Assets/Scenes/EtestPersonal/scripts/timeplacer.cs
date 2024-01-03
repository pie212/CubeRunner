
using UnityEngine;

public class timeplacer : MonoBehaviour
{
    public GameObject objectToSpawn;  // The object to be spawned
    public AudioSource audioSource;   // The audio source
    public float spawnTime;           // The time (in seconds) when the object should be spawned
    public bool RandomEN;             // bool that says if we wanna use random or not
    public float x;                 // position on the x if we dont use the random
    public float y;
    public float z = 70F;
    public float Rotx;
    public float Roty;
    public float Rotz;

    private bool hasSpawned = false;  // Flag to track if the object has been spawned

    private void Update()
    {
        // Check if the specified time has passed and the object hasn't been spawned yet
        if (audioSource.time >= spawnTime && !hasSpawned)
        {
            StartCoroutine(SpawnObjectDelayed());
            hasSpawned = true;
        }
    }

    private System.Collections.IEnumerator SpawnObjectDelayed()
    {
        yield return new WaitForEndOfFrame();
        // Instantiate the object at the desired position and rotation
        if (RandomEN == true){
            Instantiate(objectToSpawn, new Vector3(Random.Range(-11, 10),2,70), Quaternion.Euler(0,0,0));
        }
        else{
            Instantiate(objectToSpawn, new Vector3(x,y,z), Quaternion.Euler(Rotx, Roty,Rotz));
        }
    }
}
