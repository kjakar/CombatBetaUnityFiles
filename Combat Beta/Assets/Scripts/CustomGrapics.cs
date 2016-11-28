using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomGrapics : MonoBehaviour
{
    // we are going to have 5 resolution levels from 1152x648 - 3840x2160
    static int resolution = 0;
    static bool fullscreen = false;
    static bool anisotropicFilter = false;
    static int antiAliasing = 0;
    public GameObject fullscreenText;
    public GameObject resolutionText;
    public GameObject anisotropicFilterText;
    public GameObject antiAliasingText;

    // this will handle the laoding and setting all of the values when we open the menu

    void Start()
    {
        // handles resolution ================================================================================
        if (PlayerPrefs.HasKey("resolution"))
        {
            resolution = PlayerPrefs.GetInt("resolution");

            // sets the resolution after loading
            if (resolution == 0)
            {
                Screen.SetResolution(1152, 648, fullscreen);
                resolutionText.GetComponentInChildren<Text>().text = "1152x648";
            }
            else if (resolution == 1)
            {
                Screen.SetResolution(1280, 720, fullscreen);
                resolutionText.GetComponentInChildren<Text>().text = "1280x720";
            }
            else if (resolution == 2)
            {
                Screen.SetResolution(1920, 1080, fullscreen);
                resolutionText.GetComponentInChildren<Text>().text = "1920x1080";
            }
            else if (resolution == 3)
            {
                Screen.SetResolution(2560, 1440, fullscreen);
                resolutionText.GetComponentInChildren<Text>().text = "2560x1440";
            }
            else if (resolution == 4)
            {
                Screen.SetResolution(3840, 2160, fullscreen);
                resolutionText.GetComponentInChildren<Text>().text = "3840x2160";
            }
        }

        // handles fullscreen mode ===========================================================================
        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 1)
            {
                fullscreen = false;
                ChangeFullscreen();
            }

            else if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                fullscreen = true;
                ChangeFullscreen();
            }
        }

        //handles the AF =====================================================================================
        if (PlayerPrefs.HasKey("anisotropicFilter"))
        {
            if (PlayerPrefs.GetInt("anisotropicFilter") == 1)
            {
                anisotropicFilter = false;
                ChangeAnisotropicFilter();
            }

            else if (PlayerPrefs.GetInt("anisotropicFilter") == 0)
            {
                anisotropicFilter = true;
                ChangeAnisotropicFilter();
            }
        }

        // handles the AA ====================================================================================
        if (PlayerPrefs.HasKey("antiAliasing"))
        {
            antiAliasing = PlayerPrefs.GetInt("antiAliasing");
            if (antiAliasing == 0)
            {
                QualitySettings.antiAliasing = 0;
                antiAliasingText.GetComponentInChildren<Text>().text = "AA Off";
            }
            else if (antiAliasing == 2)
            {
                QualitySettings.antiAliasing = 2;
                antiAliasingText.GetComponentInChildren<Text>().text = "2X AA";
            }
            else if (antiAliasing == 4)
            {
                QualitySettings.antiAliasing = 4;
                antiAliasingText.GetComponentInChildren<Text>().text = "4X AA";
            }
            else if (antiAliasing == 8)
            {
                QualitySettings.antiAliasing = 8;
                antiAliasingText.GetComponentInChildren<Text>().text = "8X AA";
            }
        }

        saveGraphicsData();
    }

    private void saveGraphicsData()
    {
        PlayerPrefs.SetInt("resolution", resolution);
        PlayerPrefs.SetInt("antiAliasing", antiAliasing);
        if (fullscreen) { PlayerPrefs.SetInt("fullscreen", 1); }
        else { PlayerPrefs.SetInt("fullscreen", 0); }
        if(anisotropicFilter) { PlayerPrefs.SetInt("anisotropicFilter", 1); }
        else { PlayerPrefs.SetInt("anisotropicFilter", 0); }
    }

    public void ChangeAnisotropicFilter()
    {
        if (anisotropicFilter == false)
        {
            anisotropicFilter = true;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
            anisotropicFilterText.GetComponentInChildren<Text>().text = "AF Enabled";
        }
        else if (anisotropicFilter == true)
        {
            anisotropicFilter = false;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            anisotropicFilterText.GetComponentInChildren<Text>().text = "AF Disabled";
        }
        saveGraphicsData();
    }

    public void ChangeAntiAliasing(int Higher)
    {
        if (Higher == 1)
        {
            if (antiAliasing == 0)
            {
                QualitySettings.antiAliasing = 2;
                antiAliasingText.GetComponentInChildren<Text>().text = "2X AA";
                antiAliasing = 2;
            }
            else if (antiAliasing == 2)
            {
                QualitySettings.antiAliasing = 4;
                antiAliasingText.GetComponentInChildren<Text>().text = "4X AA";
                antiAliasing = 4;
            }
            else if (antiAliasing == 4)
            {
                QualitySettings.antiAliasing = 8;
                antiAliasingText.GetComponentInChildren<Text>().text = "8X AA";
                antiAliasing = 8;
            }
        }

        if (Higher == 0)
        {
            if (antiAliasing == 8)
            {
                QualitySettings.antiAliasing = 4;
                antiAliasingText.GetComponentInChildren<Text>().text = "4X AA";
                antiAliasing = 4;
            }
            else if (antiAliasing == 4)
            {
                QualitySettings.antiAliasing = 2;
                antiAliasingText.GetComponentInChildren<Text>().text = "2X AA";
                antiAliasing = 2;
            }
            else if (antiAliasing == 2)
            {
                QualitySettings.antiAliasing = 0;
                antiAliasingText.GetComponentInChildren<Text>().text = "AA Off";
                antiAliasing = 0;
            }

        }
        saveGraphicsData();
    }

    public void ChangeResolution(int Higher)
    {

        if (Higher == 1)
        {
            if (resolution == 0)
            {
                Screen.SetResolution(1280, 720, fullscreen);
                resolution = 1;
                resolutionText.GetComponentInChildren<Text>().text = "1280x720";
            }
            else if (resolution == 1)
            {
                Screen.SetResolution(1920, 1080, fullscreen);
                resolution = 2;
                resolutionText.GetComponentInChildren<Text>().text = "1920x1080";
            }
            else if (resolution == 2)
            {
                Screen.SetResolution(2560, 1440, fullscreen);
                resolution = 3;
                resolutionText.GetComponentInChildren<Text>().text = "2560x1440";
            }
            else if (resolution == 3)
            {
                Screen.SetResolution(3840, 2160, fullscreen);
                resolution = 4;
                resolutionText.GetComponentInChildren<Text>().text = "3840x2160";
            }

        }
        if (Higher == 0)
        {
            if (resolution == 1)
            {
                Screen.SetResolution(1152, 648, fullscreen);
                resolution = 0;
                resolutionText.GetComponentInChildren<Text>().text = "1152x648";
            }
            if (resolution == 2)
            {
                Screen.SetResolution(1280, 720, fullscreen);
                resolution = 1;
                resolutionText.GetComponentInChildren<Text>().text = "1280x720";
            }
            if (resolution == 3)
            {
                Screen.SetResolution(1920, 1080, fullscreen);
                resolution = 2;
                resolutionText.GetComponentInChildren<Text>().text = "1920x1080";
            }
            if (resolution == 4)
            {
                Screen.SetResolution(2560, 1440, fullscreen);
                resolution = 3;
                resolutionText.GetComponentInChildren<Text>().text = "2560x1440";
            }
            saveGraphicsData();
        }





    }

    public void ChangeFullscreen()
    {
        fullscreen = !fullscreen;

        if (fullscreen == true)
            fullscreenText.GetComponentInChildren<Text>().text = "FullScreen Mode";
        if (fullscreen == false)
            fullscreenText.GetComponentInChildren<Text>().text = "Windowed Mode";


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
        saveGraphicsData();
    }

}
