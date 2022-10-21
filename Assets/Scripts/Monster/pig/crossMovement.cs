using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class crossMovement : Monster_PIG
{
    // Start is called before the first frame update

    private GameObject Ground;
    private Vector3 moveToScreen;
    private float range = 1;
    public int speed = 10;
    public bool turnEnd;
    Vector3 checkGround;
    public Sprite moveIndicator;

    private const int LEFT = 1;
    private const int RIGHT = 2;
    private const int DOWN = 3;
    private const int UP = 4;
    private const int ERROR = 0;
    

    private GameObject system;

    void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("groundPrefs");
        range = range * Ground.transform.localScale.x;
        moveToScreen.x = range * UnityEngine.Random.Range(-4, 4) + Ground.transform.position.x;
        moveToScreen.y = range * UnityEngine.Random.Range(-4, 4) + Ground.transform.position.y;
        pig_animator = GetComponent<Animator>();
        moveToScreen.z = -2;
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

    public void pigMovePattern(){
       
         // 1~4 까지 이동
        while (true)
        {
            int direction = UnityEngine.Random.Range(1, 5);
            checkGround = moveToScreen;
            if (direction == UP)
            {
                checkGround.y += range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) { moveToScreen = checkGround; break; }


            }
            else if (direction == DOWN)
            {
                checkGround.y -= range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) { moveToScreen = checkGround; break; }


            }
            else if (direction == LEFT)
            {
                checkGround.x -= range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) { moveToScreen = checkGround; break; }


            }
            else if (direction == RIGHT)
            {
                checkGround.x += range;
                if (isGround(checkGround) && !collisionPrevent(checkGround)) {moveToScreen = checkGround; break;}


            }
        }
 
    }

    bool isGround(Vector3 moving){
        int x =  (int) Math.Round((moving.x - Ground.transform.position.x) / range);
        int y =  (int) Math.Round((moving.y - Ground.transform.position.y) / range ); //반올림 소수 오차로인해 5가 4로나오는 경우 
        if(GameObject.Find("/9by9_Ground/"+x+","+y) != null){
            return true;
        }
        return false;
    }



}
