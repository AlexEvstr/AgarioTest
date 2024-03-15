using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private GameObject _on;
    [SerializeField] private GameObject _off;

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("sound", 1);

        if (volume == 1) TurnOn();

        else TurnOff();
    }

    public void TurnOff()
    {
        _on.SetActive(false);
        _off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("sound", AudioListener.volume);
    }

    public void TurnOn()
    {
        _off.SetActive(false);
        _on.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("sound", AudioListener.volume);
    }
}
