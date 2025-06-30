using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [Header("Mixer")]
    public AudioMixer audioMixer;

    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Inicjalna synchronizacja (np. z PlayerPrefs)
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // Przykład inicjalizacji (jeśli potrzebne)
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    private void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", LinearToDecibel(value));
    }

    private void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", LinearToDecibel(value));
    }

    private void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", LinearToDecibel(value));
    }

    private float LinearToDecibel(float linear)
    {
        if (linear <= 0.0001f)
            return -80f; // całkowite wyciszenie
        return Mathf.Log10(linear) * 20f;
    }
}
