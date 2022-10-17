using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement_PIG : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI leftTurn;
    public bool isMyturn;

    private turnManagement tm;
    private CharacterMovement cm;
    public int MapSize = 8;
    public Vector3 destination;
    public int speed = 10;

    int x = Random.Range(0, 9);
    int y = Random.Range(0, 9);
    public int Damage = 1;
    GameObject temp;

    playerInfo pi;
    void Start()
    {   x = Random.Range(0, 9);
        y = Random.Range(0, 9);
        temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y)); // range만큼 이동가능한 범위 지정
        destination = temp.transform.position;
        transform.position = destination;
    }

    // Update is called once per frame
    void Update()
    {   tm = GameObject.Find("backgroundSettings").GetComponent<turnManagement>();
        cm = GameObject.Find("MainCat").GetComponent<CharacterMovement>();
        isMyturn = tm.isMyturn;
        if(!isMyturn){// 만약 내턴이 아니면
            PigRush();
            tm.isMyturn = true; // 적 이동 끝
            leftTurn.text = "5";
            cm.checkMoveable(1);
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

void OnCollisionEnter2D(Collision2D collision) // 충돌했는가?
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("충돌햇음다");
            pi = GameObject.Find("MainCat").GetComponent<playerInfo>();
            pi.nowHP -= Damage;
            PlayerPrefs.SetInt("nowHP",pi.nowHP);
            Debug.Log(PlayerPrefs.GetInt("nowHP").ToString());
        }
    }

    void enemyLocation(int x, int y){
        
    }

}
