using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The following class controls the trail renderers attached to the draw object. 
/// If a fingertip enters the collider, a new trail is instatiated. If the fingertip stays in the collider then
/// the trail will follow the finger. When the fingertip leaves the collider, the trail renderer is renamed so that it is not used again.
/// </summary>
public class ScreenWriting : MonoBehaviour {

    public GameObject thumbTrailPrefab, indexTrailPrefab, middleTrailPrefab, ringTrailPrefab, pinkyTrailPrefab;
    GameObject thumbTrail, indexTrail, middleTrail, ringTrail, pinkyTrail;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
        {
            thumbTrail = Instantiate(thumbTrailPrefab, other.transform.position, Quaternion.identity, transform);
            thumbTrail.name = "ThumbTrail";
        }

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            indexTrail = Instantiate(indexTrailPrefab, other.transform.position, Quaternion.identity, transform);
            indexTrail.name = "IndexTrail";
        }

        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            middleTrail = Instantiate(middleTrailPrefab, other.transform.position, Quaternion.identity, transform);
            middleTrail.name = "MiddleTrail";
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            ringTrail = Instantiate(ringTrailPrefab, other.transform.position, Quaternion.identity, transform);
            ringTrail.name = "RingTrail";
        }

        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            pinkyTrail = Instantiate(pinkyTrailPrefab, other.transform.position, Quaternion.identity, transform);
            pinkyTrail.name = "PinkyTrail";
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
        {
            transform.Find("ThumbTrail").GetComponent<TrailRenderer>().transform.position = other.transform.position;
        }

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            transform.Find("IndexTrail").GetComponent<TrailRenderer>().transform.position = other.transform.position;
        }

        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            transform.Find("MiddleTrail").GetComponent<TrailRenderer>().transform.position = other.transform.position;
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            transform.Find("RingTrail").GetComponent<TrailRenderer>().transform.position = other.transform.position;
        }

        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            transform.Find("PinkyTrail").GetComponent<TrailRenderer>().transform.position = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FingerTip" && other.name == "Thumb_FingerTip")
        {
            transform.Find("ThumbTrail").gameObject.name = "ThumbTrail (old)";
        }

        if (other.tag == "FingerTip" && other.name == "Index_FingerTip")
        {
            transform.Find("IndexTrail").gameObject.name = "IndexTrail (old)";
        }

        if (other.tag == "FingerTip" && other.name == "Middle_FingerTip")
        {
            transform.Find("MiddleTrail").gameObject.name = "MiddleTrail (old)";
        }

        if (other.tag == "FingerTip" && other.name == "Ring_FingerTip")
        {
            transform.Find("RingTrail").gameObject.name = "RingTrail (old)";
        }

        if (other.tag == "FingerTip" && other.name == "Pinky_FingerTip")
        {
            transform.Find("PinkyTrail").gameObject.name = "PinkyTrail (old)";
        }
    }
}
