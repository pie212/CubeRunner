using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpectrumVisualizer : MonoBehaviour
{
    private AudioSource audioSource;
    private float[] spectrumData;
    public float[] LineValues { get; private set; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spectrumData = new float[1024];
        LineValues = new float[1024];
    }

    private void Update()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        for (int i = 0; i < spectrumData.Length; i++)
        {
            LineValues[i] = spectrumData[i];
            Debug.DrawLine(new Vector3(i, 0, 0), new Vector3(i, LineValues[i] * 100, 0), Color.green);
        }
    }
}
