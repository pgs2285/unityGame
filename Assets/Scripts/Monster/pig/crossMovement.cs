using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class crossMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Ground;
    private Vector3 moveToScreen;
    private float range = 1;
    private int speed = 10;
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
        moveToScreen.z = -2;
        Debug.Log(moveToScreen);
        system = GameObject.FindGameObjectWithTag("system");
        
    }

    void FixedUpdate()
    {   
        if(!(system.GetComponent<MonsterController>().playerTurn)){
            pigMovePattern();
        }
        transform.position = Vector3.MoveTowards(transform.position, moveToScreen, Time.deltaTime * speed);
    }

    void pigMovePattern(){
        while(true){
            int direction = UnityEngine.Random.Range(1,5); // 1~4 까지 이동
            checkGround = moveToScreen;
            if(direction == UP){
                checkGround.y += range;
                if(isGround(checkGround)) moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }else if(direction == DOWN){
                checkGround.y -= range;
                if(isGround(checkGround)) moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }else if(direction == LEFT){
                checkGround.x -= range;
                if(isGround(checkGround)) moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }else if(direction == RIGHT){
                checkGround.x += range;
                if(isGround(checkGround)) moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }
            break;
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
