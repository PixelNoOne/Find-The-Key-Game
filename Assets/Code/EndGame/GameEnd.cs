using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameEnd : MonoBehaviour
{
    public PlayerInputSystem player;
    public event Action onDoorOpen;

    void Start()
    {
        player.WhenIOpenDoor += gameEnded;
    }
    public void gameEnded()
    {
        onDoorOpen?.Invoke();
        StartCoroutine(WaitForEnd());
    }
    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndGameScene");
    }
}
