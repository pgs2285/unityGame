using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public GameObject mainCharacter; // 플레이어 게임 오브젝트
    public GameObject playerTile; // 플레이어의 시작 타일
    private GameObject clickedTile;
    public bool isMoving = false;
    //public GameObject moveableTile;
    string groundAxis; //이동가능 위치를 표기해주기 위한 변수
    private int player_x, player_y, clicked_x, clicked_y;
    Vector3 destination;
    public int range = 1; // 이동가능 길이
    bool ismove = true;
    

    // Update is called once per frame
    void Start()
    {
        // Instantiate(mainCharacter, new Vector3(0,0,-1), Quaternion.identity); // MainCharacter 생성하기 매개변수(생성객체, 위치, 회전값);
        // 즉 0,0,-1 에 기본 회전값을 가지고 생성된다
    }

    void Update()
    {
        if (ismove)
        {
            string[] previousAxis = playerTile.name.Split(",");
            player_x = Convert.ToInt32(previousAxis[0]);
            player_y = Convert.ToInt32(previousAxis[1]);
            showRoute(player_x, player_y, range);
            ismove = false;
        }
        
        if (Input.GetMouseButtonDown(0)) { // 마우스가 클릭되면 0,1,2 왼쪽,오른쪽,휠
            basicMovement(player_x, player_y, range); // 어떠한 효과도 받지않은 기본 움직임 (상하좌우만 구현)  
            ismove = true;
        }  
    
    }

    void basicMovement(int prev_x, int prev_y,int range){ // range 는 상하좌우 각각 이동가능 길이 

        string[] previousAxis = playerTile.name.Split(",");// 이전의 캐릭터 위치 좌표값을 저장하는 previousAxis[0], previousAxis[1]


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);        //발사위치, 발사 방향, 발사거리
        //가상의 “레이저 빔”을 원점에서부터 레이에 따라 씬 안의 콜라이더에 충돌할 때까지 보냄,  RaycastHit 오브젝트의 충돌된 점에 대한 정보를 반환합니다. 

        clickedTile = hit.collider.gameObject; // 사용자가 클릭한 타일
        string[] clickedAxis = clickedTile.name.Split(","); /// 사용자가 클릭한 파일 좌표 split


        try // 연산을 위해 - 작업
        {
            prev_x = Convert.ToInt32(previousAxis[0]);
            prev_y = Convert.ToInt32(previousAxis[1]);
            clicked_x = Convert.ToInt32(clickedAxis[0]);
            clicked_y = Convert.ToInt32(clickedAxis[1]);
        }catch (Exception e){
           Debug.LogError(e.ToString());
        }

        if (((prev_x - clicked_x == range)|| (prev_x - clicked_x == -range)) && (prev_y == clicked_y) ) // 플레이어 기준 왼쪽 혹은 오른쪽 클릭했을시
        {
            destination = hit.collider.gameObject.transform.position;            // 클릭한 좌표를 목적지로
            destination.z = -1;            // Character가 앞에 있어야하므로 z 위치는 -1 
            mainCharacter.transform.position = destination;//캐릭터 목적지로 이동
            playerTile = clickedTile;
        }
        else if(((prev_y-clicked_y == range)|| prev_y - clicked_y == - range) && (prev_x == clicked_x))// 플레이어 기준 위 혹은 아래 클릭했을시
        {
            destination = hit.collider.gameObject.transform.position;            // 클릭한 좌표를 목적지로
            destination.z = -1;            // Character가 앞에 있어야하므로 z 위치는 -1 
            mainCharacter.transform.position = destination;//캐릭터 목적지로 이동
            playerTile = clickedTile;
        }
        else
        {
            Debug.Log("이동할 수 없는 좌표입니다");
        }

    }

    public GameObject moveableMarker;
    private GameObject temp;
    Vector3 markerLocate;
    GameObject[] trash; 
    List<GameObject> markerList = new List<GameObject>();
    public void showRoute(int x, int y, int range)
    {
        trash = GameObject.FindGameObjectsWithTag("marker");
        foreach(GameObject trash in trash)
        {
            Destroy(trash);
        }
        // Instantiate(mainCharacter, new Vector3(0,0,-1), Quaternion.identity); // MainCharacter 생성하기 매개변수(생성객체, 위치, 회전값);
        try
        {  
            temp = GameObject.Find("/9by9_Ground/" + (x + range) + "," + (y));
            markerLocate = temp.transform.position;
            markerLocate.z = -0.5f;
            Instantiate(moveableMarker, markerLocate, Quaternion.identity);

        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }

        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x - range) + "," + (y));
            markerLocate = temp.transform.position;
            markerLocate.z = -0.5f;
            Instantiate(moveableMarker, markerLocate, Quaternion.identity);

        }catch(Exception e)
        {
            Debug.Log(e.ToString());
        }

        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y + range));
            markerLocate = temp.transform.position;
            markerLocate.z = -0.5f;
            Instantiate(moveableMarker, markerLocate, Quaternion.identity);

        }catch(Exception e)
        {
            Debug.Log(e.ToString());
        }

        try
        {
            temp = GameObject.Find("/9by9_Ground/" + (x) + "," + (y - range));
            markerLocate = temp.transform.position;
            markerLocate.z = -0.5f;
            Instantiate(moveableMarker, markerLocate, Quaternion.identity);
        }catch(Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

}
