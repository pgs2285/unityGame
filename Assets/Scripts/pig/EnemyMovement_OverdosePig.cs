using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnemyMovement_OverdosePig : MonoBehaviour
{
    // Start is called before the first frame update
    bool isMyturn;

    private turnManagement tm;

    public int MapSize = 8;
    public Vector3 destination;
    public int speed = 10;

    int x = UnityEngine.Random.Range(0, 9);
    int y = UnityEngine.Random.Range(0, 9);

    GameObject temp;

    public GameObject OverdosePig_skill;


    void Start()
    {   x = UnityEngine.Random.Range(0, 9);
        y = UnityEngine.Random.Range(0, 9);
        temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
        destination = temp.transform.position;
        transform.position = destination;
        tm = GameObject.Find("backgroundSettings").GetComponent<turnManagement>();

        tm.enemyNumber += 1; // 모든 적이 이동했나 확인하기 위해 enemyNumber를 올려줌
    }

    // Update is called once per frame
    GameObject[] trash;
    void FixedUpdate()
    {  
        isMyturn = tm.isMyturn;
        if(!isMyturn){// 만약 내턴이 아니면
            PigRush();
            tm.enemiesActionCount += 1; // 행동 완료했다는 +1
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        if(transform.position == destination)
        {
            
            trash = GameObject.FindGameObjectsWithTag("enemyAttack");
            foreach (GameObject trash in trash)
            {
                Destroy(trash);
            }

        }
    }

    void PigRush(){
        //이하 try catch 문은 독 범위 표시 여기부터
        overdoseSkill();


        while (true){
            int pattern = UnityEngine.Random.Range(0,4);
            if(x >= 1 && pattern == 0){
                x -= 1;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;
                break;
            }else if(y >= 1 && pattern == 1){
                y -= 1;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;

                break;
            }else if(x + 1 < MapSize && pattern == 2){
                x += 1;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;
                break;
            }else if(y + 1 < MapSize && pattern == 3){
                y += 1;
                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
                destination = temp.transform.position;
                break;
            }

        }




    }

    void overdoseSkill()
    {
        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x + 1) + "," + (y));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x - 1) + "," + (y));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y + 1));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y - 1));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x + 1) + "," + (y + 1));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x + 1) + "," + (y - 1));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x - 1) + "," + (y - 1));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x - 1) + "," + (y + 1));
            Instantiate(OverdosePig_skill, temp.transform.position, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }


}
