using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public AudioSource audioSource;
    public Renderer targetRenderer;
    public int frequencyBand = 7;
    public float intensityMultiplier = 10f;
    public float lerpSpeed = 10f;

    private float[] spectrumData;
    private Material targetMaterial;
    private Color originalEmissionColor;
    private float originalEmissionIntensity;

    private void Start()
    {
        // Initialize the spectrum data array
        spectrumData = new float[1024];

        // Get the material from the renderer
        targetMaterial = targetRenderer.material;

        // Store the original emission color and intensity
        originalEmissionColor = targetMaterial.GetColor("_EmissionColor");
        originalEmissionIntensity = targetMaterial.GetFloat("_EmissionIntensity");
    }

    private void Update()
    {
        // Get the audio spectrum data
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Calculate the average amplitude for the target frequency band
        float averageAmplitude = 0f;
        for (int i = 0; i < frequencyBand; i++)
        {
            averageAmplitude += spectrumData[i];
        }
        averageAmplitude /= frequencyBand;

        // Adjust the emission intensity of the material based on the average amplitude
        float targetIntensity = averageAmplitude * intensityMultiplier;
        float newIntensity = Mathf.Lerp(originalEmissionIntensity, targetIntensity, lerpSpeed * Time.deltaTime);
        targetMaterial.SetFloat("_EmissionIntensity", newIntensity);

        // Apply the changes to the material
        targetMaterial.EnableKeyword("_EMISSION");
    }
}
