using UnityEngine;
using System.Collections;
using System;

public class ItemsMenu : MonoBehaviour {



    #region GlobalVars

    //these keep track of the items in the menu
    public string[] Slots = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "None", "None", "None", "None", "None", "None", "None", "None", "None", "None", "None" };
    public int[] SlotsAmount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

    private int numRows = 5;
    private int numCols = 5;

    //this keeps track of the pointer posistion
    private int currentSlot = 8;

    //this is for menu movement
    private float timer = 0.0f;
    private bool CanMove = true;
    private string LeftStickDirection = "none";
    private Double LeftStickAngle = 0.0f;

    //this is for moving items
    private bool MoveingItem = false;
    private int MoveItemSlot = 1;
    private bool MovingItemBreak = false;

    //this is for the sub menu
    private bool inUseMenu = false;
    private bool inUseMenuBreak = false;
    private int useMenuPos = 1;

    //this is for equiping items
    private bool isEquiping = true;
    private bool inEquipingMenu = false;

    #endregion



    void Start () {
        Debug.Log(SlotsAmount.Length + "    " + Slots.Length);
	}



    void Update()
    {
        JoySticks();

        #region pointer Movement

        #region outer menu movement
        //this takes care of moiving the pointer
        if (timer > 0) { timer -= Time.deltaTime; }
        if (timer <= 0) { CanMove = true; }

        if (LeftStickDirection == "Left" && CanMove == true && inUseMenu == false && isEquiping == false)
        {
            if (currentSlot > 1)
            {
                currentSlot -= 1;
                CanMove = false;
                timer = 0.3f;
            }
        }
        if (LeftStickDirection == "Right" && CanMove == true && inUseMenu == false && isEquiping == false)
        {
            if (currentSlot < numCols * numRows)
            {
                currentSlot += 1;
                CanMove = false;
                timer = 0.3f;
            }
        }
        if (LeftStickDirection == "Up" && CanMove == true && inUseMenu == false && isEquiping == false)
        {
            if (currentSlot > numCols)
            {
                currentSlot -= numCols;
                CanMove = false;
                timer = 0.3f;
            }
        }
        if (LeftStickDirection == "Down" && CanMove == true && inUseMenu == false && isEquiping == false)
        {
            if (currentSlot < (numCols * numRows) - numCols)
            {
                currentSlot += numCols;
                CanMove = false;
                timer = 0.3f;
            }
        }
        #endregion

        #region sub menu movement
        // this deals with the sub/use item menu | this has three slots, equip, move, and trash.
        if (LeftStickDirection == "Up" && CanMove == true && inUseMenu == true)
        {
            if (useMenuPos > 1)
            {
                useMenuPos -= 1;
                CanMove = false;
                timer = 0.3f;
            }
        }
        if (LeftStickDirection == "Down" && CanMove == true && inUseMenu == true)
        {
            if (useMenuPos < 3)
            {
                useMenuPos += 1;
                CanMove = false;
                timer = 0.3f;
            }
        }

        #endregion

        #endregion

        #region sub/use menu actions
        if (Input.GetButtonDown("A"))
        {
            /*
            if (MoveingItem == false)
            {
                MoveItemSlot = currentSlot;
                MoveingItem = true;
                MovingItemBreak = true;
            }
            */
            
            // this opens the sub menu            
            if (inUseMenu == false && MoveingItem == false && isEquiping == false)
            {
                inUseMenu = true;
                inUseMenuBreak = true;
            }

            // this selects a button from the sub menu
            if (inUseMenu == true && inUseMenuBreak == false)
            {
                if (useMenuPos == 1) { inUseMenu = false; useMenuPos = 1; inEquipingMenu = true; Debug.Log("======================================================"); isEquiping = true; } //add the code to equip the item to the item wheel

                if (useMenuPos == 2) //this is to move the items
                {
                    MoveItemSlot = currentSlot;
                    MoveingItem = true;
                    MovingItemBreak = true;
                    inUseMenu = false;
                    useMenuPos = 1;
                } 

                if (useMenuPos == 3) { SlotsAmount[currentSlot - 1] = 0; inUseMenu = false; useMenuPos = 1; } // this is to trash the item
            }
            
            //this places the item after you chose move in the sub menu
            if (MoveingItem == true && MovingItemBreak == false)
            {
                string temp = Slots[MoveItemSlot - 1];
                string temp2 = Slots[currentSlot - 1];

                Slots[MoveItemSlot - 1] = temp2;
                Slots[currentSlot - 1] = temp;

                MoveingItem = false;
            }

            //this selects which slot you put the item into after selecting equip
            if(isEquiping == true && LeftStickDirection != "None")
            {
                if (LeftStickDirection == "Up")
                {
                    ItemWheel.ItemUp = Slots[currentSlot - 1];
                    isEquiping = false;
                }
                if (LeftStickDirection == "Down")
                {
                    ItemWheel.ItemDown = Slots[currentSlot - 1];
                    isEquiping = false;
                }
                if (LeftStickDirection == "Left")
                {
                    ItemWheel.ItemLeft = Slots[currentSlot - 1];
                    isEquiping = false;
                }
                if (LeftStickDirection == "Right")
                {
                    ItemWheel.ItemRight = Slots[currentSlot - 1];
                    isEquiping = false;
                }
            }

            inUseMenuBreak = false;
            MovingItemBreak = false;
        }
        
        #endregion

        Debug.Log(Slots[currentSlot - 1] + " < slot | use menu pos > " + useMenuPos + " item up > " + ItemWheel.ItemUp + " is equiping > " + isEquiping);


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
        // end of thumbstick updates

        // this handles the four directions
        //left stick =======================
        //left
        if (LeftStickAngle > -225 && LeftStickAngle < -135)
        {
            LeftStickDirection = "Left";
        }
        //Right
        else if (LeftStickAngle > -45 && LeftStickAngle < 45)
        {
            LeftStickDirection = "Right";
        }
        //up
        else if ((LeftStickAngle > 45 && (LeftStickAngle < 270) || LeftStickAngle < -225))
        {
            LeftStickDirection = "Up";
        }
        //down
        else if (LeftStickAngle < -45 && LeftStickAngle > -135)
        {
            LeftStickDirection = "Down";
        }
        //none
        else if (LeftStickAngle > 270)
        {
            LeftStickDirection = "None";
        }

        //Debug.Log(LeftStickDirection + "   " + LeftStickAngle);
        // end of direction updates
    }
}
