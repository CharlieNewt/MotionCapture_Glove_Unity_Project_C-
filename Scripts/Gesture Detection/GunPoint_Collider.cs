using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoint_Collider : MonoBehaviour {

    public bool isPoint;

    bool isMiddle = false;
    bool isIndex = false;
	// Update is called once per frame
	void Update () {
        if (isMiddle && isIndex)
        {
            isPoint = true;
            //Debug.Log("Point formed");
        }
        else
        {
            isPoint = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            isMiddle = true;
            //Debug.Log("Hello World");
        }

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            isIndex = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            isMiddle = false;
        }

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            isIndex = false;
        }
    }

}
