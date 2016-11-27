using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject healthUI;
    public GameObject manaUI;
    public GameObject energyUI;
    public float health = 100.0f;
    public float mana = 100.0f;
    public float energy = 100.0f;

    // Update is called once per frame
    void Update () {

        healthUI.GetComponent<RectTransform>().sizeDelta = new Vector2(health * 10, 25);
        manaUI.GetComponent<RectTransform>().sizeDelta = new Vector2(mana * 10, 25);
        energyUI.GetComponent<RectTransform>().sizeDelta = new Vector2(energy * 10, 25);
        
        if(mana > 100)
        {
            mana = 100;
        }
        if (health > 100)
        {
            health = 100;
        }
        if (energy > 100)
        {
            energy = 100;
        }


    }
}
