using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
        audioSource.volume = 0.4f;
        audioSource.loop = true;
    }
}
