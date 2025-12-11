using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource steps;
    [SerializeField] private AudioSource vectorOpenSound;
    [SerializeField] private AudioSource eulerOpenSound;
    void Start()
    {
        audioSource.Play();
        audioSource.volume = 0.4f;
        audioSource.loop = true;
    }
}
