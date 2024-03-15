using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMovement : MonoBehaviour
{
    public float _speed = 5.0f;
    private float waitTime;           //время отдыха между передвижениями
    public float startWaitTime;
    bool wait = false;
    Vector3 moveTarget;

    private GameObject _gameOver;
    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameOver = GameObject.FindGameObjectWithTag("GameOver");
        waitTime = startWaitTime;
        transform.eulerAngles = new Vector2(0, 0);
    }

    void Update()
    {
        if (_player == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
                _player = GameObject.FindGameObjectWithTag("Player");
            else
            {
                _gameOver.SetActive(true);
            }
        }
        float newSpeed = _speed / transform.localScale.x;
        if (wait)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                wait = false;

                if (transform.localScale.x > _player.transform.localScale.x)
                {

                    moveTarget = _player.transform.position;
                }
                else
                {
                    moveTarget = new Vector2(Random.Range(-15, 15), Random.Range(-10, 10));
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, newSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveTarget) < 0.5f)
            {
                wait = true;
                waitTime = startWaitTime;
            }
        }
    }
}
