using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDamage : MonoBehaviour {

    float timer = 0;
    GameObject enemy;

    [SerializeField]
    float damage = 1;
    [SerializeField]
    float speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy != null)
        {
            if (timer >= speed)
            {
                enemy.GetComponent<HealthLogic>().Damage(damage);
                timer = 0;
            }
            else timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy == null && collision.GetComponent<HealthLogic>() && !enemy.GetComponent<Tagger>().haveTag("Bad"))
        {
            enemy = collision.gameObject;
            timer = 0;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(enemy!=null && collision.gameObject == enemy)
        {
            enemy = null;
        }
    }

    }
