using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CameraController : NetworkBehaviour {

    private GameObject mainCam;

	// Use this for initialization
	void Start () {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;

        Vector3 camPos = mainCam.transform.position;
        camPos.x = transform.position.x;
        camPos.y = transform.position.y;
        mainCam.transform.position = camPos;
	}
}
