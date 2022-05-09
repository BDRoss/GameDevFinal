using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    //private GameObject otherGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        switch (otherGO.tag)
        {
            case "Bee":
                Destroy(otherGO);
                Main.S.BeeDied();
                break;
            default:
                print("Not the bee");
                break;
        }
    }
}
