using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void RestartBtn()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
