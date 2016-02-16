using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	private Vector3 target;
	private Vector3 targetVector;
	private Vector3 bisector;
	private Rigidbody rb;
	private float dot;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

		//float translation = Time.deltaTime;
		//transform.Translate (new Vector3 (0, 0, translation));

		if (Input.GetButtonDown("Fire1")) {
			Camera c = Camera.main;
			Vector3 p = Input.mousePosition;
			Ray r = c.ScreenPointToRay (p);
			rb.angularDrag = 0;

			float distance = 0; 
			Vector3 worldP = Vector3.zero;
			// if the ray hits the plane...
			if (groundPlane.Raycast(r, out distance)){
				// get the hit point:
				worldP = r.GetPoint(distance);
			}

			target = worldP;
			targetVector = (target - transform.position).normalized;
			bisector = (transform.forward + targetVector).normalized;
			//dot = Vector3.Dot (transform.forward, target);
		}

		TurnToFace (target);

		// move if far away enough
		// TODO: actually accelerate
		if (Vector3.Distance (transform.position, target) > 0.5) {
			transform.position += transform.forward * Time.deltaTime;
		}
	}

	void TurnToFace (Vector3 target) {
		if (target == Vector3.zero) {
			return;
		}
			targetVector = (target - transform.position).normalized;

		Debug.DrawRay (transform.position, target - transform.position);
		Debug.DrawRay (transform.position, bisector * 10);
		Debug.DrawRay (transform.position, transform.forward * 10);
		Debug.DrawRay (transform.position, targetVector * 10);

		if (Mathf.Abs (Vector3.Dot (transform.forward, targetVector) - 1) < 0.01 && rb.angularVelocity.magnitude < 0.01) {
			rb.angularDrag = 100;
			// transform.LookAt (target);
			//rb.angularVelocity = Vector3.zero;
		}

		// turn ship to face the target
		// TODO: actually turn
		//transform.LookAt(target);
		//if (Vector3.Dot (transform.forward, (target - transform.position).Normalize()) > 0) {
		if (Vector3.Dot(Vector3.Cross (transform.forward, bisector), Vector3.up) > 0) {
			rb.AddRelativeTorque (Vector3.up);
		} else {
			rb.AddRelativeTorque (Vector3.up * -1);
		}
	}
}

