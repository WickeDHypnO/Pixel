using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    Vector3 shootDirection;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        Ray2D ray = new Ray2D(shootDirection, Vector3.down);
        RaycastHit2D hit;
        if (Input.GetMouseButton(0))
        {            
            if (Physics2D.Raycast(transform.position,shootDirection))
            {
                hit = Physics2D.Raycast(transform.position, shootDirection);
                isEnemy(hit.collider);
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
                //Debug.Log(hit);
            }

        }
    }

    void isEnemy(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" && col.GetComponent<Renderer>())
        {
            col.GetComponent<Renderer>().material.color = Color.red;

        }
    }
}
