using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    #region Instance
    public static ObstacleSpawner ins;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    #endregion

    public GameObject Obstacle;
    public int MaxObstacles = 20;
    public List<GameObject> Obstacles = new List<GameObject>();
    private MapBorders mapBorders;

    private void Start()
    {
        mapBorders = MapBorders.ins;
        InvokeRepeating("InstantiateObstacle", 1, 1);
    }

    private void InstantiateObstacle()
    {
        if (Obstacles.Count >= MaxObstacles)
        {
            return;
        }

        Vector2 newPosition = new Vector2
            (Random.Range(mapBorders.MapLimits.x / 2 * -1, mapBorders.MapLimits.x / 2),
             Random.Range(mapBorders.MapLimits.y / 2 * -1, mapBorders.MapLimits.y / 2));

        GameObject newObstacle = Instantiate(Obstacle, newPosition, Quaternion.identity);
    }

    public void AddObstacle(GameObject obstacle)
    {
        Obstacles.Add(obstacle);
    }

    public void RemoveObstacle(GameObject obstacle)
    {
        Obstacles.Remove(obstacle);
    }
}
