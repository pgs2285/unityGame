using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossPig : crossMovement
{
    GameObject camerashake;
    int count = 0;
    void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("groundPrefs");
        range = range * Ground.transform.localScale.x;
        moveToScreen.x = range * UnityEngine.Random.Range(-4, 4) + Ground.transform.position.x;
        moveToScreen.y = range * UnityEngine.Random.Range(-4, 4) + Ground.transform.position.y;
        pig_animator = GetComponent<Animator>();
        
        camerashake = GameObject.FindGameObjectWithTag("MainCamera");

        Debug.Log(moveToScreen);
        system = GameObject.FindGameObjectWithTag("system");
        setHP(30);
        setFullHP(30);
    }
    void FixedUpdate()
    {
        if (transform.position != moveToScreen)
        {
            pig_animator.SetBool("isMove", true);
            count = 0;
        }
        else
        {   
            if(count == 0){
                camerashake.GetComponent<cameraShake>().VibrateForTime(0.5f);
                count++;
            }
            pig_animator.SetBool("isMove", false);
        }
        transform.position = Vector3.MoveTowards(transform.position, moveToScreen, Time.deltaTime * speed);
    }

}
