using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RushPig : crossMovement
{
    const double EPSILON = 0.0001; // 허용오차

    private bool isEqual(float x, float y) // 비교 함수.

    {

        return (((x - EPSILON) < y) && (y < (x + EPSILON)));

    }
   
    public bool isPlayerAround(){ // player가 주변 3~4칸 사이에 있으면 돌진하게 만드는 코드
        GameObject mainCat = GameObject.FindGameObjectWithTag("Player");
        Vector3 catPosition = mainCat.transform.position;

        for(int i = -3; i<= 3; i++){
            
            
            if(isEqual(catPosition.y, (transform.position.y + (range * i))) && isEqual(catPosition.x, transform.position.x)) {
                moveToScreen = catPosition;
                return true;
            }
            else if(isEqual(catPosition.y, transform.position.y) && isEqual(catPosition.x, (transform.position.x + (range*i))) ) {
                moveToScreen = catPosition;
                return true;
            }

        }
        return false;

    }

    void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("groundPrefs");
        range = range * Ground.transform.localScale.x;
        moveToScreen.x = range * UnityEngine.Random.Range(-4, 5) + Ground.transform.position.x;
        moveToScreen.y = range * UnityEngine.Random.Range(-4, 5) + Ground.transform.position.y;
        pig_animator = GetComponent<Animator>();
        
        Debug.Log(moveToScreen);
        system = GameObject.FindGameObjectWithTag("system");
        
    }
    void FixedUpdate()
    {
        if (transform.position != moveToScreen)
        {
            pig_animator.SetBool("isMove", true);
        }
        else
        {
            pig_animator.SetBool("isMove", false);
        }
        transform.position = Vector3.MoveTowards(transform.position, moveToScreen, Time.deltaTime * speed);
    }


}
