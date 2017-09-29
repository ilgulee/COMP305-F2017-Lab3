using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;

    private Rigidbody2D rBody;
	// Use this for initialization
	void Start ()
	{
	    rBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
	    float horizMove = Input.GetAxis("Horizontal");
	    float verMove = Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(horizMove,verMove,0);
	    rBody.velocity = movement * speed;

	}
}
