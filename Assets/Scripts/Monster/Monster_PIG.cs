using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_PIG : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "playerAttack")
        {
            setHP(getHP());
        }
    }
}
