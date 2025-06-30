using UnityEngine;

public class PlayerFootstepAudio : MonoBehaviour
{
    public float velocityThreshold = 0.1f; // Minimalna prędkość, żeby uznać za ruch
    [SerializeField]private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // Upewnij się, że dźwięk się zapętla
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;

        if (speed > velocityThreshold)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop(); // Gwałtowne przerwanie
        }
    }
}