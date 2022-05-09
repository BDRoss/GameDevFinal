using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    bool sentPopMessage = false;
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
                if (!sentPopMessage)
                {
                    Main.S.BalloonPop();
                    sentPopMessage = true;
                }
                Destroy(this.gameObject);
                break;
            default:
                print("Not the bee");
                break;
        }
    }

}
