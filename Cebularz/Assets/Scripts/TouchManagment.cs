using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManagment : MonoBehaviour {



    RaycastHit2D[] hits;
    Camera cam;
    List<GameObject> Units = new List<GameObject>();
    int toucheMode = 0;
    float timer = 0;
    bool OneFingerMoved = false;
    Vector3 LastFrameMovePosition;
    int fId;
    Vector2 TouchedPoint;

    [SerializeField]
    public LayerMask mask;
    public float MoveTriggerTime = 1;
    public float TouchMoveMargin = 0;
    public float fingerRadius = 1;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount == 1)
        {
  
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.CircleCast(cam.ScreenToWorldPoint(Input.GetTouch(0).position),fingerRadius, Vector3.forward,0,mask);
                if (hit.collider != null)
                {
                    if (!Units.Contains(hit.transform.gameObject))
                    {
                        Units.Add(hit.transform.gameObject);
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        Units.Remove(hit.transform.gameObject);
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    }
                }
                else
                {
                    TouchedPoint = Input.GetTouch(0).position;
                }
                fId = Input.GetTouch(0).fingerId;
                timer = 0;
                OneFingerMoved = false;
            }
            if (Input.GetTouch(0).fingerId == fId) {
                if (Vector2.Distance(TouchedPoint, Input.GetTouch(0).position) < TouchMoveMargin) timer += Time.deltaTime;
                else if (!OneFingerMoved)
                {
                    OneFingerMoved = true;
                    LastFrameMovePosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                }
                if (timer >= MoveTriggerTime) MoveOrder();
                else if (OneFingerMoved)
                {
                    cam.GetComponent<CameraMovement>().Move(cam.ScreenToWorldPoint(Input.GetTouch(0).position) - LastFrameMovePosition);
                    LastFrameMovePosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                }
            }
        }

        else if (Input.touchCount >= 2 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended))
        {
        
            hits = Physics2D.BoxCastAll(
                midpoint(Input.GetTouch(0).position,Input.GetTouch(1).position),
                boxSize(Input.GetTouch(0).position, Input.GetTouch(1).position),
                0,
                new Vector2(0,0),
                0,
                mask
                );



            foreach (RaycastHit2D h in hits)
                {
                    if (!Units.Contains(h.transform.gameObject))
                    {
                        Units.Add(h.transform.gameObject);
                        h.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        Units.Remove(h.transform.gameObject);
                        h.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    }
                }
           
        }

	}


    void MoveOrder()
    {
        print("MoveOrder");
        foreach(GameObject unit in Units)
        {
            Vector3 location = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            location.z = 0;
            unit.GetComponent<Walking>().MoveTo(location);
        }
    }


    private void OnGUI()
    {
        if (Input.touchCount >= 2)
        {
            Rect rect = new Rect(0,0, Mathf.Abs(Input.GetTouch(1).position.x - Input.GetTouch(0).position.x), Mathf.Abs(Input.GetTouch(1).position.y - Input.GetTouch(0).position.y));

            rect.center = new Vector2((Input.GetTouch(0).position.x + Input.GetTouch(1).position.x)/2 , (Screen.height-Input.GetTouch(0).position.y + Screen.height-Input.GetTouch(1).position.y)/2);

            GUI.Box(rect,"");
        }
    }

    Vector2 midpoint(Vector3 point1, Vector3 point2)
    {
        Vector3 worldPoint1 = cam.ScreenToWorldPoint(point1);
        Vector3 worldPoint2 = cam.ScreenToWorldPoint(point2);

        return new Vector2((worldPoint1.x+ worldPoint2.x)/2,(worldPoint1.y+ worldPoint2.y)/2);
    }

    Vector2 boxSize(Vector3 point1, Vector3 point2)
    {
        Vector3 worldPoint1 = cam.ScreenToWorldPoint(point1);
        Vector3 worldPoint2 = cam.ScreenToWorldPoint(point2);

        return new Vector2(Mathf.Abs(worldPoint2.x - worldPoint1.x) , Mathf.Abs(worldPoint2.y - worldPoint1.y));
    }

}
