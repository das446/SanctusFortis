using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using SanctusFortis;


public class MoveCamera : MonoBehaviour {

   
    public GameObject Target;
    public float maxX,minX, maxY, minY;
    public float WorldMinX=Mathf.NegativeInfinity, WorldMaxX=Mathf.Infinity, WorldMinY=Mathf.NegativeInfinity, WorldMaxY=Mathf.Infinity;
    public Vector3 Offset;

    public GameObject background1, background2;
    public float BgScrollSpeed;
    public float d=50;
    public float nextSwap=50;
	// Use this for initialization
	void Start () {
        GameObject levelCanvas = GameObject.Find("Level Canvas");
        if (levelCanvas == null) { return; }
        if (levelCanvas.activeInHierarchy==false) { levelCanvas.SetActive(true); }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Target == null) { Target = GameObject.FindObjectOfType<Player>().gameObject; }
        if (Target == null) { return; }
        
        float prevX = transform.position.x;
        Vector3 target = Target.transform.position + Offset;
        if (target.x - transform.position.x > maxX)
        {
            transform.position = new Vector3(target.x - maxX, transform.position.y, transform.position.z);
        }
        if (target.y - transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, target.y - maxY, transform.position.z);
        }
        if (transform.position.y - target.y > minY)
        {
            transform.position = new Vector3(transform.position.x, target.y + minY, transform.position.z);
        }
        if (transform.position.x - target.x > minX)
        {
            transform.position = new Vector3(target.x + minX, transform.position.y, transform.position.z);
        }
        //Adjust To World Bounds

        if (transform.position.x < WorldMinX) { transform.position = transform.position.setX(WorldMinX); }
        else if (transform.position.x > WorldMaxX) { transform.position = transform.position.setX(WorldMaxX); }
        if (transform.position.y < WorldMinY) { transform.position = transform.position.setY(WorldMinY); }
        else if (transform.position.y > WorldMaxY) { transform.position = transform.position.setY(WorldMaxY); }

        //MoveBackground(prevX);

    }

    private void MoveBackground(float prevX)
    {
        background1.transform.Translate(new Vector3(prevX - transform.position.x / BgScrollSpeed, 0, 0));
        background2.transform.Translate(new Vector3(prevX - transform.position.x / BgScrollSpeed, 0, 0));
        if (background2.transform.position.x < 0 && background1.transform.position.x < 0)
        {
            background1.transform.position = background2.transform.position + Vector3.right * d;
            GameObject temp = background1;
            background1 = background2;
            background2 = temp;
        }
        if (background2.transform.position.x > 0 && background1.transform.position.x > 0)
        {
            background2.transform.position = background1.transform.position + Vector3.left * d;
            GameObject temp = background1;
            background1 = background2;
            background2 = temp;
        }
    }
}
