using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPosition;
    
    private Transform camTrans;

    private PlayerController player;
    private GameObject myPlayer;
    private GameObject camera2ndPos;

    public bool shouldZoomIn = false;
    public bool shouldZoomOut = false;

    private int flag = 0;

    // Use this for initialization
    void Start ()
	{
	    camTrans = this.transform;

	    myPlayer = GameObject.Find("Player");
	    player = (PlayerController)myPlayer.GetComponent<PlayerController>();
        camera2ndPos = GameObject.FindGameObjectWithTag("CameraPos");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tpV3 = new Vector3();

	    if (player == null)
	    {
	        player = (PlayerController)myPlayer.GetComponent<PlayerController>();
        }
        
	    if (player.shouldZoomOut)
	    {
	        flag = 1;
	    }
        else if (player.shouldZoomIn)
	    {
	        flag = 2;
	    }

	    if (flag == 1)
	    {
	        tpV3.x = camera2ndPos.transform.position.x;
	        tpV3.y = camera2ndPos.transform.position.y;
	    }
	    else
	    {
	        tpV3.x = playerPosition.position.x;
	        tpV3.y = playerPosition.position.y;
	    }
        camTrans.position=new Vector3(tpV3.x, tpV3.y, camTrans.position.z);
		
	}

    public void SetZoomInOut(bool _zoomIn, bool _zoomOut)
    {
        this.shouldZoomIn = _zoomIn;
        this.shouldZoomOut = _zoomOut;
    }
}
