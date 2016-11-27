using UnityEngine;
using System.Collections;

public class WheelZoom : MonoBehaviour {

    public string ZoomIn = "WeaponWheelZoom";
    public string ZoomOut = "OutWeaponWheel";
	
    public PlayMode WeaponWheelZoom;

    // Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("RightBumper"))
        {
            GetComponent<Animation>().Play(ZoomIn);
        }
        if (Input.GetButtonUp ("RightBumper"))
        {
            GetComponent<Animation>().Play(ZoomOut);
        }

    }
}