using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_Switch_Controller : MonoBehaviour {

    //Each of these boolean represent the state of a switch.
	bool isSwitch_L_Up;
	bool isSwitch_M_Up;
	bool isSwitch_R_Up;

    //This float is the timer between switch flicks, to prevent accidental double flicks.
	float switchBufferTimer;

    //These are the switch objects
	GameObject switchL, switchM, switchR;


    //The shield modifier and weapons modifier are placeholders for the time being as they have no consiquence in the world.
    //They are just here as an example of how the glove could be integrated into the game.
	int shieldModifier;
	public int ShieldModifier
	{
		get { return shieldModifier; }
	}

	int weaponModifier;
	public int WeaponModifier {
		get { return weaponModifier; }
	}


	// Use this for initialization
	void Start () {
        //Find all the switches and attach them to the correct gameobject.
		switchL = transform.Find("Switch_L_Base").Find("Switch_L").gameObject;
		switchM = transform.Find("Switch_M_Base").Find("Switch_M").gameObject;
		switchR = transform.Find("Switch_R_Base").Find("Switch_R").gameObject;


		shieldModifier = 3;
		weaponModifier = 0;

        //Start the buffer above the limit so that it doesnt start counting.
		switchBufferTimer = 1.2f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //If the buffer is less than .3 of a second then increase the buffer.
		if (switchBufferTimer < 1.2f)
			switchBufferTimer += Time.deltaTime * 4;
	}

    /// <summary>
    /// The UseSwitch(X) function identifies whether a switch should be flicked, depending on the direction of the collision.
    /// </summary>
    /// <param name="flickUp">If the function is entered with flick up true and isSwitch up false, then the switch will flick up and vice versa.</param>
	public void UseSwitchL(bool flickUp)
	{
        //If the parameter bool is opposite to the is switch up bool, and the buffer is above 0.25 seconds, then flick the switch.
		if ((isSwitch_L_Up != flickUp) && (switchBufferTimer > 1) )
		{
			isSwitch_L_Up = flickUp;
			Debug.Log("SwitchL Flick");

			RotateSwitch(switchL, isSwitch_L_Up);
			ChangeModifier(isSwitch_L_Up);

			//Debug.Log(isSwitch_L_Up);
			switchBufferTimer = 0f;
		}
	}

	public void UseSwitchM(bool flickUp)
	{
		if ((isSwitch_M_Up != flickUp) && (switchBufferTimer > 1))
		{
			isSwitch_M_Up = flickUp;
			Debug.Log("SwitchM Flick");
			
			RotateSwitch(switchM, isSwitch_M_Up);
			ChangeModifier(isSwitch_M_Up);


			//Debug.Log(isSwitch_M_Up);

			switchBufferTimer = 0f;
		}
	}

	public void UseSwitchR(bool flickUp)
	{
		if ((isSwitch_R_Up != flickUp) && (switchBufferTimer > 1))
		{
			isSwitch_R_Up = flickUp;
			Debug.Log("SwitchR Flick");
		
			RotateSwitch(switchR, isSwitch_R_Up);
			ChangeModifier(isSwitch_R_Up);


			//Debug.Log(isSwitch_R_Up);

			switchBufferTimer = 0f;
		}
	}


    /// <summary>
    /// This function contacts the switch object and tewlls it which direction it should rotate.
    /// </summary>
    /// <param name="thisSwitch"> The switch object. </param>
    /// <param name="switchPosition">The direction the switch should rotate.</param>
	void RotateSwitch(GameObject thisSwitch, bool switchPosition)
	{
		thisSwitch.GetComponent<Rotate_Switch>().IsSwitchUp = switchPosition;
	}

    /// <summary>
    /// This is more placeholder code that could be implemented into the main game if the glove was compatible with that version of unity.
    /// </summary>
    /// <param name="switchIsUp">Depending on the direction of the switch, the modifiers are either increased or decreased.</param>
	void ChangeModifier (bool switchIsUp)
	{
		if (switchIsUp)
		{
			weaponModifier++;
			shieldModifier--;
		}
		else {
			weaponModifier--;
			shieldModifier++;
		}
	}
}
