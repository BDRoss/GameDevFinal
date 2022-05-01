using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeathZone : DeathZone
{
    public float reach = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = new Vector3(transform.localScale.x, Mathf.Abs(Mathf.Cos(Time.time) * reach) + 0.5f, transform.localScale.z);
        //transform.localScale.y = Mathf.Sin(Time.time);
        transform.localScale = scale;


    }
}
