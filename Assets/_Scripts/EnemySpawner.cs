using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Color[] _colors;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int color = Random.Range(0, _colors.Length);
        GameObject newEnemy = Instantiate(_enemy, new Vector2(Random.Range(-15, 15), Random.Range(-10, 10)), Quaternion.identity);
        newEnemy.GetComponent<SpriteRenderer>().color = _colors[color];
    }
}