﻿using UnityEngine;
using System.Collections;

public class Invincibility : Effects {

    private void Awake()
    {
        timeActive = 20.0f;
    }

    // Use this for initialization
    void Start () {
        base.Start();
	}
	
}
