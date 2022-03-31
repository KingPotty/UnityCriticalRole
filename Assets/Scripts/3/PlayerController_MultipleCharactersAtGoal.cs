using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_MultipleCharactersAtGoal : PlayerController
{
    public GameObject otherPlayer;

    protected override bool CheckIfWon()
    {
        return otherPlayer.GetComponent<PlayerController_MultipleCharactersAtGoal>().CheckAtGoal() && this.CheckAtGoal();
    }
}
