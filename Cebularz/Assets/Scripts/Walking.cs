using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walking : MonoBehaviour {


    NavMeshAgent NavAgent;


    // Use this for initialization
    void Start () {

        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.updateUpAxis = false;
        NavAgent.updateRotation = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveTo(Vector3 location)
    {
        NavAgent.destination = location;
    }
}
