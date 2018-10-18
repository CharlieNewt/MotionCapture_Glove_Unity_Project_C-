using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

	public GameObject hand;

	// Update is called once per frame
	void Update () {
		Camera.main.transform.LookAt(hand.transform);
	}
}
