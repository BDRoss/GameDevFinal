using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //bool sentDeathMessage = false;
    //private GameObject otherGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                //sentDeathMessage = false; // Reset Death signal at fixed intervals - just need to prevent constant signalling
    }

    private void FixedUpdate()
    {

    }

    /*protected void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        switch (otherGO.tag)
        {
            case "Bee":
                //if (!sentDeathMessage)
                //{
                Main.S.BeeDied();
                //sentDeathMessage = true;
               // }
                Destroy(otherGO);
                break;
            default:
                print("Not the bee");
                break;
        }
    }*/

    protected void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Untagged") print(other.tag);

        switch (other.gameObject.tag)
        {
            case "Bee":
                //if (!sentDeathMessage)
                //{
                //if (!other)
                //{
                //    return;
                //}
                print("No destruction?");
                Destroy(other.gameObject);
                Main.S.BeeDied();
                //sentDeathMessage = true;
                // }
                break;

            default:
                //print("Not the bee");
                break;
        }
    }

}
