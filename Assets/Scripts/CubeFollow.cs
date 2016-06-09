using UnityEngine;
using System.Collections;

public class CubeFollow : MonoBehaviour {

	public Transform target;
	public float moveSpeed = 3;
	public float rotationSpeed = 3;
	public Transform myTransform;

	public void Awake() {
		myTransform = transform; //cache transform data for easy access/preformance
	}

	public void Update () {
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime); //rotate to look at the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime; //move towards the player
	}
}