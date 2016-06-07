using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class CameraControl : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	public Transform target; //What we can see in the inspector. Let's us attach a prefab to follow.

	// Update is called once per frame
	void Update () 
	{
		if (target) //We don't want these calculations going on every frame if there's no target attached.
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position;
		}
	}
}