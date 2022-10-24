using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MOVING_MAIN_CHARACTER : MonoBehaviour
{   
    private Vector3 Destination;
    public float speed = 6.0f;
    private float range = 1;

    private const int LEFT = 1;
    private const int RIGHT = 2;
    private const int DOWN = 3;
    private const int UP = 4;
    private const int ERROR = 0;

    private float MapRatio = 1;

    public GameObject UPArrow;
    public GameObject DOWNArrow;
    public GameObject LEFTArrow;
    public GameObject RIGHTArrow;

    public GameObject system;

    public GameObject Ground;
    public Animator mainCharacterAnimator;
    private float moveMap_X=0;
    private float moveMap_Y=0;

    public TextMeshProUGUI cost;

    public float start_x;
    public float start_y;
    const double EPSILON = 0.0001; // 허용오차
    public GameObject basicAttack;
    public bool isMyTurn = true;
    public Animator basicAttackAnimator;

    private bool isEqual(float x, float y) // 비교 함수.

    {

        return (((x - EPSILON) < y) && (y < (x + EPSILON)));

    }
    void Start()
    {
                
        moveMap_X = Ground.transform.position.x;
        moveMap_Y = Ground.transform.position.y;
        MapRatio = Ground.transform.localScale.x;

        Destination = new Vector3(moveMap_X + start_x * MapRatio, moveMap_Y + start_y * MapRatio, 0);
        range = range * MapRatio;
    }



    void Update()
    {
        MainCharacter.Instance.HPIndicator();
        
        if (Convert.ToInt32(cost.text) >= 1 && system.GetComponent<MonsterController>().playerTurn) // 턴이 남아있으면 움직여라
        {
            showMoveablePaths();
            clickMove();
        }
        else
        {
            destroyMarker(); //아니면 마커 지우고 못움직이게 해라
        }

        transform.position = Vector3.MoveTowards(transform.position,Destination,Time.deltaTime*speed); //이동
        if (transform.position == Destination)
        {
            mainCharacterAnimator.SetBool("moving", false);
        }
        else
        {
            mainCharacterAnimator.SetBool("moving", true);
        }
    }

    int checkMovablePosition(RaycastHit2D hit){ // 현재는 float 비교를 위해 ToString으로 비교하지만 추후 오차값 정해서 수정하기
        Vector3 clickPosition = hit.collider.gameObject.transform.position;
        //Debug.Log(clickPosition.x.ToString() +" "+ transform.position.x.ToString() +" " + clickPosition.y.ToString() +" " +(transform.position.y - range).ToString());
        if (isEqual(clickPosition.x, transform.position.x - range) && isEqual(clickPosition.y,(transform.position.y))) return LEFT;  // 캐릭터기준 좌측 클릭시
        else if (isEqual(clickPosition.x, transform.position.x + range) && isEqual(clickPosition.y, transform.position.y)) return RIGHT; // 캐릭터기준 우측클릭시
        else if (isEqual(clickPosition.x, transform.position.x) && isEqual(clickPosition.y, transform.position.y + range)) return UP; //캐릭터기준 아래클릭시
        else if (isEqual(clickPosition.x, transform.position.x) && isEqual(clickPosition.y, transform.position.y - range)) return DOWN;
         //캐릭터기준 위 클릭시
        else return 0;

    }

    void clickMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);  //발사위치, 발사 방향, 발사거리
            if(hit){
                if(hit.collider.gameObject.tag == "enemy" && checkMovablePosition(hit) != ERROR)
                {
                    cost.text = (Convert.ToInt32(cost.text) - 1).ToString(); // cost 1감소
                    Instantiate(basicAttack, hit.collider.gameObject.transform.position, Quaternion.identity);
                }
                if (checkMovablePosition(hit) != ERROR && hit.collider.gameObject.tag == "ground")
                {
                    cost.text = (Convert.ToInt32(cost.text) - 1).ToString(); // cost 1감소
                    Destination = hit.collider.gameObject.transform.position; // hit.collider.gameObject(부딫힌 gameObject) 의 위치
                    Destination.z = 0;
                }
            }
        }
    }
    Vector3 ArrowPositions;
    void showMoveablePaths()
    {   
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        destroyMarker(); // 이전 마커 지워주고
        ArrowPositions = transform.position;
        if(hit){
            if (hit.collider.gameObject.tag == "ground")
            {
                if (checkMovablePosition(hit) == DOWN)
                { //캐릭터 아래쪽에 마커표기
                    ArrowPositions.y = transform.position.y - range;
                    Instantiate(DOWNArrow, ArrowPositions, Quaternion.identity);
                }
                else if (checkMovablePosition(hit) == UP) //캐릭터 위쪽에 마커표기
                {
                    ArrowPositions.y = transform.position.y + range;
                    Instantiate(UPArrow, ArrowPositions, Quaternion.identity);
                }
                else if (checkMovablePosition(hit) == LEFT) //캐릭터 왼쪽에 마커표기
                {
                    ArrowPositions.x = transform.position.x - range;
                    Instantiate(LEFTArrow, ArrowPositions, Quaternion.identity);
                }
                else if (checkMovablePosition(hit) == RIGHT) //캐릭터 오른쪽에 마커표기
                {
                    ArrowPositions.x = transform.position.x + range;
                    Instantiate(RIGHTArrow, ArrowPositions, Quaternion.identity);
                }
                else
                {
                }
            }
        }
    }

    GameObject[] trash;
    void destroyMarker()
    {
        trash = GameObject.FindGameObjectsWithTag("ArrowMarker");
        foreach (GameObject trash in trash)
        {
            Destroy(trash);
        }
    }



    void OnCollisionEnter2D(Collision2D enemy){
        if(enemy.collider.CompareTag("enemy")){// 적과 충돌시
            while(true){
                int direction = UnityEngine.Random.Range(1,5); // 넉백 위치 결정
                Debug.Log("방향"+direction + " range:" + range);
                Vector3 tempVec = Destination;
                if(direction == UP){
                    tempVec.y = Destination.y + range;
                    if(isGround(tempVec)) {Destination.y +=range; break;} 
                }else if(direction == DOWN){
                    tempVec.y = Destination.y - range;
                    if(isGround(tempVec)) {Destination.y -=range; break;}
                }else if(direction == LEFT){
                    tempVec.x = Destination.x - range;
                    if(isGround(tempVec)) {Destination.x -=range; break;}
                }else if(direction == RIGHT){
                    tempVec.x = Destination.x + range;
                    if(isGround(tempVec)) {Destination.x +=range; break;}
                }
                
            }
            int enemyDamage = enemy.gameObject.GetComponent<Monster_PIG>().getDamage();
            MainCharacter.Instance.setCurrentHP(MainCharacter.Instance.getCurrentHP() - enemyDamage);
            Debug.Log("충돌후 currentHP :" + MainCharacter.Instance.getCurrentHP());

        }

    }

    bool isGround(Vector3 moving){
        GameObject Ground = GameObject.FindGameObjectWithTag("groundPrefs");
        int x =  (int) Math.Round((moving.x - Ground.transform.position.x) / range);
        int y =  (int) Math.Round((moving.y - Ground.transform.position.y) / range ); //반올림 소수 오차로인해 5가 4로나오는 경우 
        Debug.Log("Moving.y = "+moving.y +" Ground.transform.y = " + Ground.transform.position.y + " range = " + range);
        Debug.Log("/9by9_Ground/"+ x +","+y);
        if(GameObject.Find("/9by9_Ground/"+x+","+y) != null){
            return true;
        }
        return false;
    }


}
