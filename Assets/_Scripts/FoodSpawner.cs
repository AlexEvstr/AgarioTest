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

    public int MaxPlayers = 6;
    public List<GameObject> CreatedMasses = new List<GameObject>();
    public int MaxMass = 200;
    public float Time_To_Instantiate = 0.25f;

    MapBorders mapBorders;

    private void Start()
    {
        mapBorders = MapBorders.ins;
        StartCoroutine(CreateFood());
    }

    public IEnumerator CreateFood()
    {
        // wait for seconds
        yield return new WaitForSecondsRealtime(Time_To_Instantiate);

        if (CreatedMasses.Count <= MaxMass)
        {
            Vector2 Position = new Vector2(Random.Range(-mapBorders.MapLimits.x, mapBorders.MapLimits.x), Random.Range(-mapBorders.MapLimits.y, mapBorders.MapLimits.y));
            Position /= 2;

            GameObject m = Instantiate(Mass, Position, Quaternion.identity);

            ColorsManager.ins.GetRandomColor(m.GetComponent<SpriteRenderer>());

            m.GetComponent<FoodSize>().MakeRandomSize();

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

    public void AddPlayer(GameObject b)
    {
        if (Players.Contains(b) == false)
        {
            Players.Add(b);
            b.SetActive(true);
        }
    }

    public void RemovePlayer(GameObject b)
    {
        if (Players.Contains(b) == true)
        {
            Players.Remove(b);
            b.SetActive(false);
        }
    }

    public void MakeOnePlayer()
    {
        StartCoroutine(CombineParts());
    }

    private IEnumerator CombineParts()
    {
        float size = 0;
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].GetComponent<CircleCollider2D>().enabled = false;
        }
        
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < Players.Count; i++)
        {
            size += Players[i].transform.localScale.x;
        }
        for (int i = 0; i < Players.Count; i++)
        {
            RemovePlayer(Players[i]);
        }
        Players[0].transform.localScale = new Vector3(size, size, size);
        Players[0].GetComponent<CircleCollider2D>().enabled = true;
        Players[1].SetActive(false);
    }
}