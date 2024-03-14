using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSize : MonoBehaviour
{
    private float MinSize = 0.4f;
    private float MaxSize = 1.0f;

    public void MakeRandomSize()
    {
        float randomSize = Random.Range(MinSize, MaxSize);
        randomSize *= transform.localScale.x;
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
}
