using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walking : MonoBehaviour {


    NavMeshAgent NavAgent;

    [SerializeField]
    float speed = 3.5f;
    // Use this for initialization
    void Start () {

        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.updateUpAxis = false;
        NavAgent.updateRotation = false;
        NavAgent.speed = speed;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveTo(Vector3 location)
    {
        NavAgent.destination = location;
    }
}
