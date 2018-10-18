using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorMath;

public class ProjectileCannon : MonoBehaviour {

    public GameObject cannon;
    public GameObject lookAt;
    public bool inGunPosition;

    GameObject projectile;

    float timer;

	// Use this for initialization
	void Start () {
        projectile = Resources.Load("Projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        
        if (inGunPosition)
        {
            if (timer > 0.7f)
            {
                GameObject shot = Instantiate(projectile, cannon.transform.position, Quaternion.identity);
                Rigidbody rb = shot.GetComponent<Rigidbody>();

                rb.velocity = VectorFunc.Direction(cannon.transform.position, lookAt.transform.position) * 5f;
                timer = 0f;
            }
        }
	}
}
