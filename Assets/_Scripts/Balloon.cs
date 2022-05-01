using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
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
                Destroy(this.gameObject);
                // Scoring not yet implemented
                //Main.S.BalloonPop();
                break;
            default:
                print("Not the bee");
                break;
        }
    }

}
