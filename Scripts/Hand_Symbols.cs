using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorMath;

public class Hand_Symbols : MonoBehaviour {

    GameObject pinchCBP, gunPalmCBP, gunPointCBP, gunThumbDownCBP; //(Cube Base Pivot)
    public GameObject thumbTip, indexTip, middleTip, ringTip, pinkyTip; //Tips of the fingers
    public GameObject hand_base;
    public GameObject thumbTipColl, indexTipColl; //Collider objects

    GameObject pinchBox, gunPalm, gunPoint, gunThumbDown;

    List<float> pinchDistances = new List<float>();
    List<Vector3> pinchDirections = new List<Vector3>();


    List <float> gunPalmDistances = new List<float>();
    List<Vector3> gunPalmDirections = new List<Vector3>();


    List<float> gunPointDistances = new List<float>();
    List<Vector3> gunPointDirections = new List<Vector3>();

    List<Vector3> thumbDownPositions = new List<Vector3>();


	// Use this for initialization
	void Start () {
        pinchCBP = Resources.Load("PinchBox") as GameObject;
        gunPalmCBP = Resources.Load("GunBoxPalm") as GameObject;
        gunPointCBP = Resources.Load("GunBoxPoint") as GameObject;
        gunThumbDownCBP = Resources.Load("GunBoxThumbDown") as GameObject;
        pinchBox = Instantiate(pinchCBP, thumbTip.transform);

        gunPalm = Instantiate(gunPalmCBP, hand_base.transform);
        gunPoint = Instantiate(gunPointCBP, hand_base.transform);
        gunThumbDown = Instantiate(gunThumbDownCBP, hand_base.transform);

        gunPalm.name = "GunBoxPalm";
        gunPoint.name = "GunBoxPoint";
        gunThumbDown.name = "GunBoxThumbDown";
    }

    private void Update()
    {
        GunDetection();   
    }

