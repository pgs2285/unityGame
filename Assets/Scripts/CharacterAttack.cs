using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterMovement characterMovement;
    GameObject MainCharacterLocated;
    public TextMeshProUGUI leftTurn;
    public GameObject AttackableMarker;
    void Start()
    {
        checkMoveable(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        { //오른쪽 마우스 클릭할시
            GetComponent<CharacterMovement>().enabled = true;
            GetComponent<CharacterAttack>().enabled = false;
        }
        if (Input.GetMouseButtonUp(0))
        { // 좌클릭시
            
           

        }
    }

    Vector3 temp;

    public void checkMoveable(int range)
    { // 사용자가 현재 이동가능한 위치를 클릭하였는가?


 
        int x = Convert.ToInt32(transform.position.x);
        int y = Convert.ToInt32(transform.position.y);
        temp = new Vector3(x, y, 0);
        for (int i = 0; i < range; i++)
        {

            try
            {

              // range만큼 이동가능한 범위 지정
                if (leftTurn.text != "0")
                    temp = new Vector3(x+1, y, 0);
                Instantiate(AttackableMarker, temp, Quaternion.identity);

            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }

            try
            {

             // range만큼 이동가능한 범위 지정
                if (leftTurn.text != "0")
                    temp = new Vector3(x-1, y, 0);
                Instantiate(AttackableMarker, temp, Quaternion.identity);

            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }

            try
            {

              // range만큼 이동가능한 범위 지정
                if (leftTurn.text != "0")
                    temp = new Vector3(x, y+1, 0);
                Instantiate(AttackableMarker, temp, Quaternion.identity);


            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }

            try
            {

                if (leftTurn.text != "0")
                    temp = new Vector3(x, y-1, 0);
                Instantiate(AttackableMarker, temp, Quaternion.identity);

            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
            Debug.Log("호출완료");

        }


    }
    GameObject[] trash;
}
