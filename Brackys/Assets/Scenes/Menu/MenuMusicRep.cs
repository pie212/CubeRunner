using UnityEngine;

public class MenuMusicRep : MonoBehaviour
{
    public GameObject audioManagerPrefab;

    private void Update()
    {
        // Find the AudioManager in the scene.
        AudioSource audioManager = FindObjectOfType<AudioSource>();

        // If AudioManager doesn't exist, instantiate it.
        if (audioManager == null)
        {
            Instantiate(audioManagerPrefab);
        }
    }
}
