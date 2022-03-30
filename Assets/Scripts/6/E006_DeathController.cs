using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E006_DeathController : MonoBehaviour {
    public GameObject player;
    public GameObject respawnPos;

    private Vector2 lastGroundPos;
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start () {
        lastGroundPos = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        // if player on ground
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 0.5f, layerMask);

        if (player.transform.position.y < -5.4f) {
            string thisScene = SceneManager.GetActiveScene().name;
            player.transform.position = new Vector3(lastGroundPos.x, lastGroundPos.y, 0);
        } 
        
        else if (hit.collider != null) {
            print("here");
            lastGroundPos.x = player.transform.position.x;
            lastGroundPos.y = player.transform.position.y;
        }

        respawnPos.transform.position = lastGroundPos;
    }
}
