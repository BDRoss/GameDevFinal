using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
 
    public GameObject Arm;
    public float reach = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float sinTime = Mathf.Cos(Time.time);
        Vector3 scale = new Vector3(1, 1, 1);

        
        if (sinTime > 0)
        {

                scale = new Vector3(Mathf.Abs((sinTime * 1)), Arm.transform.localScale.y, Arm.transform.localScale.z);
                transform.localScale = scale;
        }

    }
}
