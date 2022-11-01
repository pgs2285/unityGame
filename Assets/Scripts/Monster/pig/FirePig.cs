using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class FirePig : crossMovement
{
    public GameObject Fire;
    public void makeFire(){ // player가 주변 3~4칸 사이에 있으면 돌진하게 만드는 코드
        

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
        setHP(15);
        setFullHP(15);
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


    const double EPSILON = 0.0001; // 허용오차

    private bool isEqual(float x, float y) // 비교 함수.

    {

        return (((x - EPSILON) < y) && (y < (x + EPSILON)));

    }

    public bool firePigMovePattern(float range)
    {
        GameObject mainCat = GameObject.FindGameObjectWithTag("Player");
        Vector3 catPosition = mainCat.transform.position;
        // 1~4 까지 이동
        range = range * Ground.transform.localScale.x;



            for (int i = -3; i <= 3; i++)
            {


                if (isEqual(catPosition.y, (transform.position.y + (range * i))) && isEqual(catPosition.x, transform.position.x))
                {
                    moveToScreen = catPosition;
                    return true;
                }
                else if (isEqual(catPosition.y, transform.position.y) && isEqual(catPosition.x, (transform.position.x + (range * i))))
                {
                    moveToScreen = catPosition;
                    return true;
                }

            }
        return false;
        

    }


}
