using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E003_PlayerController : MonoBehaviour {
    // Constants
    private float SPEED = 5f;
    private float JUMPFORCE = 300;
    private float GOALDISTANCE = 2.8f;

    // Variables
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool onGround = false;
    private float prevYPos;
    public GameObject Goal;
    public Sprite sprite;
    public Sprite spriteInGoal;

    public bool isSelected = false;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();

        prevYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        if (isSelected) {
            if (Input.GetKey(KeyCode.A)) {
                transform.position = new Vector2(transform.position.x - SPEED * Time.deltaTime, transform.position.y);
            }

            if (Input.GetKey(KeyCode.D)) {
                transform.position = new Vector2(transform.position.x + SPEED * Time.deltaTime, transform.position.y);
            }

            if (Input.GetKey(KeyCode.Space) && onGround && prevYPos == transform.position.y) {
                rb.AddForce(new Vector2(0, JUMPFORCE));
                onGround = false;
            }

            if ((Goal.transform.position - transform.position).magnitude < GOALDISTANCE) {
                sr.sprite = spriteInGoal;
            } else {
                sr.sprite = sprite;
            }

            prevYPos = transform.position.y;
        }
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
