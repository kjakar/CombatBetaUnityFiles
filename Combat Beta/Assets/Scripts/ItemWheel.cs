using UnityEngine;
using System.Collections;
using System;


public class ItemWheel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
    public GameObject CenterUI;
    public static string ItemUp = "none";
    public static string ItemDown = "none";
    public static string ItemLeft = "none";
    public static string ItemRight = "none";
    private int CanShow = 0;

    void Update()
    {

        if (Input.GetButtonDown("LeftBumper"))
        {
            CanShow = 1;
            Time.timeScale = 0.2f;
        }
        if (Input.GetButtonUp("LeftBumper"))
        {
            CanShow = 0;
            Time.timeScale = 1.0f;
        }

        //Debug.Log(CanShow);      

        JoySticks();
        if (RightStickDirection == "Right" && CanShow == 1)
        {
            RightUI.SetActive(true);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "Left" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(true);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "Up" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(true);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            CenterUI.SetActive(false);
        }
        else if (RightStickDirection == "Down" && CanShow == 1)
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(true);
            LeftUI.SetActive(false);
            CenterUI.SetActive(false);
        }

        else
        {
            RightUI.SetActive(false);
            UpUI.SetActive(false);
            DownUI.SetActive(false);
            LeftUI.SetActive(false);
            CenterUI.SetActive(false);
        }




    }

    void JoySticks()
    {
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
        if (RightStickAngle > -225 && RightStickAngle < -135)
        {
            RightStickDirection = "Left";
        }
        //right
        else if (RightStickAngle > -45 && RightStickAngle < 45)
        {
            RightStickDirection = "Right";
        }
        //up
        else if ((RightStickAngle > 45 && (RightStickAngle < 270) || RightStickAngle < -225))
        {
            RightStickDirection = "Up";
        }
        //down
        else if (RightStickAngle < -45 && RightStickAngle > -135)
        {
            RightStickDirection = "Down";
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
