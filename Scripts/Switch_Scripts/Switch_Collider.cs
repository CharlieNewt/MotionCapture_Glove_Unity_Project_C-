using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Collider : MonoBehaviour {

	public bool isTopCollider; //If this object is the top of a switch, this should be set the true in the editor.

	/// <summary>
    /// The following function checks if any of the trigger collisions are fingertips.
    /// If they are, then teh flick switch query is sent to the desk switch controller class.
    /// </summary>
    /// <param name="other">other refers to the other collider which is making contact with this objects collider.</param>

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "FingerTip")
		{
			if (transform.parent.name == "Switch_L")
			{
				transform.parent.parent.parent.GetComponent<Desk_Switch_Controller>().UseSwitchL(isTopCollider);
				//Debug.Log("Switch Contact with " + transform.parent.name + " is " + isTopCollider + "!");
				return;
			}
			else if (transform.parent.name == "Switch_M")
			{
				transform.parent.parent.parent.GetComponent<Desk_Switch_Controller>().UseSwitchM(isTopCollider);
				//Debug.Log("Switch Contact with " + transform.parent.name + " is " + isTopCollider + "!");
				return;
			}
			else if (transform.parent.name == "Switch_R")
			{
				transform.parent.parent.parent.GetComponent<Desk_Switch_Controller>().UseSwitchR(isTopCollider);
				//Debug.Log("Switch Contact with " + transform.parent.name + " is " + isTopCollider + "!");
				return;
			}
			//Debug.Log("Switch Contact with " + transform.parent.name + "!");
		}
	}
}
