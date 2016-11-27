using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	
	public void SwitchScenes(int scene)
    {
        SceneManager.LoadScene(scene);
	}
}
