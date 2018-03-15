using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 shift)
    {
        shift.z = 0;
        shift *= -1;
        gameObject.transform.position += shift;
    }
}
