using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E005_PlayerController : MonoBehaviour
{
    // Constants
    private float SPEED = 5f;
    private float JUMPFORCE = 300;
    private float GOALDISTANCE = 2.8f;

    // Variables
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private bool isOnGround = false;
    public GameObject Goal;
    public Sprite sprite;
    public Sprite spriteInGoal;
    
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfOnGround();

        if (Input.GetKey(KeyCode.A)) {
            transform.position = new Vector2(transform.position.x - SPEED * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.position = new Vector2(transform.position.x + SPEED * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            rb.AddForce(new Vector2(0, JUMPFORCE));

        }

        if((Goal.transform.position - transform.position).magnitude < GOALDISTANCE) {
            sr.sprite = spriteInGoal;
        } else {
            sr.sprite = sprite;
        }
    }

    private void checkIfOnGround () {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        isOnGround = hit.collider != null;
    }

    public bool getIsOnGround () {
        return isOnGround;
    }
}
