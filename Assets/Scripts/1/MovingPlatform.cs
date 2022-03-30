using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float SPEED = 2f;

    private int destinationID;
    private Vector2 destination;
    private Vector2[] waypoints = new Vector2[] { new Vector2(-3f, -2f), new Vector2(3f, -2f) };

    // Start is called before the first frame update
    void Start () {
        destinationID = 0;
        destination = waypoints[destinationID];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 prevPos = new Vector2(transform.position.x, transform.position.y);

        Vector2 direction = (destination - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.position += new Vector3(direction.x * SPEED * Time.deltaTime, direction.y * SPEED * Time.deltaTime);

        if(!((destination.x > prevPos.x && destination.x > transform.position.x) || (destination.x < prevPos.x && destination.x < transform.position.x))) {
            if (!((destination.y > prevPos.y && destination.y > transform.position.y) || (destination.y < prevPos.y && destination.y < transform.position.y))) {
                destinationID += 1;
                destinationID %= waypoints.Length;
                destination = waypoints[destinationID];
            }
        }
    }
}
