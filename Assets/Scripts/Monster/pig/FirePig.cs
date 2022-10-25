using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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


    public void firePigMovePattern(float range)
    {

        // 1~4 까지 이동
        range = range * Ground.transform.localScale.x;
        while (true)
        {
            int direction = UnityEngine.Random.Range(1, 5);
            checkGround = moveToScreen;
            if (direction == UP)
            {
                checkGround.y += range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) { 
                    
                    for(float i = 0; i < 1.6; i+= 0.8f)
                    Instantiate(Fire, transform.position + new Vector3(0, i, 0),Quaternion.identity);
                    moveToScreen = checkGround;
                    break;
                }


            }
            else if (direction == DOWN)
            {
                checkGround.y -= range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) {
                    for (float i = 0; i < 1.6; i += 0.8f)
                        Instantiate(Fire, transform.position + new Vector3(0, -i, 0), Quaternion.identity);
                    moveToScreen = checkGround;
                    break;
                }


            }
            else if (direction == LEFT)
            {
                checkGround.x -= range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) {
                    for (float i = 0; i < 1.6; i += 0.8f)
                        Instantiate(Fire, transform.position + new Vector3(-i, 0, 0), Quaternion.identity);
                    moveToScreen = checkGround;
                    break;
                }


            }
            else if (direction == RIGHT)
            {
                checkGround.x += range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) {
                    for (float i = 0; i < 1.6; i += 0.8f)
                        Instantiate(Fire, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
                    moveToScreen = checkGround;
                    break;
                }


            }
        }

    }


}