    /// <summary>
    /// This function gets the average direction and distance between the thumb tip and the index tip,
    /// then uses the averages to position the pinchBox collider.
    /// </summary>
    public void SyncPinch()
    {
        Vector3 thumbTipPos = thumbTip.transform.position - hand_base.transform.position;
        Vector3 indexTipPos = indexTip.transform.position - hand_base.transform.position;

        Vector3 direction = VectorFunc.Direction(thumbTipPos, indexTipPos);
        float distance = VectorFunc.Distance(thumbTipPos, indexTipPos);
        Debug.Log("Distance between thumb and index tip = " + distance);

        pinchDirections.Add(thumbTip.transform.InverseTransformDirection(direction));
        pinchDistances.Add(distance);

        float avDistance = FloatAverage(pinchDistances);
        Vector3 avDirection = Vector3Average(pinchDirections);

        
        pinchBox.transform.LookAt(thumbTip.transform.TransformDirection(avDirection));
        pinchBox.transform.localScale = new Vector3(
            pinchBox.transform.localScale.x,
            pinchBox.transform.localScale.y,
            avDistance * 2f
            );
        
    }
    /// <summary>
    /// Same idea as the SyncPinch script but with more pairs of colliders. 
    /// </summary>
    public void SyncGun()
    {
        Vector3 thumbTipPos = thumbTip.transform.position;
        Vector3 indexTipPos = indexTip.transform.position;
        Vector3 middleTipPos = middleTip.transform.position;
        Vector3 ringTipPos = ringTip.transform.position;
        Vector3 pinkyTipPos = pinkyTip.transform.position;

        Vector3 palmDirection = VectorFunc.Direction(pinkyTipPos, ringTipPos);
        float palmDistance = VectorFunc.Distance(pinkyTipPos, ringTipPos);
        Debug.Log("Distance between ring and pinky tip = " + palmDistance);
        gunPalmDirections.Add(palmDirection);
        gunPalmDistances.Add(palmDistance);

        float avPalmDistance = FloatAverage(gunPalmDistances);
        Vector3 avPalmDirection = Vector3Average(gunPalmDirections);
        
        gunPalm.transform.position = pinkyTipPos;
        gunPalm.transform.LookAt(avPalmDirection);
        gunPalm.transform.localScale = new Vector3(
            gunPalm.transform.localScale.x,
            gunPalm.transform.localScale.y,
            avPalmDistance * 2f
            );


        Vector3 pointDirection = VectorFunc.Direction(middleTipPos, indexTipPos);
        float pointDistance = VectorFunc.Distance(middleTipPos, indexTipPos);
        Debug.Log("Distance between middle and index tip = " + pointDistance);
        gunPointDirections.Add(pointDirection);
        gunPointDistances.Add(pointDistance);

        float avPointDistance = FloatAverage(gunPointDistances);
        Vector3 avPointDirection = Vector3Average(gunPointDirections);

        gunPoint.transform.position = middleTipPos;
        gunPoint.transform.LookAt(avPointDirection);
        gunPoint.transform.localScale = new Vector3(
            gunPoint.transform.localScale.x,
            gunPoint.transform.localScale.y,
            avPointDistance * 2f
            );


        Vector3 thumbDownPosition = thumbTipPos;
        thumbDownPositions.Add(thumbDownPosition);

        Vector3 avThumbDownPosition = Vector3Average(thumbDownPositions);

        gunThumbDown.transform.position = avThumbDownPosition;
        gunThumbDown.transform.localScale = new Vector3(
            gunPoint.transform.localScale.x,
            gunPoint.transform.localScale.y,
            0.01f
            );


    }
    /// <summary>
    /// If the palm, point and thumb sensors are all active, then the hand is in the gun/shoot gesture.
    /// </summary>
    void GunDetection()
    {
        GameObject palm = hand_base.transform.Find("GunBoxPalm").gameObject;
        GameObject point = hand_base.transform.Find("GunBoxPoint").gameObject;
        GameObject thumb = hand_base.transform.Find("GunBoxThumbDown").gameObject;

        if (palm.GetComponent<GunPalm_Collider>().isPalm && point.GetComponent<GunPoint_Collider>().isPoint && thumb.GetComponent<GunThumbDown_Collider>().isThumbDown)
        {
            hand_base.GetComponent<ProjectileCannon>().inGunPosition = true;
        }
        else
        {
            hand_base.GetComponent<ProjectileCannon>().inGunPosition = false;

        }
    }

    /// <summary>
    /// The following function calcuates the average of any given float list and returns the float average.
    /// </summary>
    /// <param name="list">The float list thats average is required. </param>
    /// <returns>The average float of the given list. </returns>
    float FloatAverage(List<float> list)
    {
        float listSum = 0;
        float listAverage = 0;
        foreach(float f in list)
        {
            listSum += f;
        }
        if (list.Count > 0)
        listAverage = listSum / list.Count;
        return listAverage;
    }

    /// <summary>
    /// The following function calcuates the average of any given Vector3 list and returns the Vector3 average.
    /// </summary>
    /// <param name="list">The Vector3 list thats average is required. </param>
    /// <returns>The average Vector3 of the given list. </returns>
    Vector3 Vector3Average(List<Vector3> list)
    {
        Vector3 listSum = new Vector3 (0f, 0f, 0f);
        Vector3 listAverage = new Vector3(0f, 0f, 0f);
        foreach (Vector3 f in list)
        {
            listSum += f;
        }
        if (list.Count > 0)
            listAverage = listSum / list.Count;
        return listAverage;
    }

    /// <summary>
    /// The following funtion will clear the lists used to hold the direction and distance data for the pinch gesture.
    /// </summary>
    public void ClearPinchLists()
    {
        pinchDistances.Clear();
        pinchDirections.Clear();
    }

    /// <summary>
    /// The following funtion will clear the lists used to hold the direction and distance data for the gun gesture.
    /// </summary>
    public void ClearGunLists()
    {
        gunPalmDirections.Clear();
        gunPalmDistances.Clear();
        gunPointDirections.Clear();
        gunPointDistances.Clear();
        thumbDownPositions.Clear();
    }

}
