using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

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
    public int deadMonsterNumber = 0;
    public bool playerTurn;
    public TextMeshProUGUI monsterExplain;

    private int coroutineCount = 0;

    void Start()
    {
        blankImage = monsterImage.sprite;
        StartCoroutine(generateDelay());

    }

    IEnumerator generateDelay()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < Monster.Length; i++)
        {
            Instantiate(Monster[i]);

            blankImage = monsterImage.sprite;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkTurnEnd();
        IndicateImage();

        if (!(playerTurn))
        {
            
            GameObject[] monsterList = GameObject.FindGameObjectsWithTag("enemy");
            if (coroutineCount == 0)
            {
                StartCoroutine(moveOrder(monsterList));
                coroutineCount++;
            }
        }
    }

    IEnumerator moveOrder(GameObject[] monsterList)
    {
        Debug.Log("Coroutine Start");
        foreach (GameObject monster in monsterList)
        {
            monster.GetComponent<crossMovement>().pigMovePattern();
            checkTurn += 1;
            yield return new WaitForSeconds(0.4f);
            
            
        }
        checkTurn = 0;
        coroutineCount = 0;
    }

    void IndicateImage()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);  //발사위치, 발사 방향, 발사거리
        if (hit)
        {
            if (hit.collider.gameObject.tag == "enemy")
            {

                monsterImage.sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite; // 돼지 UI에 띄우기
                monsterMoveIndicator.sprite = hit.collider.gameObject.GetComponent<crossMovement>().moveIndicator;
                monsterExplain.text = "지능이 떨어져 주변을 인식하지 못해!";
            }
            else
            {
                monsterImage.sprite = blankImage;
                monsterMoveIndicator.sprite = blankImage;
                monsterExplain.text = "";

            }
        }
    }
    public int checkTurn = 0;


    void checkTurnEnd()
    {
        
        if (checkTurn == GameObject.FindGameObjectsWithTag("enemy").Length && playerTurn == false)
        { //만약 monster들이 전부다 turn을 마쳤고, 내 턴이 종료된 상태라면

            playerTurn = true;
            cost.text = "5";
                
        }
        
    }


    public void PlayerTurnSet()
    {
        playerTurn = false;
    }



}
