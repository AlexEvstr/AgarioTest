using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour
{
    public Color[] colors;

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

    

    public void GetRandomColor(SpriteRenderer sprite)
    {
        int index = Random.Range(0, colors.Length);
        sprite.color = colors[index];
    }

    public void GetTargetColor(SpriteRenderer SourseColor, SpriteRenderer TargetColor)
    {
        TargetColor.color = SourseColor.color;
    }

    public void GetPlayerColor(SpriteRenderer player)
    {
        int index = Random.Range(0, colors.Length);
        if (PlayerColorWasSet == false)
        {
            player.color = colors[index];
            currentPlayerColor = player.color;
            PlayerColorWasSet = true;
            return;
        }
        player.color = currentPlayerColor;
    }
}
