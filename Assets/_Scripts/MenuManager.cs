using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settings;

    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void OpenSettings()
    {
        _settings.SetActive(true);
    }

    public void BackButton()
    {
        _settings.SetActive(false);
    }
}
