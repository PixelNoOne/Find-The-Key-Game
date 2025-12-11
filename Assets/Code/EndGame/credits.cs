using UnityEngine;
using UnityEngine.Video;

public class credit : MonoBehaviour
{
    public VideoPlayer clip;
    public AudioSource song;

    void Start()
    {
        clip.Play();
        song.Play();
        song.volume = 0.5f;
        clip.loopPointReached += end;
    }
    void end(VideoPlayer video)
    {
        clip.Stop();
        song.Stop();
        Application.Quit();
    }
}
