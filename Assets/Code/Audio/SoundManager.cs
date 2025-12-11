using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource steps;
    [SerializeField] private AudioSource vectorOpenSound;
    [SerializeField] private AudioSource eulerOpenSound;
    [SerializeField] private AudioSource doorOpen;
    public GameEnd gameEnd;
    void Start()
    {
        gameEnd.onDoorOpen += doorSound;
        audioSource.Play();
        audioSource.volume = 0.4f;
        audioSource.loop = true;
    }
    void doorSound()
    {
        doorOpen.Play();
    }
}
