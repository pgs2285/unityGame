using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class pigMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Ground;
    private Vector3 moveToScreen;
    private float range = 1;
    private int speed = 10;

    void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("groundPrefs");
        range = range * Ground.transform.localScale.x;
        moveToScreen.x = range * Random.Range(-4, 5);
        moveToScreen.y = range * Random.Range(-4, 5);

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveToScreen, Time.deltaTime * speed);
    }
}
