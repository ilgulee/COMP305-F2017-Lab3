using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPosition;

    private Transform camTrans;

	// Use this for initialization
	void Start ()
	{
	    camTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        camTrans.position=new Vector3(playerPosition.position.x,playerPosition.position.y,camTrans.position.z);
		
	}
}
