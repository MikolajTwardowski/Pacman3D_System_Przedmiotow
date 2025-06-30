using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Mixer")]
    public AudioMixer audioMixer;

   [Header("Output Groups")]
    public AudioMixerGroup masterGroup;
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;

    [Header("Defaults")]
    [SerializeField] private float defaultVolume = 1f;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 15f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayOneShot(AudioClip clip, Vector3 position)
    {
        if (clip == null) return;

        GameObject soundObject = new GameObject("OneShotAudio_" + clip.name);
        soundObject.transform.position = position;

        AudioSource source = soundObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = defaultVolume;
        source.spatialBlend = 1f;
        source.minDistance = minDistance;
        source.maxDistance = maxDistance;
        source.rolloffMode = AudioRolloffMode.Linear;
        source.outputAudioMixerGroup = sfxGroup;

        source.Play();
        Destroy(soundObject, clip.length + 0.1f);
    }

    public void SetVolume(string parameterName, float volumeDB)
    {
        audioMixer.SetFloat(parameterName, volumeDB);
    }
}