using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    private Rigidbody2D rBody;

    public float camSize;
    public float camSizeLimit;
    public float increment;
    public float timeLerp;
    public float timeLerpValue;
    public bool shouldZoomIn = false;
    public bool shouldZoomOut = false;

	// Use this for initialization
	void Start ()
	{
	    rBody = this.GetComponent<Rigidbody2D>();
	}

    void Update()
    {

        float horizMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizMove, verMove, 0);
        rBody.velocity = movement * speed;
        if (shouldZoomIn)
        {
            ZoomIn();
        }
        else if (shouldZoomOut)
        {
            ZoomOut();
        }

        camSize = Camera.main.orthographicSize;
        timeLerpValue = timeLerp * Time.deltaTime;
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ZoomInTrigger")
        {
            shouldZoomIn = true;
        }
        else if(col.gameObject.tag == "ZoomOutTrigger")
        {
            shouldZoomOut = true;
        }
    }

    void ZoomOut()
    {
        if (Camera.main.orthographicSize < camSizeLimit)
        {
            Camera.main.orthographicSize =
                Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + increment,timeLerp*Time.deltaTime);
        }
        else if (Camera.main.orthographicSize > camSizeLimit)
        {
            shouldZoomOut = false;
        }
    }



    void ZoomIn()
    {
        if (Camera.main.orthographicSize > 5f)
        {
            Camera.main.orthographicSize =
                Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -increment, timeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize < 5f)
        {
            shouldZoomIn = false;
        }
    }
}
