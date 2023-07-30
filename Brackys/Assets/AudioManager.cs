using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject audio;
    public int numberOfAudioSources;
    // Start is called before the first frame update
    void Awake()
    {
        numberOfAudioSources = CountAudioSourcesInScene();
        if (numberOfAudioSources == 0){
            Instantiate(audio);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int CountAudioSourcesInScene()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        return audioSources.Length;
    }
}
