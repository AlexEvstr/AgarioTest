using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyEat : MonoBehaviour
{
    private GameObject _gameOver;

    private void Awake()
    {
        _gameOver = GameObject.FindGameObjectWithTag("GameOver");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            EatFood();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
                Destroy(collision.gameObject);
                if (GameObject.FindGameObjectWithTag("Player") != null)
                {
                    return;
                }
                else
                {
                    _gameOver.SetActive(true);
                }
                transform.localScale += collision.gameObject.transform.localScale;
            }
            else
            {
                collision.gameObject.transform.localScale += transform.localScale;
                Destroy(gameObject);
            }
        }
    }

    void EatFood()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
}
