using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour {

    float timer = 0;
    GameObject enemy;

    [SerializeField]
    float damage = 1;
    [SerializeField]
    float speed = 2;
    [SerializeField]
    float precision = 2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            if (timer >= speed)
            {
                Shoot();
                timer = 0;
            }
            else timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy == null && collision.GetComponent<HealthLogic>() && enemy.GetComponent<Tagger>().haveTag("Bad"))
        {
            enemy = collision.gameObject;
            timer = 0;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemy != null && collision.gameObject == enemy)
        {
            enemy = null;
        }
    }

    void Shoot()
    {
        print("pif");
        float angl = Vector2.Angle(transform.position, enemy.transform.position);
        angl += Random.Range(-precision, precision);
        Vector2 direction = (Vector2)(Quaternion.Euler(0, 0, angl) * Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if(!hit)enemy.GetComponent<HealthLogic>().Damage(damage);
    }

}
