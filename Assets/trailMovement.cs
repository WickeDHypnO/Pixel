using UnityEngine;
using System.Collections;

public class trailMovement : MonoBehaviour {
    public float speed;
    public float destroyTime = 0.1f;
    float timer;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * speed;
        Color temp = new Color(1, 1, 1, 1 - timer);
        GetComponent<Renderer>().material.SetColor("_TintColor", temp);
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
