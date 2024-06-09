using UnityEngine;

public class v3_self : MonoBehaviour
{
    private AudioSource audioSource;
    private Renderer targetRenderer;
    public float intensityMultiplier = 10000f;
    public float lerpSpeed = 100f;
    public float defaultEmissionLevel = 10f;

    private Material targetMaterial;
    private float originalEmissionLevel;

    private void Start()
    {
        // Get the material from the renderer
        audioSource = FindObjectOfType<AudioSource>();
        Debug.Log(audioSource);
        targetMaterial = GetComponent<Renderer>().material;

        // Store the original emission level
        originalEmissionLevel = targetMaterial.GetFloat("_EmissionIntensity");
        
        // Set the default emission level
        targetMaterial.SetFloat("_EmissionIntensity", defaultEmissionLevel);
        targetMaterial.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        // Get the audio spectrum data
        float[] spectrumData = new float[1024];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Calculate the average amplitude
        float averageAmplitude = 0f;
        for (int i = 0; i < spectrumData.Length; i++)
        {
            averageAmplitude += spectrumData[i];
        }
        averageAmplitude /= spectrumData.Length;

        // Calculate the target emission level based on the average amplitude
        float targetEmissionLevel = averageAmplitude * intensityMultiplier;
        

        // Lerp the current emission level towards the target emission level
        float currentEmissionLevel = targetMaterial.GetFloat("_EmissionIntensity");
        float newEmissionLevel = Mathf.Lerp(currentEmissionLevel, targetEmissionLevel, lerpSpeed * Time.deltaTime);
        targetMaterial.SetFloat("_EmissionIntensity", newEmissionLevel);
    }
}
