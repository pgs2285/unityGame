using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainCharacter : MonoBehaviour
{
    private int damage = 5;
    public int hp = 3;
    public int currentHp = 3;
    public Sprite brokenHP;
    public Sprite HP;
    

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
    public int getDamage()
    {
        
        return Random.Range(damage-1, damage +2);
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }
    public int getHp()
    {
        return hp;
    }


    void OnCollisionEnter2D(Collision2D enemy){
        if(enemy.collider.CompareTag("enemy")){
            int enemyDamage = enemy.gameObject.GetComponent<Monster_PIG>().getDamage();
            currentHp -= enemyDamage;
            
            
        }
    }

    public GameObject hpbar;
    void HPIndicator(){
        if(currentHp > 0){
            for(int i = 0; i < hp; i++){
                hpbar.transform.GetChild(i).gameObject.SetActive(true);
            }
            for(int i = 0; i< currentHp; i++){
                hpbar.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = HP;
            }
            for(int i = currentHp; i < hp; i++){
                hpbar.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = brokenHP;
            }
        }else if(currentHp <= 0){
            
            Debug.Log("GAME OVER!!");
        }

    }

    void Update(){
        HPIndicator();
    }

}
