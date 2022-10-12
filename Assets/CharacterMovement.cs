using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject ourObject;

    // Update is called once per frame
    void Start()
    {
        Instantiate(mainCharacter, new Vector3(0,0,-1), Quaternion.identity); // MainCharacter 생성하기 매개변수(생성객체, 위치, 회전값);
        // 즉 0,0,-1 에 기본 회전값을 가지고 생성된다
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit,2f))
        {
            ourObject=hit.collider.gameObject;
            Debug.Log ("object that was hit: "+ourObject);
        }
    
    }
}
