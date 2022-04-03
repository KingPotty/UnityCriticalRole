using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitching : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    private PlayerController_MultipleCharactersAtGoal player1Controller;
    private PlayerController_MultipleCharactersAtGoal player2Controller;

    // Start is called before the first frame update
    void Start()
    {
        player1Controller = player1.GetComponent<PlayerController_MultipleCharactersAtGoal>();
        player2Controller = player2.GetComponent<PlayerController_MultipleCharactersAtGoal>();

        player1Controller.Select();
        player2Controller.Select();

        print(player1Controller.GetSelected());
        print(player2Controller.GetSelected());
    }

    // Update is called once per frame
    void Update () 
    {
        // Q and E allow changing of selected character. Wraps around
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (player1Controller.GetSelected())
            {
                player1Controller.Deselect();
                player2Controller.Select();
            } 
            else
            {
                player1Controller.Select();
                player2Controller.Deselect();
            }
        }

        // if on top of one another, both move if lower one is selected
    }
}