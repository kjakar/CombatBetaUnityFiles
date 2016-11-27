using UnityEngine;
using System.Collections;
using System;


public class WeaponWheel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public Double LeftStickAngle = 0.0f;
    public Double RightStickAngle = 0.0f;
    public string LeftStickDirection = "none";
    public string RightStickDirection = "none";
    public GameObject UpUI;
    public GameObject DownUI;
    public GameObject LeftUI;
    public GameObject RightUI;
    public GameObject LeftUpUI;
    public GameObject LeftDownUI;
    public GameObject RightUpUI;
    public GameObject RightDownUI;
    public GameObject CenterUI;
    private int CanShow = 0;

    void Update () {

        if (Input.GetButtonDown("RightBumper"))
        {
            CanShow = 1;
        }
        if (Input.GetButtonUp("RightBumper"))
        {
            CanShow = 0;
        }

        //Debug.Log(CanShow);

        JoySticks();
        if (RightStickDirection == "Right" && CanShow == 1)
        {
            RightUI.SetActive(true);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "Left" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(true);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "Up" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(true);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "Down" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(true);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "RightUp" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(true);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "RightDown" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(true);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "LeftUp" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(true);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "LeftDown" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(true);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "None" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(true);
        }
        else
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            LeftUpUI.SetActive(false);
            LeftDownUI.SetActive(false);
            RightUpUI.SetActive(false);
            RightDownUI.SetActive(false);
            CenterUI.SetActive(false);
        }




    }

    void JoySticks() {
        // this gives back the angle of the thumbsticks right being 0  degrees and left being -180 degrees || sets the value to 360 if not in use
        //left stick
        if (Input.GetAxis("ControllerXaxis") != 0 || Input.GetAxis("ControllerYaxis") != 0)
        {
            LeftStickAngle = Math.Atan2(Input.GetAxis("ControllerXaxis"), Input.GetAxis("ControllerYaxis")) * (180 / Math.PI) - 90;
        }
        else
        {
            LeftStickAngle = 360;
        }

        //right stick
        if (Input.GetAxis("ControllerRightXaxis") != 0 || Input.GetAxis("ControllerRightYaxis") != 0)
        {
            RightStickAngle = Math.Atan2(Input.GetAxis("ControllerRightXaxis"), Input.GetAxis("ControllerRightYaxis")) * (180 / Math.PI) - 90;
        }
        else
        {
            RightStickAngle = 360;
        }
        // end of thumbstick updates


        // this handles the eight directions
        //left stick =======================
        //left
        if (LeftStickAngle > -202.5 && LeftStickAngle < -157.5)
        {
            LeftStickDirection = "Left";
        }
        //right
        else if (LeftStickAngle > -22.5 && LeftStickAngle < 22.5)
        {
            LeftStickDirection = "Right";
        }
        //up
        else if ((LeftStickAngle > 67.5 && (LeftStickAngle < 270) || LeftStickAngle < -247.5))
        {
            LeftStickDirection = "Up";
        }
        //down
        else if (LeftStickAngle < -67.5 && LeftStickAngle > -112.5)
        {
            LeftStickDirection = "Down";
        }
        //left up
        else if (LeftStickAngle < -202.5 && LeftStickAngle > -247.5)
        {
            LeftStickDirection = "LeftUp";
        }
        //left down
        else if (LeftStickAngle < -112.5 && LeftStickAngle > -157.5)
        {
            LeftStickDirection = "LeftDown";
        }
        //right up
        else if (LeftStickAngle > 22.5 && LeftStickAngle < 67.5)
        {
            LeftStickDirection = "RightUp";
        }
        //right down
        else if (LeftStickAngle < -22.5 && LeftStickAngle > -67.5)
        {
            LeftStickDirection = "RightDown";
        }
        //none
        else if (LeftStickAngle > 270)
        {
            LeftStickDirection = "None";
        }

        //Debug.Log(LeftStickDirection + "   " + LeftStickAngle);

        //Right stick =======================
        //left
        if (RightStickAngle > -202.5 && RightStickAngle < -157.5)
        {
            RightStickDirection = "Left";
        }
        //right
        else if (RightStickAngle > -22.5 && RightStickAngle < 22.5)
        {
            RightStickDirection = "Right";
        }
        //up
        else if ((RightStickAngle > 67.5 && (RightStickAngle < 270) || RightStickAngle < -247.5))
        {
            RightStickDirection = "Up";
        }
        //down
        else if (RightStickAngle < -67.5 && RightStickAngle > -112.5)
        {
            RightStickDirection = "Down";
        }
        //left up
        else if (RightStickAngle < -202.5 && RightStickAngle > -247.5)
        {
            RightStickDirection = "LeftUp";
        }
        //left down
        else if (RightStickAngle < -112.5 && RightStickAngle > -157.5)
        {
            RightStickDirection = "LeftDown";
        }
        //right up
        else if (RightStickAngle > 22.5 && RightStickAngle < 67.5)
        {
            RightStickDirection = "RightUp";
        }
        //right down
        else if (RightStickAngle < -22.5 && RightStickAngle > -67.5)
        {
            RightStickDirection = "RightDown";
        }
        //none
        else if (RightStickAngle > 270)
        {
            RightStickDirection = "None";
        }

        //Debug.Log(RightStickDirection + "   " + RightStickAngle);
        // end of direction updates
    }
}
