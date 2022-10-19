using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI cost;
    public GameObject[] Monster;
    // public GameObject PigIndicator;
    public Image monsterImage; //UI Canvas 에 띄울 image 변수
    public Image monsterMoveIndicator;
    private Sprite blankImage;
    public GameObject player;

    public bool playerTurn;

    void Start()
    {   
        for(int i = 0; i < Monster.Length; i++)
        {
          Instantiate(Monster[i]);
          
          blankImage = monsterImage.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {   checkTurnEnd();
        IndicateImage();
    }

    void IndicateImage(){
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);  //발사위치, 발사 방향, 발사거리
      if(hit.collider.gameObject.tag == "enemy"){
        
        monsterImage.sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite; // 돼지 UI에 띄우기
        monsterMoveIndicator.sprite = hit.collider.gameObject.GetComponent<crossMovement>().moveIndicator;
      }else{
        monsterImage.sprite = blankImage;
        monsterMoveIndicator.sprite = blankImage;
      }
    }
    public int checkTurn = 0;


    void checkTurnEnd(){
      for(int i = 0; i< Monster.Length; i++){

        if(checkTurn >= Monster.Length && playerTurn == false){ //만약 monster들이 전부다 turn을 마쳤고, 내 턴이 종료된 상태라면
          playerTurn = true;
          cost.text = "5";
          checkTurn = 0;
        }
      }
    }


    public void PlayerTurnSet()
    {
      playerTurn = false;
    }



}
