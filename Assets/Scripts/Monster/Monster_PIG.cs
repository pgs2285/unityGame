using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_PIG : Monster
{
    // Start is called before the first frame update
    protected Animator pig_animator;
    public GameObject floatingDamage;
    void Start()
    {
        pig_animator = GetComponent<Animator>();        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.CompareTag("playerAttack"))
        {
            int damage = collision.gameObject.GetComponent<basicAttack>().getTotalDamage();
            setHP(getHP() - damage);
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
