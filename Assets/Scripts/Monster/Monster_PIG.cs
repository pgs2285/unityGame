using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_PIG : Monster
{
    // Start is called before the first frame update
    Animator pig_animator;

    void Start()
    {
        pig_animator = GetComponent<Animator>();        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.CompareTag("playerAttack"))
        {

            setHP(getHP() - collision.gameObject.GetComponent<basicAttack>().getTotalDamage());

        }
        if (getHP() == 0)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            pig_animator.SetBool("isDeath", true);
            
        }
    }
    
}
