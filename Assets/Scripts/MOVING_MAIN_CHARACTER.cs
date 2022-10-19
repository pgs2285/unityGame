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

    public GameObject Ground;
    public Animator mainCharacterAnimator;
    private float moveMap_X=0;
    private float moveMap_Y=0;

    public TextMeshProUGUI cost;

    public float start_x;
    public float start_y;
    const double EPSILON = 0.0001; // 허용오차

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
        if (Convert.ToInt32(cost.text) >= 1) // 턴이 남아있으면 움직여라
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
            if (checkMovablePosition(hit) != ERROR )
            {
                cost.text = (Convert.ToInt32(cost.text) - 1).ToString(); // cost 1감소
                Destination = hit.collider.gameObject.transform.position; // hit.collider.gameObject(부딫힌 gameObject) 의 위치
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
        if (checkMovablePosition(hit) == DOWN) { //캐릭터 아래쪽에 마커표기
            ArrowPositions.y = transform.position.y - range;
            Instantiate(DOWNArrow, ArrowPositions, Quaternion.identity);
        }
        else if (checkMovablePosition(hit) == UP) //캐릭터 위쪽에 마커표기
        {
            ArrowPositions.y = transform.position.y + range;
            Instantiate(UPArrow, ArrowPositions, Quaternion.identity);
        }else if (checkMovablePosition(hit) == LEFT) //캐릭터 왼쪽에 마커표기
        {
            ArrowPositions.x = transform.position.x-range;
            Instantiate(LEFTArrow, ArrowPositions, Quaternion.identity);   
        }else if(checkMovablePosition(hit) == RIGHT) //캐릭터 오른쪽에 마커표기
        {
            ArrowPositions.x = transform.position.x + range;
            Instantiate(RIGHTArrow, ArrowPositions, Quaternion.identity);
        }
        else
        {
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

}
