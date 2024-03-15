using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject Mass;
    public Transform MassPosition;

    public float Percentage = 0.01f;

    public float SplitMass = 2.0f;


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

        ColorsManager.ins.GetTargetColor(GetComponent<SpriteRenderer>(), b.GetComponent<SpriteRenderer>());

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

        transform.localScale /= SplitMass;
        StartCoroutine(SplitAndCombine());
        
    }

    private IEnumerator SplitAndCombine()
    {
        float size = 0;
        GameObject newGameObject = Instantiate(gameObject, transform.position, Quaternion.identity);

        newGameObject.GetComponent<SplitForce>().enabled = true;
        newGameObject.GetComponent<SplitForce>().SplitPlayer();

        yield return new WaitForSeconds(10.0f);
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < FoodSpawner.ins.Players.Count; i++)
        {
            size += FoodSpawner.ins.Players[i].transform.localScale.x;
        }
        for (int i = 1; i < FoodSpawner.ins.Players.Count; i++)
        {
            FoodSpawner.ins.RemovePlayer(FoodSpawner.ins.Players[i]);
        }
        
        Debug.Log(size);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale = new Vector3(size, size, size);
        GetComponent<CircleCollider2D>().enabled = true;
    }



    // Start is called before the first frame update

    PlayerEat mass_script;
    FoodSpawner ms;
    void Start()
    {
        mass_script = GetComponent<PlayerEat>();
        ms = FoodSpawner.ins;
        //ColorsManager.ins.GetPlayerColor(GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 1)
        {
            return;
        }
        transform.localScale -= new Vector3(Percentage, Percentage, Percentage) * Time.deltaTime;
    }
}
