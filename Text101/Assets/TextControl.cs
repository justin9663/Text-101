using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour {

    public Text text;
    public enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0 };
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if (myState == States.cell)             { state_cell(); }
        else if (myState == States.sheets_0)    { state_sheets_0();}
        else if (myState == States.sheets_1)    { state_sheets_1(); }
        else if (myState == States.lock_0)      { state_lock_0(); }
        else if (myState == States.lock_1)      { state_lock_1(); }
        else if (myState == States.mirror)      { state_mirror(); }
        else if (myState == States.cell_mirror) { state_cell_mirror(); }
        else if (myState == States.corridor_0)      { state_freedom(); }
	}

    void state_cell()
    {
        text.text = "You are in a prison cell. You want to get out of here as quickly as you can. " +
                    "There is a bed with dirty sheets, a chamber pot full of crap, a mirror on the wall " +
                    "and it appears that the cell is locked from the outside.\n\n" +
                    "Press S to view sheets, press L to view the lock or press M to view the mirror";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_0;
        } else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.mirror;
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_0;
        }
    }

    void state_sheets_0()
    {
        text.text = "These sheets are disgusting! Isn't it time for someone to change these??\n" +
                    "Oh the joys of prison life.....\n\n" +
                    "Press R to return to your cell";
        if (Input.GetKeyDown(KeyCode.R))        { myState = States.cell; }
    }

    void state_sheets_1()
    {
        text.text = "Looking at the sheets with the mirror in my hand doesn't seem to make these " +
                    "sheets look any better. They still need to be clean. \n\n" +
                    "Press R to return.";
        if (Input.GetKeyDown(KeyCode.R))        { myState = States.cell_mirror; }
    }

    void state_lock_0   ()
    {
        text.text = "Well this is definitely a lock. I don't see how I will be able to open it\n" +
                    "If only there was a way to see the lock form the other side...\n\n" +
                    "Press R to return to the main screen.";
        if (Input.GetKeyDown(KeyCode.R))        { myState = States.cell; }
    }

    void state_lock_1()
    {
        text.text = "I can use the mirror to look at the other side of the lock. \n" +
                    "Well shit, look at that, the key is still in the lock, I can reach thru the " +
                    "bars and twist the key and open the door!\n\n" +
                    "Press O to open the door, or R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.O))        { myState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.R))   { myState = States.cell_mirror; }
    }

    void state_mirror()
    {
        text.text = "The mirror on the wall seems loose. I bet I could remove it with a little effort.\n\n" +
                    "Press T to take the Mirror or R to return to the cell. ";
        if (Input.GetKeyDown(KeyCode.T))        { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.R))   { myState = States.cell; }
    }

    void state_cell_mirror()
    {
        text.text = "You are STILL in your cell and your sheets are still dirty, but now " +
            "you have a mirror in your hands! So at least there is that. :)\n\n" +
            "Press S to view the sheets, or press L to view the lock";
        if (Input.GetKeyDown(KeyCode.S))        { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))   { myState = States.lock_1; }
    }

    void state_freedom()
    {
        text.text = "I am free! Now it is time to get the hell out of here!\n" +
                    "I am never going to get involved with that crazy midget clown posse again!\n\n" +
                    "Game Over!! You are free!! Press P to play again";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }
}
