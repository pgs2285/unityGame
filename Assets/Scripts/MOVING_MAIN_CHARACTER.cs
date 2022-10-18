using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVING_MAIN_CHARACTER : MonoBehaviour
{   
    private Vector3 Destination;
    public float speed = 6.0f;
    public int mapsize = 8;
    public int range = 1;
    Ray ray;
    RaycastHit2D hit;
    void Start()
    {
        
    }


    void Update()
    {   if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);  //발사위치, 발사 방향, 발사거리
            if(checkMovablePosition(hit))
            Destination = hit.collider.gameObject.transform.position; // hit.collider.gameObject(부딫힌 gameObject) 의 위치
        }

        transform.position = Vector3.MoveTowards(transform.position,Destination,Time.deltaTime*speed); //이동
    }

    bool checkMovablePosition(RaycastHit2D hit){
        Vector3 clickPosition = hit.collider.gameObject.transform.position;
        if(clickPosition.x - range == transform.position.x && clickPosition.y == transform.position.y) return true;  // 캐릭터기준 좌측 클릭시
        else if(clickPosition.x + range == transform.position.x && clickPosition.y == transform.position.y ) return true; // 캐릭터기준 우측클릭시
        else if(clickPosition.x == transform.position.x && clickPosition.y + range == transform.position.y ) return true; //캐릭터기준 아래클릭시
        else if(clickPosition.x == transform.position.x && clickPosition.y - range ==transform.position.y) return true; //캐릭터기준 위 클릭시
        else return false;

    }
}
