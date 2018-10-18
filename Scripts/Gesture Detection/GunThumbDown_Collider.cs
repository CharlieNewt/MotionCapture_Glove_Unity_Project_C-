using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunThumbDown_Collider : MonoBehaviour {

    public bool isThumbDown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
        {
            isThumbDown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
        {
            isThumbDown = false;
        }
    }
}
