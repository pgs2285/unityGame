using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster_PIG : Monster
{
    // Start is called before the first frame update
    protected Animator pig_animator;
    public GameObject floatingDamage;
    //public GameObject MonsterhpBar;
    //private Vector3 MonsterHpSize;
    //GameObject monsterHP = null;
    void Start()
    {
        pig_animator = GetComponent<Animator>();

        //MonsterHpSize = MonsterhpBar.transform.localScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        MainCharacter character = collision.gameObject.GetComponent<MainCharacter>();

        if (collision.collider.CompareTag("playerAttack"))
        {
            int damage = collision.gameObject.GetComponent<basicAttack>().getTotalDamage();
            setHP(getHP() - damage);
            //if (((float)getHP() / (float)getFullHP()) > 0) MonsterHpSize.x *= ((float)getHP() / (float)getFullHP());
            //else MonsterHpSize.x = 0;
            //MonsterHpSize.y = 0.1f;
       
            //MonsterhpBar.transform.localScale = MonsterHpSize;

            floatingDamage.GetComponent<TextMesh>().text = damage.ToString();
            floatingDamage.GetComponent<MeshRenderer>().sortingOrder = 3;


            Instantiate(floatingDamage, transform.position, Quaternion.identity);
            
            Debug.Log("들어온 대미지: "+ damage + " 남은체력:"+getHP());
            if (getHP() <= 0)
            {   
                Destroy(gameObject.GetComponent<BoxCollider2D>());
 
                pig_animator.SetBool("isDeath", true);
                GameObject.Find("backgroundSettings").GetComponent<MonsterController>().deadMonsterNumber += 1;
            }

        }
        
    }



}
