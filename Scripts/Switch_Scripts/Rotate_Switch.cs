using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Switch : MonoBehaviour {

	Transform from, to;
	float maxRotation, minRotation;
	float t;

	float timer;
	bool isSwitchUp;
	public bool IsSwitchUp
	{
		set { isSwitchUp = value; }
	}
	// Use this for initialization
	void Start () {
		maxRotation = 25;
		minRotation = -25;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Rotate switch up
		if (isSwitchUp)
		{
			if (t < 1)
			{
				t += (4 * Time.deltaTime);				
			}
			else {
				t = 1;
			}
		}

		//Rotate switch down
		else
		{
			if (t > 0)
			{
				t -= (4 * Time.deltaTime);
				
			}
			else {
				t = 0;
			}
		}
		
		transform.localRotation = Quaternion.Lerp(Quaternion.Euler(25f, 0f, 0f), Quaternion.Euler(-25f, 0f, 0f), t);
		Changetext();
	}

	void Changetext()
	{
		if (isSwitchUp)
			transform.parent.Find("On_Off_Txt").GetComponent<TMPro.TextMeshPro>().SetText("On");
		else 
			transform.parent.Find("On_Off_Txt").GetComponent<TMPro.TextMeshPro>().SetText("Off");
	}

}
