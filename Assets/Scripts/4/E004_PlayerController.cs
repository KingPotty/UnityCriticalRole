using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E004_PlayerController : MonoBehaviour {
    // Constants
    private float SPEED = 5f;
    private float JUMPFORCE = 300;
    private float GOALDISTANCE = 2.8f;
    private float FLOATSPEED = 1f;

    // Variables
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool onGround = false;
    private float prevYPos;
    public bool isFloating = false;

    public GameObject Goal;
    public Sprite sprite;
    public Sprite spriteInGoal;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();

        prevYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.A) && !isFloating) {
            transform.position = new Vector2(transform.position.x - SPEED * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D) && !isFloating) {
            transform.position = new Vector2(transform.position.x + SPEED * Time.deltaTime, transform.position.y);
        }

        if (onGround && prevYPos == transform.position.y) {
            if (Input.GetKey(KeyCode.Space)) {
                rb.AddForce(new Vector2(0, JUMPFORCE));
                onGround = false;
            } else if (Input.GetKeyDown(KeyCode.Q)) {
                isFloating = true;
                rb.gravityScale = 0;
                onGround = false;
            }
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            isFloating = false;
            rb.gravityScale = 1;
        }

        if ((Goal.transform.position - transform.position).magnitude < GOALDISTANCE) {
            sr.sprite = spriteInGoal;
        } else {
            sr.sprite = sprite;
        }

        if (isFloating) {
            transform.position = new Vector2(transform.position.x, transform.position.y + FLOATSPEED * Time.deltaTime);
        }

        prevYPos = transform.position.y;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider != null) {
            if (hit.collider == collision.collider) {
                onGround = true;
            }
        }
    }
}
