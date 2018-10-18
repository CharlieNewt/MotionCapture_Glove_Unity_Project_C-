using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                gameObject.GetComponent<Hand_Symbols>().ClearPinchLists();
                Debug.Log("Pich points cleared");
                return;
            }
            gameObject.GetComponent<Hand_Symbols>().SyncPinch();
            Debug.Log("P pressed");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                gameObject.GetComponent<Hand_Symbols>().ClearGunLists();
                Debug.Log("Gun points cleared");
                return;
            }
            gameObject.GetComponent<Hand_Symbols>().SyncGun();
            Debug.Log("G pressed");
        }
	}
}
