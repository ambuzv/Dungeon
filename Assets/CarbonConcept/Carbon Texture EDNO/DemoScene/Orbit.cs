using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	
	public GameObject target;
	public Transform center;
	public Vector3 axis = Vector3.up;
	public Vector3 desiredPosition;
	public float radius = 0.05f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 50.0f;
	
	void Start () {

		center = target.transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 1.0f;
	}
	
	void Update () {
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	}
}