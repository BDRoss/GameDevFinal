using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeathZone : DeathZone
{
    public float reachY = 5;
    public float reachX = 10;


    private bool xory = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //if(Mathf.Sin(Time.time) == 0)
        //{
        //    xory = !xory;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float sinTime = Mathf.Sin(Time.time);
        Vector3 scale = new Vector3(1, 1, 1);
        // Original logic just in case
        //if (Mathf.Abs(sinTime) < 0.01f)
        /*print(transform.localScale.x);
        if (xory)
        {
            scale = new Vector3(transform.localScale.x, Mathf.Abs((sinTime * reach)) + 2.454f, transform.localScale.z); //Magic numbers bad
        }
        else
        {
            scale = new Vector3(Mathf.Abs((sinTime * reach)) + 2.454f, transform.localScale.y, transform.localScale.z);
        }
        if ((xory && transform.localScale.y == 2.454) || (!xory && transform.localScale.x == 2.454))
        {
            xory = !xory;
            print(xory);
        }*/


        //print(transform.localScale.x);
        if (sinTime > 0)
        {
            scale = new Vector3(transform.localScale.x, Mathf.Abs((sinTime * reachY)) + 2.454f, transform.localScale.z); //Magic numbers bad
        }
        else
        {
            scale = new Vector3(Mathf.Abs((sinTime * reachX)) + 2.454f, transform.localScale.y, transform.localScale.z);
        }
        if ((xory && transform.localScale.y == 2.454) || (!xory && transform.localScale.x == 2.454))
        {
            xory = !xory;
            //print(xory);
        }

        //Vector3 scale = new Vector3(transform.localScale.x, Mathf.Abs(Mathf.Sin(Time.time) * reach) + 0.5f, transform.localScale.z);
        //transform.localScale.y = Mathf.Sin(Time.time);
        transform.localScale = scale;


    }
}
