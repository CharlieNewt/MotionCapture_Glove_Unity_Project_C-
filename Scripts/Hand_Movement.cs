using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Movement : MonoBehaviour {

	public GameObject camera_Top;
    Vector3 cameraOriginalPosition;

    Vector3 handOriginalPosition;

	float forward;
	float sideways;
	float up;

	float speed;

	bool isMouse;
	// Use this for initialization
	void Start () {
		speed = 0.01f;
		if (isMouse)
		{
			forward = Input.GetAxis("Mouse Y");
			sideways = Input.GetAxis("Mouse X");
		}
		else {
			forward = Input.GetAxis("Vertical");
			sideways = Input.GetAxis("Horizontal");
		}

        cameraOriginalPosition = camera_Top.transform.position;
        handOriginalPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (isMouse)
				isMouse = false;
			else
				isMouse = true;
		}
		
		if (isMouse)
		{
			forward = Input.GetAxis("Mouse Y");
			sideways = Input.GetAxis("Mouse X");
		}
		else {
			forward = Input.GetAxis("Vertical");
			sideways = Input.GetAxis("Horizontal");
		}

		

		if (Input.GetKey(KeyCode.LeftShift))
		{
			up = 1;
		}
		else if (Input.GetKey(KeyCode.LeftControl))
		{
			up = -1;
		}
		else
		{
			up = 0;
		}

		transform.position += new Vector3(-sideways, up, -forward) * speed;
		camera_Top.transform.position += new Vector3(-sideways, up * 0.5f, -forward * 0.5f) * speed;

		MovementText();
        //Debug.Log(forward);
        //Debug.Log(sideways);
        if (Input.GetKeyDown(KeyCode.Home))
        {
            ResetPosition();
        }
	}

	void MovementText()
	{
		if (GameObject.Find("Canvas") != null)
		{
			if (isMouse)
			{
				GameObject.Find("Canvas").transform.Find("MovementModeTxt").Find("MovementModeVariableTxt").GetComponent<TMPro.TextMeshProUGUI>().SetText("Mouse");
			}
			else {
				GameObject.Find("Canvas").transform.Find("MovementModeTxt").Find("MovementModeVariableTxt").GetComponent<TMPro.TextMeshProUGUI>().SetText("WASD");
			}
		}
	}

    void ResetPosition()
    {
        transform.position = handOriginalPosition;
        camera_Top.transform.position = cameraOriginalPosition;
    }
}
