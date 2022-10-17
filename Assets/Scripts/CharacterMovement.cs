using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    
    public int range = 1; // 이동가능 길이
    bool clickable = false;
    public float speed = 10.0f;
    // Update is called once per frame
    public GameObject MainCharacterLocated; // 캐릭터의 시작위치 등록
    public GameObject MoveableMarker;
    Vector3 destination = new Vector3(0,-4,1);
    public Animator moveAnimator; 
    public TextMeshProUGUI leftTurn;

    private int turn;

    int state  = 1;
    void Start()
    {   DestroyMoveableTile();
        moveAnimator.SetBool("moving",false);
        destination = MainCharacterLocated.transform.position;
        MainCharacterLocated.transform.position = destination;
        // checkMoveable(range);
        // Instantiate(mainCharacter, new Vector3(0,0,-1), Quaternion.identity); // MainCharacter 생성하기 매개변수(생성객체, 위치, 회전값);
        
    }

    void Update()
    {   

        switch(state){
            case 1: // 평범한 이동 range값 조정으로 상하좌우 범위 증가 가능
            basicMove();
            break;
        }

    }
    
    void basicMove(){
        if (Input.GetMouseButtonDown(0) && clickable){   

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);        //발사위치, 발사 방향, 발사거리


            //가상의 “레이저 빔”을 원점에서부터 레이에 따라 씬 안의 콜라이더에 충돌할 때까지 보냄,  RaycastHit 오브젝트의 충돌된 점에 대한 정보를 반환합니다. 
            if(isMoveable(hit, range)){ // 범위를 넘어서 클릭하진 않았나 체크
                destination = hit.collider.gameObject.transform.position; // 사용자가 클릭한 타일

                MainCharacterLocated = hit.collider.gameObject;

                clickable = false; // 이동중에 다시 클릭할 경우 움직이지 않게 하기위함
            }

        }

        if(transform.position != destination){ //완전히 이동될때까지
            DestroyMoveableTile();
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            moveAnimator.SetBool("moving",true);
        }else {
            if(!clickable) checkMoveable(range); // 한번만 찍게 메모리 낭비 X
            clickable = true; // 이동완료하면 다음으로 이동가능하게

            moveAnimator.SetBool("moving",false);
        }
    }

    GameObject temp;
    public void checkMoveable(int range){ // 사용자가 현재 이동가능한 위치를 클릭하였는가?

       
        string[] nowLocation = MainCharacterLocated.name.Split(",");
        int x = Convert.ToInt32(nowLocation[0]);
        int y = Convert.ToInt32(nowLocation[1]);
        for(int i = 0; i < range; i++){
        
            try{
                
                temp = GameObject.Find("/9by9_Ground/" + (x + i + 1) + "," + (y)); // range만큼 이동가능한 범위 지정
                if(leftTurn.text != "0") 
                    Instantiate(MoveableMarker, temp.transform.position, Quaternion.identity);

            }catch(Exception e){
                Debug.Log(e.ToString());
            }

            try{

                temp = GameObject.Find("/9by9_Ground/" + (x - i - 1) + "," + (y)); // range만큼 이동가능한 범위 지정
                if (leftTurn.text != "0") 
                    Instantiate(MoveableMarker, temp.transform.position, Quaternion.identity);

            }catch(Exception e){
                Debug.Log(e.ToString());
            }

            try{

                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y + i + 1)); // range만큼 이동가능한 범위 지정
                if (leftTurn.text != "0")
                    Instantiate(MoveableMarker, temp.transform.position, Quaternion.identity);
                

            }catch(Exception e){
                Debug.Log(e.ToString());
            }

            try{

                temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y - i - 1)); // range만큼 이동가능한 범위 지정
                if (leftTurn.text != "0")
                    Instantiate(MoveableMarker, temp.transform.position, Quaternion.identity);

            }catch(Exception e){
                Debug.Log(e.ToString());
            }


        }


    }
    GameObject[] trash;
    void DestroyMoveableTile(){
        trash = GameObject.FindGameObjectsWithTag("marker");
        foreach(GameObject trash in trash)
        {
            Destroy(trash);
        }
    }

    bool isMoveable(RaycastHit2D hit,int range){ // 이동가능한 좌표를 클릭했는가 체크
        int prev_x, prev_y, clicked_x, clicked_y;

        try{
            string[] prevAxis = MainCharacterLocated.name.Split(",");
            string[] clickedAxis = hit.collider.gameObject.name.Split(",");
            
            clicked_x = Convert.ToInt32(clickedAxis[0]);
            clicked_y = Convert.ToInt32(clickedAxis[1]);
            prev_x = Convert.ToInt32(prevAxis[0]);
            prev_y = Convert.ToInt32(prevAxis[1]);

        }catch(Exception e){
            Debug.Log(e.ToString());
            return false;
        }
        for(int i = 1; i <= range; i++){
            if (((prev_x - clicked_x == i) || (prev_x - clicked_x == -i)) && (prev_y == clicked_y) && leftTurn.text != "0" )
            {
                turn = Convert.ToInt32(leftTurn.text);
                turn -= 1;
                leftTurn.text = turn.ToString();
                return true;
            }
            else if (((prev_y - clicked_y == i) || prev_y - clicked_y == -i) && (prev_x == clicked_x) && leftTurn.text != "0")
            {
                turn = Convert.ToInt32(leftTurn.text);
                turn -= 1;
                leftTurn.text = turn.ToString();
                return true;
            }
        }
        return false;
    }
}
