using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLogic : MonoBehaviour {

    [SerializeField]
    float health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    virtual public void Damage(float amount = 0)
    {
        print("Ouch - " + amount);
    }
}
