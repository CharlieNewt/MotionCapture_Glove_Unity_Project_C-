using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKill : MonoBehaviour {

    float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > 1f)
        { Destroy(gameObject); }
	}
}
