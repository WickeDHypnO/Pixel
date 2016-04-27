using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    Vector3 shootDirection;
    public float shootDelay = 0.1f;
    float timer;
    RaycastHit2D hit;
    public Transform trailPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        if (Input.GetMouseButton(0))
        {
            if (timer > shootDelay)
            {
                if (Physics2D.Raycast(transform.position, shootDirection))
                {
                    hit = Physics2D.Raycast(transform.position, shootDirection);
                  
                    Debug.DrawLine(transform.position, hit.point, Color.cyan);
                    Debug.Log(hit.distance);
                    Trail(hit.distance);
                    //Debug.Log(hit);
                }
                timer = 0;
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

    void Trail(float distance)
    {
        trailPrefab.gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(distance + 0.2f, 0, 0));
        if(distance < 21f)
        {
            isEnemy(hit.collider);
        }
        Instantiate(trailPrefab, transform.position, transform.parent.rotation);
    }
}
