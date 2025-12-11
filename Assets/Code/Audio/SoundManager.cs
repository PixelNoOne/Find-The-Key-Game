using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource steps;
    [SerializeField] private AudioSource vectorOpenSound;
    [SerializeField] private AudioSource eulerOpenSound;
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource cartonBoxOpen;
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private Move move;
    [SerializeField] private PlayerInputSystem player;
    bool iWalkingNow = false;
    void Start()
    {
        move.iWalking += WalkSound;
        move.iStay += WalkSoundStop;
        player.onCartonBoxOpen += OpenCartonBox;
        player.onVectorBoxOpen += VectorOpen;
        player.onEulerBoxOpen += EulerOpen;
        gameEnd.onDoorOpen += doorSound;
        audioSource.Play();
        audioSource.volume = 0.4f;
        audioSource.loop = true;
    }
    void doorSound()
    {
        doorOpen.Play();
    }
    void VectorOpen()
    {
        vectorOpenSound.Play();
    }
    void EulerOpen()
    {
        eulerOpenSound.Play();
    }
    void OpenCartonBox()
    {
        cartonBoxOpen.Play();
    }
    void WalkSound()
    {
        if (!iWalkingNow)
        {
            steps.Play();
            iWalkingNow = true;
        }
    }
    void WalkSoundStop()
    {
        if(iWalkingNow)
        {
            steps.Stop();
            iWalkingNow = false;
        }
    }
}
