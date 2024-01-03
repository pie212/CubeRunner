

using UnityEngine;
using UnityEngine.Events;
public class BeatSpawner : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;
    public GameObject cube;
    public void spawn(){
        Debug.Log("E");
        Instantiate(cube, new Vector3(Random.Range(-11, 10),2,50), Quaternion.Euler(0,0,0));
    }

    public void Update(){
            foreach (Intervals interval in _intervals) 
            {
            float sampledTime = (_audioSource.timeSamples/ (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm))); 
            interval.CheckForNewInterval (sampledTime);
            }
    }
}

[System.Serializable]

public class Intervals {
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _LastInterval;
    
    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * _steps);

    }


    public void CheckForNewInterval (float interval){

        if (Mathf.FloorToInt(interval) != _LastInterval){
            _LastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}
