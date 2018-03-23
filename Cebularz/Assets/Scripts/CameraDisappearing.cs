using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraDisappearing : MonoBehaviour {

    
    int direction = 1;
    float t = 1;
    List<GameObject> Children;

    [SerializeField]
    float speed = 5f;

    // Use this for initialization
    void Start () {
        Children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.tag == "Diasppear")
            {
                Children.Add(child.transform.gameObject);
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
            Tilemap h = child.GetComponent<Tilemap>();
            h.color = new Color(h.color.r, h.color.g, h.color.b, Mathf.Lerp(0, 1, x));
        }
    }
}
