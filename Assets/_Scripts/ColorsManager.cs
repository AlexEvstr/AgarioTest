using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour
{
    public Color[] colors;
    [SerializeField] private SpriteRenderer _player;

    public static ColorsManager ins;
    private bool PlayerColorWasSet = false;
    private Color currentPlayerColor;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }

    private void Start()
    {
        CheckColor();
    }

    private void CheckColor()
    {
        int color = PlayerPrefs.GetInt("ColorNumber", 0);
        if (color == 0)
        {
            _player.color = new Color(1, 0, 0);
            Debug.Log("0");
        }
        else if(color == 1)
        {
            _player.color = new Color(0, 0.1620431f, 1);
        }
        else if (color == 2)
        {
            _player.color = new Color(0.9468057f, 1, 0);
        }
        else if (color == 3)
        {
            _player.color = new Color(1, 0.5498703f, 0);
        }
        else if (color == 4)
        {
            _player.color = new Color(0.09360993f, 1, 0);
        }
        else if (color == 5)
        {
            _player.color = new Color(0, 0, 0);
        }
        else if (color == 6)
        {
            _player.color = new Color(0.5377358f, 0.5377358f, 0.5377358f);
        }
        else if (color == 7)
        {
            _player.color = new Color(1, 0, 0.7794147f);
        }
    }



    public void GetRandomColor(SpriteRenderer sprite)
    {
        int index = Random.Range(0, colors.Length);
        sprite.color = colors[index];
    }

    public void GetTargetColor(SpriteRenderer SourseColor, SpriteRenderer TargetColor)
    {
        TargetColor.color = SourseColor.color;
    }

    //public void GetPlayerColor(SpriteRenderer player)
    //{
    //    int index = Random.Range(0, colors.Length);
    //    if (PlayerColorWasSet == false)
    //    {
    //        player.color = colors[index];
    //        currentPlayerColor = player.color;
    //        PlayerColorWasSet = true;
    //        return;
    //    }
    //    player.color = currentPlayerColor;
    //}
}
