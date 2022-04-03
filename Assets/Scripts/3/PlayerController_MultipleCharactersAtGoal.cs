using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_MultipleCharactersAtGoal : PlayerController
{
    public GameObject otherPlayer;
    private SpriteRenderer sr;

    protected bool selected;

    protected override void Start()
    {
        this.sr = GetComponent<SpriteRenderer>();
        this.selected = false;
        base.Start();
    }

    protected override void Update()
    {
        if (this.selected)
        {
            base.Update();
        }

        if (Vector2.Distance(this.goal.transform.position, this.transform.position) < this.goalDistance)
        {
            this.sr.color = this.colourAtGoal;
        }
        else
        {
            this.sr.color = this.defaultColour;
        }
    }

    protected override bool CheckIfWon()
    {
        return otherPlayer.GetComponent<PlayerController_MultipleCharactersAtGoal>().CheckAtGoal() && this.CheckAtGoal();
    }

    public void Select()
    {
        this.selected = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Deselect()
    {
        this.selected = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    public bool GetSelected()
    {
        return this.selected;
    }
}
