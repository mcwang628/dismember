using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
