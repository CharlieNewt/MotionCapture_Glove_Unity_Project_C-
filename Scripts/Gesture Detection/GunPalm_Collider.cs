using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPalm_Collider : MonoBehaviour {

    public bool isPalm;

    bool isPinky = false; 
    bool isRing = false;

    private void Update()
    {
        if (isPinky && isRing)
        {
            //Debug.Log("Palm in place");
            isPalm = true;
        }
        else
        {
            isPalm = false;
        }
        //Debug.Log("Hello World");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            isPinky = true;
            //Debug.Log("Hello World");
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            isRing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            isPinky = false;
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            isRing = false;
        }
    }


}
