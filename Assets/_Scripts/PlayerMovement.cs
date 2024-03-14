using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5.0f;
    Actions actions;


    public bool lockActions = false;
    MapBorders mapBorders;

    private void Start()
    {
        actions = GetComponent<Actions>();
    }

    private void Update()
    {
        mapBorders = MapBorders.ins;
        float newSpeed = _speed / transform.localScale.x;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction.x = Mathf.Clamp(direction.x, mapBorders.MapLimits.x * -1 / 2, mapBorders.MapLimits.x / 2);
        direction.y = Mathf.Clamp(direction.y, mapBorders.MapLimits.y * -1 / 2, mapBorders.MapLimits.y / 2);
        transform.position = Vector2.MoveTowards(transform.position, direction, newSpeed * Time.deltaTime);

        if (lockActions)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            actions.ThrowMass();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FoodSpawner.ins.Players.Count >= FoodSpawner.ins.MaxPlayers)
            {
                return;
            }
            actions.Split();
        }
    }

    private void OnEnable()
    {
        if (FoodSpawner.ins.Players.Count >= FoodSpawner.ins.MaxPlayers)
        {
            Destroy(gameObject);
            return;
        }
        FoodSpawner.ins.AddPlayer(gameObject);
    }

    private void OnDisable()
    {
        FoodSpawner.ins.RemovePlayer(gameObject);
    }
}
