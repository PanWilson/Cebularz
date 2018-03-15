using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisappearing : MonoBehaviour {

    
    SpriteRenderer sprite;
    int direction = 1;
    float t = 1;
    List<GameObject> Children;

    [SerializeField]
    float speed = 5f;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
        {
            if (child.tag == "Disappear")
            {
                Children.Add(child.gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (direction > 0 && t < 1) Transition(t += speed * Time.deltaTime);
        if (direction < 1 && t > 0) Transition(t -= speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        direction = 0;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        direction = 1;
    }

    void Transition(float x)
    {
        foreach (GameObject child in Children)
        {
            child.GetComponent<SpriteRenderer>().color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(0, 1, x));
        }
    }
}
