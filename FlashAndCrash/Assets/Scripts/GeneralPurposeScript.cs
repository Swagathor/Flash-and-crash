﻿//Remove cursor, allow for alt-f4/escape to quit

using UnityEngine;
using System.Collections;

public class GeneralPurposeScript : MonoBehaviour {
    private CompletionTimer timer;

	// Use this for initialization
	void Start () {
        timer = (CompletionTimer) gameObject.GetComponent(typeof(CompletionTimer));
        Screen.lockCursor = true;
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyDown(KeyCode.F4)))
        {
            if (Application.isEditor)
            {
                Screen.lockCursor = false;
            }
            else
            {
                Application.Quit();
            }
        }

        if (/*Globals.gameFinished &&*/ Input.GetKeyDown(KeyCode.Keypad9))
        {
            Globals.gameFinished = false;
            Application.LoadLevel("Level_1");
        }

        if (timer && timer.isActivated)
        {
            Debug.Log(timer.ToString());
        }
    }
}
