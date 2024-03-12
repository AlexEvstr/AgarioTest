using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject Mass;
    public Transform MassPosition;

    public float Percentage = 0.01f;


    public void ThrowMass()
    {
        if(transform.localScale.x < 1)
        {
            return;
        }
        // rotate 
        Vector2 Direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float Z_Rotation = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, Z_Rotation);

        // instantiate mass 
        GameObject b = Instantiate(Mass, MassPosition.position, Quaternion.identity);

        // apply force
        b.GetComponent<FoodForce>().ApplyForce = true;


        // add mass to the player
        ms.AddFood(b);


        // lose mass
        transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
    }

    public void Split()
    {
        if (transform.localScale.x <= 2)
        {
            return;
        }
        GameObject newGameObject = Instantiate(gameObject, transform.position, Quaternion.identity);

        newGameObject.GetComponent<SplitForce>().enabled = true;
        newGameObject.GetComponent<SplitForce>().SplitPlayer();

    }



    // Start is called before the first frame update

    PlayerEat mass_script;
    FoodSpawner ms;
    void Start()
    {
        mass_script = GetComponent<PlayerEat>();
        ms = FoodSpawner.ins;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(Percentage, Percentage, Percentage) * Time.deltaTime;
    }
}
