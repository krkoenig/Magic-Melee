using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	// Speed at which the projectile moves
	public float speed;
	public float maxDis;
    public Rigidbody2D rb;

	private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
        startPos = transform.position;
        rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Check if the projectile has moved its max distance
		if (Vector3.Distance (startPos, transform.position) >= maxDis) {
			Destroy (gameObject);
		}
	}
}
