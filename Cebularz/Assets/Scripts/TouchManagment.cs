using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManagment : MonoBehaviour {



    public LayerMask mask;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.touchCount >= 2)
        {
            RaycastHit2D[] hits;
            ContactFilter2D Filter = new ContactFilter2D();
            
            hits = Physics2D.BoxCastAll(
                Input.GetTouch(0).position,
                new Vector2(Mathf.Abs(Input.GetTouch(1).position.x-Input.GetTouch(0).position.x)/2, Mathf.Abs(Input.GetTouch(1).position.y - Input.GetTouch(0).position.y)/2),
                0,
                new Vector2(0,0),
                Filter,
                hits
                );
        }

	}

}
