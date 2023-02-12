using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    float h;
    float v;
    public float moveSpeed = 1f;

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2 (h, v) * Time.deltaTime * moveSpeed);
    }
}
