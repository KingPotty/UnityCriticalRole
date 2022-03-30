using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E001_PlayerController : MonoBehaviour
{
    public GameObject movingPlatform;

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.gameObject == movingPlatform) {
            transform.SetParent(collision.collider.gameObject.transform);
        }
    }

    private void OnCollisionExit2D (Collision2D collision) {
        if (collision.collider.gameObject == movingPlatform) {
            transform.parent = null;
        }
    }
}
