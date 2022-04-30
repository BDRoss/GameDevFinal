using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float m_speed = 2;

    Vector3 mousePos;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        rb.maxDepenetrationVelocity = Mathf.Infinity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y -= 0.5f; // Trying to move mouse cursor to center of bee - model higher than center of object
        //transform.position = Vector3.Lerp(transform.position, mousePos, 1);
        //rb.MovePosition(mousePos);
        //rb.MovePosition(transform.position + mousePos * Time.deltaTime * m_speed);
        //rb.velocity = new Vector3(0,0,0);
        //rb.position = Vector3.Lerp(transform.position, mousePos, 1);
        rb.velocity = (mousePos - transform.position) * m_speed;
    }
}
