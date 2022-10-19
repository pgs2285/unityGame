using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using TMPro;

public class CharacterMovement : MonoBehaviour
{


    Vector3 destination;

    void Start()
    {  

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);        //발사위치, 발사 방향
            Debug.Log(destination);
            destination = hit.collider.gameObject.transform.position; // 사용자가 클릭한 타일

            destination.x = Convert.ToInt32(destination.x);
            destination.y = Convert.ToInt32(destination.y);

            transform.position = destination;

            

        }

    }
  

}
