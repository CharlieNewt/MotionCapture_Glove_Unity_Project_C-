using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorMath;

/// <summary>
/// This function is the basis for what happens when a pinch is occuring inside a collider, specifically the collider that
/// the sript is attached to.
/// </summary>
public class Basic_Box_Collision : MonoBehaviour {

    bool isPinchBox;
    public bool IsPinchBox
    {
        get { return isPinchBox; }
    }
    bool isPinching;
    bool isThumb, isIndex, isMiddle, isRing, isPinky;

    bool hasStarted;

    bool isLastPinchFrame;
    Vector3 lastPosition;

    GameObject pinchBox;

	// Use this for initialization
	void Start () {
        //pinchBox = GameObject.FindGameObjectWithTag("Pinch_Box");

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //pinchBox = GameObject.FindGameObjectWithTag("Pinch_Box");
        if (pinchBox != null)
        {
            isPinching = pinchBox.GetComponent<Pinch_Collider>().isPinching;
        }
        //Debug.Log(isPinching);
        PinchControl();
        //Debug.Log(pinchBox.GetComponent<Pinch_Collider>().isPinching);
	}

    //Collider enter check for each fingertip, as well as a check to see if the pinch box object is inside.
    // the pinchbox is inside and the user is pinching then the gameobject gravity should be turned off.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
		{
            isThumb = true;
		}

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            isIndex = true;
        }

        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            isMiddle = true;
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            isRing = true;
        }

        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            isPinky = true;
        }

        if (other.tag == "Pinch_Box")
        {
            isPinchBox = true;
            pinchBox = other.gameObject;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            //Debug.Log("PinchBox in");
        }

	}
    //Collider exit check for each fingertip, as well as a check to see if the pinch box object is inside.
    //If the pinchbox stops pinchinbg or leaves the collision box, the the objects gravity is returned.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
        {
            isThumb = true;
        }

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            isIndex = true;
        }

        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            isMiddle = true;
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            isRing = true;
        }

        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            isPinky = true;
        }

        if (other.tag == "Pinch_Box")
        {
            isPinchBox = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            //Debug.Log("PinchBox out");

        }
    }

    /// <summary>
    /// This function controls the behaviour of this object if the pinch object is inside it and the user is pinching.
    /// </summary>
    void PinchControl()
    {

        // If the pinchBox is inside the object and the user is pinching
        if (isPinchBox && (pinchBox.GetComponent<Pinch_Collider>().isPinching))
        {
            //Turn off the gravity of the object so that it can be carried.
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            Vector3 relativeBoxPosition = new Vector3(0f, 0f, 0f); //Used to maintain the displacement in position betweren the pinch and the object.

            //On the first pinched frame the relative position is set.
            if (!hasStarted)
            {
                relativeBoxPosition = transform.position - pinchBox.transform.position;
                hasStarted = true;
            }

            //The psotion of the object is then set in accordance to the pinch position and the relative position.
            transform.position = pinchBox.transform.position + relativeBoxPosition;
            isLastPinchFrame = true;
        }

        //When the user is not pinching the reletive position is readied to be changed when the next pinch gesture occurs.
        else if (pinchBox != null && !pinchBox.GetComponent<Pinch_Collider>())
        {
            Debug.Log("Cannot find Pinch Collider script");
            hasStarted = false;
        }

        else
        {
            //Turn the gravity back on when the object is not being pinched
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (isLastPinchFrame)
            {
                //gameObject.GetComponent<Rigidbody>().velocity = VectorFunc.Direction(lastPosition, transform.position) * VectorFunc.Distance(lastPosition, transform.position) * 1000;
                isLastPinchFrame = false;
            }
            hasStarted = false;

        }
        lastPosition = transform.position;

    }

}
