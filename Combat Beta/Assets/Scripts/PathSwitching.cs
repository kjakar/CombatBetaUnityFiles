using UnityEngine;
using System.Collections;

public class PathSwitching : MonoBehaviour
{

    public string pathName;
    public float whatPercent = 0;
    public string LeftRightOrBack;
    public GameObject Character;


    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("The Char is in");
        if (Input.GetKey("w") && LeftRightOrBack == "Back")
        {
            Character.GetComponent<PathMovement>().currentPath = pathName;
            Character.GetComponent<PathMovement>().characterDirection = PathMovement.Direction.Forward;
            Character.GetComponent<PathMovement>().pathPosition = whatPercent / 100;
        }
        if (Input.GetKey("a") && LeftRightOrBack == "Left")
        {
            Character.GetComponent<PathMovement>().currentPath = pathName;
            Character.GetComponent<PathMovement>().characterDirection = PathMovement.Direction.Forward;
            Character.GetComponent<PathMovement>().pathPosition = whatPercent / 100;
        }
        if (Input.GetKey("a") && LeftRightOrBack == "Right")
        {
            Character.GetComponent<PathMovement>().currentPath = pathName;
            Character.GetComponent<PathMovement>().characterDirection = PathMovement.Direction.Forward;
            Character.GetComponent<PathMovement>().pathPosition = whatPercent / 100;
        }
    }
}
