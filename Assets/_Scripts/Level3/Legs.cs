using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    public float reach = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sinTime = Mathf.Sin(Time.time);
        Vector3 scale = new Vector3(1, 1, 1);


        scale = new Vector3(Mathf.Abs((sinTime * reach)), transform.localScale.y, transform.localScale.z);
        transform.localScale = scale;
    }
}
