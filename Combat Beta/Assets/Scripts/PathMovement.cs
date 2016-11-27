using UnityEngine;
using System.Collections;

public class PathMovement : MonoBehaviour
{

    public Transform character;
    public Transform characterModel;
    public enum Direction { Forward, Reverse };
    public Direction characterDirection = Direction.Forward;
    private float lookAheadAmount = .005f;
    public float pathPosition = 0.50f; // this is a % from 0 - 1.00
    private float playerSpeed = 10.0f;
    public string currentPath = "MainPath";


    void Update()
    {

        UserInput();

        iTween.PutOnPath(gameObject, iTweenPath.GetPath(currentPath), pathPosition); // this keeps the player at the right spot on the path

        if (pathPosition < 0.02f)
        {
            pathPosition = 0.02f;
        }
        if (pathPosition > 0.98f)
        {
            pathPosition = 0.98f;
        }
        Look();

        //Debug.Log("");
    }


    void Look()
    {
        float pathPercent = pathPosition % 1;
        Vector3 lookTarget;

        if (characterDirection == Direction.Forward)
        {
            lookTarget.x = iTween.PointOnPath(iTweenPath.GetPath(currentPath), pathPercent + lookAheadAmount).x;
            lookTarget.z = iTween.PointOnPath(iTweenPath.GetPath(currentPath), pathPercent + lookAheadAmount).z;
            lookTarget.y = characterModel.position.y;
        }
        else
        {
            lookTarget.x = iTween.PointOnPath(iTweenPath.GetPath(currentPath), pathPercent - lookAheadAmount).x;
            lookTarget.z = iTween.PointOnPath(iTweenPath.GetPath(currentPath), pathPercent - lookAheadAmount).z;
            lookTarget.y = characterModel.position.y;
        }

        characterModel.LookAt(lookTarget);
        lookTarget = iTween.PointOnPath(iTweenPath.GetPath(currentPath), pathPercent + lookAheadAmount);
        character.LookAt(lookTarget);
    }

    void UserInput()
    {
        if (Input.GetAxis("ControllerXaxis") > 0 || Input.GetKey("d") && pathPosition < 0.99)
        {

            characterDirection = Direction.Forward;
            pathPosition += (playerSpeed / iTween.PathLength(iTweenPath.GetPath(currentPath))) * Time.deltaTime;

        }
        if (Input.GetAxis("ControllerXaxis") < 0 || Input.GetKey("a"))
        {

            characterDirection = Direction.Reverse;
            pathPosition -= (playerSpeed / iTween.PathLength(iTweenPath.GetPath(currentPath))) * Time.deltaTime;

        }
    }



    // THE PLAYER DOESN"T MOVE THE SAME SPEED THROUGH OUT THE PATH



}
