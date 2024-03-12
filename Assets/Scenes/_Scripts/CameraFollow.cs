using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Offset;
    private Vector3 Change;
    public float Speed = 0.4f;

    private void Update()
    {
        Vector3 position = GetCenter() + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, position, ref Change, Speed);
    }

    private Vector3 GetCenter()
    {
        FoodSpawner foodSpawner = FoodSpawner.ins;

        Bounds bounds = new Bounds(foodSpawner.Players[0].transform.position, Vector3.zero);

        for (int i = 0; i < foodSpawner.Players.Count; i++)
        {
            bounds.Encapsulate(foodSpawner.Players[i].transform.position);
        }

        return bounds.center;

    }
}
