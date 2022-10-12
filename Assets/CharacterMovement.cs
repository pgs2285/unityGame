using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject playerTile;

    string objectName;
    Vector3 destination;
    

    // Update is called once per frame
    void Start()
    {
        // Instantiate(mainCharacter, new Vector3(0,0,-1), Quaternion.identity); // MainCharacter 생성하기 매개변수(생성객체, 위치, 회전값);
        // 즉 0,0,-1 에 기본 회전값을 가지고 생성된다
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) { // 마우스가 클릭되면 0,1,2 왼쪽,오른쪽,휠
            CastRay();
            moveableLocation();
        }  
    
    }

        void CastRay() 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
            //                                      발사위치, 발사 방향, 발사거리
            //가상의 “레이저 빔”을 원점에서부터 레이에 따라 씬 안의 콜라이더에 충돌할 때까지 보냄,  RaycastHit 오브젝트의 충돌된 점에 대한 정보를 반환합니다. 
            
            if (hit.collider !=null) {
                destination = hit.collider.gameObject.transform.position; 
                playerTile = hit.collider.gameObject;
                // 클릭한 좌표를 목적지로
                destination.z = -1;  
                // Character가 앞에 있어야하므로 z 위치는 -1 
                mainCharacter.transform.position = destination;
                //캐릭터 목적지로 이동
                
            }
        }


        void moveableLocation(){
            string[] a =  playerTile.name.Split(",");
    
            Debug.Log(a[0] +" "+ a[1]);
        }

}
