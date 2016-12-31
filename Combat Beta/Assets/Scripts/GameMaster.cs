using UnityEngine;
using System.Collections;
using System;

public class GameMaster : MonoBehaviour {

    public GameObject OptionsMenu;
    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // this opens the graphics options menu
        if (Input.GetButtonUp("Start"))
        {
            if (OptionsMenu.activeSelf)
            { OptionsMenu.SetActive(false); }
            else { OptionsMenu.SetActive(true); }
        }
	}
}
