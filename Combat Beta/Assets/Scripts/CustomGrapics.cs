using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomGrapics : MonoBehaviour
{

    // we are going to have 5 resolution levels from 1152x648 - 3840x2160
    static int resolution = 0;
    static bool fullscreen = false;
    public GameObject fullscreenText;


    public void ChangeResolution(int Higher)
    {

        if (Higher == 1)
        {
            if (resolution == 0)
            {
                Screen.SetResolution(1280, 720, fullscreen);
                resolution = 1;
            }
            else if (resolution == 1)
            {
                Screen.SetResolution(1920, 1080, fullscreen);
                resolution = 2;
            }
            else if (resolution == 2)
            {
                Screen.SetResolution(2560, 1440, fullscreen);
                resolution = 3;
            }
            else if (resolution == 3)
            {
                Screen.SetResolution(3840, 2160, fullscreen);
                resolution = 4;
            }

        }
        if (Higher == 0)
        {
            if (resolution == 1)
            {
                Screen.SetResolution(1152, 648, fullscreen);
                resolution = 0;
            }
            if (resolution == 2)
            {
                Screen.SetResolution(1280, 720, fullscreen);
                resolution = 1;
            }
            if (resolution == 3)
            {
                Screen.SetResolution(1920, 1080, fullscreen);
                resolution = 2;
            }
            if (resolution == 4)
            {
                Screen.SetResolution(2560, 1440, fullscreen);
                resolution = 3;
            }
        }





    }

    public void ChangeFullscreen()
    {
        fullscreen = !fullscreen;

        if (fullscreen == true)
            fullscreenText.GetComponentInChildren<Text>().text = "FullScreen mode True";
        if (fullscreen == false)
            fullscreenText.GetComponentInChildren<Text>().text = "FullScreen mode False";


        if (resolution == 0)
        {
            Screen.SetResolution(1152, 648, fullscreen);
        }
        else if (resolution == 1)
        {
            Screen.SetResolution(1280, 720, fullscreen);
        }
        else if (resolution == 2)
        {
            Screen.SetResolution(1920, 1080, fullscreen);
        }
        else if (resolution == 3)
        {
            Screen.SetResolution(2560, 1440, fullscreen);
        }
        else if (resolution == 4)
        {
            Screen.SetResolution(3840, 2160, fullscreen);
        }
        Debug.Log(fullscreen);
    }


}
