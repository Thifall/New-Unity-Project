using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    CameraRaycaster _rayCaster;
	// Use this for initialization
	void Start () {
		_rayCaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(_rayCaster.layerHit);
        }
    }
}
