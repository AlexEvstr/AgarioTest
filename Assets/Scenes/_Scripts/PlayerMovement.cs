using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5.0f;
    Actions actions;

    private void Start()
    {
        actions = GetComponent<Actions>();
    }

    private void Update()
    {
        float newSpeed = _speed / transform.localScale.x;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, direction, newSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            actions.ThrowMass();
        }
    }
}
