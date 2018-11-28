﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : InventoryController {


    public GameObject InventoryUI;

    public virtual void Open()
    {
        var canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();

        var control = Instantiate(InventoryUI, canvas.transform);

        var screen = control.GetComponent<InventoryScreen>();
        screen.Load(this);


        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public virtual void Close()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public virtual void Toggle()
    {

    }

    public virtual void Start()
    {
        
    }
}
