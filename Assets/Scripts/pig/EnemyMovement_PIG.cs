using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement_PIG : MonoBehaviour
{
    bool isMyturn;

    private turnManagement tm;

    public int MapSize = 8;
    public Vector3 destination;
    public int speed = 10;

    int x = Random.Range(0, 9);
    int y = Random.Range(0, 9);

    GameObject temp;

    playerInfo pi;
    void Start()
    {   x = Random.Range(0, 9);
        y = Random.Range(0, 9);
        temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
        destination = temp.transform.position;
        transform.position = destination;
        tm = GameObject.Find("backgroundSettings").GetComponent<turnManagement>();

        tm.enemyNumber += 1; // 모든 적이 이동했나 확인하기 위해 enemyNumber를 올려줌
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        isMyturn = tm.isMyturn;
        if(!isMyturn){// 만약 내턴이 아니면
            PigRush();
            tm.enemiesActionCount += 1; // 행동 완료했다는 +1
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }

    void PigRush(){
        while(true){
            int pattern = Random.Range(0,4);
            if(x >= 4 && pattern == 0){
                x -= 4;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;
                break;
            }else if(y >= 4 && pattern == 1){
                y -= 4;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;

                break;
            }else if(x + 4 < MapSize && pattern == 2){
                x += 4;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;
                break;
            }else if(y + 4 < MapSize && pattern == 3){
                y += 4;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;
                break;
            }

        }
    }




}
