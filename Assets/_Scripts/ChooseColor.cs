using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseColor : MonoBehaviour
{
    [SerializeField] private int _colorNumber;

    public void UseColor()
    {
        PlayerPrefs.SetInt("ColorNumber", _colorNumber);
    }
}
