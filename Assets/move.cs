using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update �ѹ��� 
    void Start()
    {
        
    }
    // Update is called once per frame��� ����
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶�� ���� ���콺 ��ġ�� Ray�� ���

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);        //�߻���ġ, �߻� ����, �߻�Ÿ�

            Vector3 vec = hit.collider.gameObject.transform.position;

            transform.position = vec;
        }
        


    }
}
