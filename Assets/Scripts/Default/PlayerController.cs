using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject goal;
    public float goalDistance;

    public Color defaultColour;
    public Color colourAtGoal;

    protected Rigidbody2D rb;
    private BoxCollider2D bc;
    public float speed;
    public float jumpForce;

    [SerializeField] LayerMask platformLayerMask;

    protected virtual void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.bc = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        Move();

        if (CheckIfWon())
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (this.transform.position.y < -5.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected void Move()
    {
        float xAxisInput = Input.GetAxisRaw("Horizontal");

        float moveBy = xAxisInput * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            rb.AddForce(new Vector2(0, this.jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.01f, platformLayerMask);
        return hit.collider != null;
    }

    protected bool CheckAtGoal()
    {
        return Vector2.Distance(this.transform.position, this.goal.transform.position) < this.goalDistance;
    }

    protected virtual bool CheckIfWon()
    {
        return CheckAtGoal();
    }
}
