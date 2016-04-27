using UnityEngine;
using System.Collections;

public class GunLookAt : MonoBehaviour {
    Vector3 shootDirection;
    public SpriteRenderer gunSprite;
    public Transform shootPoint;
    public float shootPointOffset;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Camera cam = Camera.main;
        float camDis = cam.transform.position.y - transform.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            gunSprite.flipY = true;
            shootPoint.localPosition = new Vector2(shootPoint.localPosition.x, -shootPointOffset);
        }
        else
        {
            gunSprite.flipY = false;
            shootPoint.localPosition = new Vector2(shootPoint.localPosition.x, shootPointOffset);
        }
    }
}
