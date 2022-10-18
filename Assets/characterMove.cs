using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit=Physics.Raycast(ray.origin,ray.direction,Mathf.Infinity);
            if(hit)
            {
                vec = hit.collider.gameObject;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, vec);
    }
}
