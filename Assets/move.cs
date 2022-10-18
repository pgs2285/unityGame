using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update 한번만 
    void Start()
    {
        
    }
    // Update is called once per frame계속 돌음
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로 부터 마우스 위치에 Ray를 쏜다

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);        //발사위치, 발사 방향, 발사거리

            Vector3 vec = hit.collider.gameObject.transform.position;

            transform.position = vec;
        }
        


    }
}
