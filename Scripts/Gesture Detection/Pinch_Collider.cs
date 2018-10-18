using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch_Collider : MonoBehaviour {

    public bool isPinching;
    public bool IsPinching
    {
        get { return isPinching; }
    }

    private void Start()
    {
        isPinching = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FingerTip" && other.name != "Thumb_FingerTip")
        {
            isPinching = true;
            Debug.Log("isPinching = " + isPinching);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FingerTip" && other.name != "Thumb_FingerTip")
        {
            isPinching = false;
            Debug.Log("isPinching = " + isPinching);

        }
    }
}
