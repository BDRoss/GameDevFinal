using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    GameObject armTransform;
    public GameObject Arm;
    public float reach = 1;
    private bool xory = false;

    // Start is called before the first frame update
    void Start()
    {
        //Arm = GameObject.Find("Arm");
        //armTransform = this.gameObject.transform.GetChild(0).gameObject;
        //Arm = this.gameObject.GetComponent<Chil>
        //Arm = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float sinTime = Mathf.Cos(Time.time);
        Vector3 scale = new Vector3(1, 1, 1);

        
        if (sinTime > 0)
        {
            //if (sinTime > 0.25)
            //{
                //scale = new Vector3(Mathf.Abs((sinTime * reach)), Arm.transform.localScale.y, Arm.transform.localScale.z);
                //Arm.transform.localScale = scale;
            //}
            //else
            //{
                scale = new Vector3(Mathf.Abs((sinTime * 1)), Arm.transform.localScale.y, Arm.transform.localScale.z);
                transform.localScale = scale;
            //}
        }
        /*print(sinTime);
        if (sinTime < 0)
        {
            scale = new Vector3(transform.localScale.x, Mathf.Abs((sinTime * 1.0f)), transform.localScale.z); //Magic numbers bad
            transform.localScale = scale;
        }
        else
        {
            scale = new Vector3(Mathf.Abs((sinTime * reach)), transform.localScale.y, transform.localScale.z);
            Arm.transform.localScale = scale;
        }
        if ((xory && transform.localScale.y == 2.454) || (!xory && Arm.transform.localScale.x == 1.25))
        {
            xory = !xory;
            //print(xory);
        }*/
    }
}
