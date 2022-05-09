using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo P;
    public string userID;
    public float playTime;

    // Start is called before the first frame update
    void Start()
    {
        P = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInfo(string uID, float time)
    {
        userID = uID;
        playTime = time;
    }
}
