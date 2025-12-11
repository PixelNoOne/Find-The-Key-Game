using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameEnd : MonoBehaviour
{
    public PlayerInputSystem player;

    void Start()
    {
        player.WhenIOpenDoor += gameEnded;
    }
    public void gameEnded()
    {
        SceneManager.LoadScene("EndGameScene");
    }
}
