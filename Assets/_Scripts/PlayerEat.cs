using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
    public GameObject[] Food;



    public void UpdateFood()
    {
        Food = GameObject.FindGameObjectsWithTag("Food");
    }

    public void RemoveMass(GameObject MassObject)
    {
        List<GameObject> MassList = new List<GameObject>();

        for (int i = 0; i < Food.Length; i++)
        {
            MassList.Add(Food[i]);
        }
        MassList.Remove(MassObject);

        Food = MassList.ToArray();
    }
    public void AddMass(GameObject MassObject)
    {
        List<GameObject> MassList = new List<GameObject>();

        for (int i = 0; i < Food.Length; i++)
        {
            MassList.Add(Food[i]);
        }
        MassList.Add(MassObject);

        Food = MassList.ToArray();
    }


    public void CheckFood()
    {
        for (int i = 0; i < Food.Length; i++)
        {
            if (Food[i] == null)
            {
                UpdateFood();
                return;
            }

            Transform m = Food[i].transform;

            if (Vector2.Distance(transform.position, m.position) <= transform.localScale.x / 2)
            {
                RemoveMass(m.gameObject);
                // eat 
                EatFood();

                // destroy
                ms.RemoveFood(m.gameObject);
                Destroy(m.gameObject);
            }
        }
    }

    FoodSpawner ms;
    // Start is called before the first frame update
    void Start()
    {
        UpdateFood();
        InvokeRepeating("CheckFood", 0, 0.1f);

        ms = FoodSpawner.ins;
        //ms.Players.Add(gameObject);
    }

    void EatFood()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
}
