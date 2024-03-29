using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Drawing;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.transform.localScale.x <= 2)
            {
                return;
            }

            GameObject player = collision.gameObject;
            int CountToSpawn = (int)player.transform.localScale.x - 1;
            Debug.Log("Count to spawn(float): " + player.transform.localScale.x);
            Debug.Log("Count to spawn(int): " + CountToSpawn);
            player.transform.localScale /= player.transform.localScale.x;

            List<GameObject> instantiatedPlayers = new List<GameObject>();

            instantiatedPlayers.Add(player);


            for (int i = 0; i < CountToSpawn; i++)
            {
                GameObject newPlayer = (Instantiate(player, player.transform.position, Quaternion.identity));
                instantiatedPlayers.Add(newPlayer);
            }

            int circleDegree = 360;

            float rotation = circleDegree / CountToSpawn;
            int currentRotation = 0;

            for (int i = 0; i < instantiatedPlayers.Count; i++)
            {
                GameObject playerToRotate = instantiatedPlayers[i];
                currentRotation += 1;
                playerToRotate.transform.rotation = Quaternion.Euler(0, 0, rotation * currentRotation);

                playerToRotate.GetComponent<CircleCollider2D>().enabled = false;
                playerToRotate.GetComponent<PlayerMovement>().lockActions = true;

                playerToRotate.GetComponent<SplitForce>().Speed = playerToRotate.GetComponent<SplitForce>().DefaultSpeed;
                playerToRotate.GetComponent<SplitForce>().ApplySplitForce = true;

                playerToRotate.GetComponent<SplitForce>().enabled = true;
            }

            FoodSpawner.ins.MakeOnePlayer();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        ObstacleSpawner.ins.AddObstacle(gameObject);
    }

    private void OnDisable()
    {
        ObstacleSpawner.ins.RemoveObstacle(gameObject);
    }
}
