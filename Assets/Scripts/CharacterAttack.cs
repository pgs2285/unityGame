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
        { //������ ���콺 Ŭ���ҽ�
            GetComponent<CharacterMovement>().enabled = true;
            GetComponent<CharacterAttack>().enabled = false;
        }
        if (Input.GetMouseButtonUp(0))
        { // ��Ŭ����
            
           

        }
    }

    Vector3 temp;

    public void checkMoveable(int range)
    { // ����ڰ� ���� �̵������� ��ġ�� Ŭ���Ͽ��°�?


 
        int x = Convert.ToInt32(transform.position.x);
        int y = Convert.ToInt32(transform.position.y);
        temp = new Vector3(x, y, 0);
        for (int i = 0; i < range; i++)
        {

            try
            {

              // range��ŭ �̵������� ���� ����
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

             // range��ŭ �̵������� ���� ����
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

              // range��ŭ �̵������� ���� ����
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
            Debug.Log("ȣ��Ϸ�");

        }


    }
    GameObject[] trash;
}
