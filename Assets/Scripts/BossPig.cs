using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPig : crossMovement
{
    // Start is called before the first frame update
    void Start()
    {
        setFullHP(100);
        setHP(100);
    }

    // Update is called once per frame
    void Update()
    {
        pigMovePattern(1);
    }
}
