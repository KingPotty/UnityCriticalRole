﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -5.4f) {
            string thisScene = SceneManager.GetActiveScene().name;
            SceneManager.UnloadSceneAsync(thisScene);
            SceneManager.LoadSceneAsync(thisScene);
        }
    }
}
