using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitching : MonoBehaviour {
    public GameObject playersObject;

    private List<Transform> playerList = new List<Transform>();
    private int selection;
    private float[] playerCurXValues;
    private float[] playerPrevXValues;
    private float buffer;

    // Start is called before the first frame update
    void Start () {
        // get list of player objects
        foreach (Transform player in playersObject.transform) {
            print(playerList.Count);
            playerList.Add(player);
        }

        // select first one
        selection = 0;
        playerList[selection].gameObject.GetComponent<PlayerController_MultipleCharactersAtGoal>().isSelected = true;

        // Initialise current and previous 
        playerCurXValues = new float[playerList.Count];
        playerPrevXValues = new float[playerList.Count];

        for (int i = 0; i < playerList.Count; i++) {
            playerCurXValues[i] = playerList[i].position.x;
            playerPrevXValues[i] = playerList[i].position.x;
        }
    }

    // Update is called once per frame
    void Update () {
        // update current and prev X coords
        buffer = new float();
        for (int i = 0; i < playerList.Count; i++) {
            buffer = playerCurXValues[i];
            playerCurXValues[i] = playerList[i].position.x;
            playerPrevXValues[i] = buffer;
        }

        // Q and E allow changing of selected character. Wraps around
        if (Input.GetKeyDown(KeyCode.Q)) {
            playerList[selection].gameObject.GetComponent<PlayerController_MultipleCharactersAtGoal>().isSelected = false;
            selection -= 1;
            selection = Mathf.Abs(selection % playerList.Count);
            playerList[selection].gameObject.GetComponent<PlayerController_MultipleCharactersAtGoal>().isSelected = true;
            print(selection);
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            playerList[selection].gameObject.GetComponent<PlayerController_MultipleCharactersAtGoal>().isSelected = false;
            selection += 1;
            selection = Mathf.Abs(selection % playerList.Count);
            playerList[selection].gameObject.GetComponent<PlayerController_MultipleCharactersAtGoal>().isSelected = true;
            print(selection);
        }

        // if on top of one another, both move if lower one is selected
    }
}