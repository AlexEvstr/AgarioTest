using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    #region instance 
    public static FoodSpawner ins;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    #endregion

    public GameObject Mass;
    public List<GameObject> Players = new List<GameObject>();
    public List<GameObject> CreatedMasses = new List<GameObject>();
    public int MaxMass = 50;
    public float Time_To_Instantiate = 0.5f;
    public Vector2 pos;


    private void Start()
    {
        StartCoroutine(CreateFood());
    }

    public IEnumerator CreateFood()
    {
        // wait for seconds
        yield return new WaitForSecondsRealtime(Time_To_Instantiate);

        if (CreatedMasses.Count <= MaxMass)
        {
            Vector2 Position = new Vector2(Random.Range(-pos.x, pos.x), Random.Range(-pos.y, pos.y));
            Position /= 2;

            GameObject m = Instantiate(Mass, Position, Quaternion.identity);

            AddFood(m);

        }

        StartCoroutine(CreateFood());


    }

    public void AddFood(GameObject m)
    {
        if (CreatedMasses.Contains(m) == false)
        {
            CreatedMasses.Add(m);
            for (int i = 0; i < Players.Count; i++)
            {
                PlayerEat pp = Players[i].GetComponent<PlayerEat>();
                pp.AddMass(m);
            }
        }
    }
    public void RemoveFood(GameObject m)
    {
        if (CreatedMasses.Contains(m) == true)
        {
            CreatedMasses.Remove(m);
            for (int i = 0; i < Players.Count; i++)
            {
                PlayerEat pp = Players[i].GetComponent<PlayerEat>();
                pp.RemoveMass(m);
            }
        }
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, pos);
    }
}
