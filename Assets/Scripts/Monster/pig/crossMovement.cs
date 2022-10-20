using System.Collections;
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
        moveToScreen.x = range * Random.Range(-4, 4) + Ground.transform.position.x;
        moveToScreen.y = range * Random.Range(-4, 4) + Ground.transform.position.y;
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
            int direction = Random.Range(1,5); // 1~4 까지 이동
            checkGround = moveToScreen;
            if(direction == UP){
                checkGround.y += range;
                moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }else if(direction == DOWN){
                checkGround.y -= range;
                moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }else if(direction == LEFT){
                checkGround.x -= range;
                moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }else if(direction == RIGHT){
                checkGround.x += range;
                moveToScreen = checkGround;
                system.GetComponent<MonsterController>().checkTurn += 1;
                
            }
            break;
        }
    }



}
