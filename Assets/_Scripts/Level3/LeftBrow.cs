using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBrow : MonoBehaviour
{
    public float reach = 1;
    //Scale Y for some reason
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sinTime = Mathf.Sin(Time.time);
        Vector3 scale = new Vector3(1, 1, 1);
        if (sinTime > 0)
        {
            scale = new Vector3(transform.localScale.x, Mathf.Abs((sinTime * reach)), transform.localScale.z);
        }
        else scale = new Vector3(transform.localScale.x, 0f, transform.localScale.z);
        transform.localScale = scale;
    }
}
