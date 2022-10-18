using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using TMPro;

public class move : MonoBehaviour
{


    Vector3 destination;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶�� ���� ���콺 ��ġ�� Ray�� ���

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);        //�߻���ġ, �߻� ����
            Debug.Log(destination);
            destination = hit.collider.gameObject.transform.position; // ����ڰ� Ŭ���� Ÿ��

            destination.x = Convert.ToInt32(destination.x);
            destination.y = Convert.ToInt32(destination.y);

            transform.position = destination;



        }

    }


}
