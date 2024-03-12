using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Offset;
    private Vector3 Change;
    public float Speed = 0.4f;
    private Camera camera;
    public float MaxZoom = 6.0f;
    public float MinZoom = 3.0f;

    public float ZoomController = 2.0f;

    public float ZoomSpeed = 1.0f;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 position = GetCenter() + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref Change, Speed);
    }

    private void Zoom()
    {
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, GetZoom(), ZoomSpeed);
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, MinZoom, MaxZoom);
    }

    private float GetZoom()
    {
        FoodSpawner foodSpawner = FoodSpawner.ins;

        Bounds bounds = new Bounds(foodSpawner.Players[0].transform.position, Vector3.zero);

        for (int i = 0; i < foodSpawner.Players.Count; i++)
        {
            bounds.Encapsulate(foodSpawner.Players[i].transform.position);
        }

        return (bounds.size.x + bounds.size.y) / ZoomController;
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
