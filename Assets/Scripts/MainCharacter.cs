using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainCharacter : Singleton<MainCharacter>
{
    private int damage = 5;
    private int hp = 6;
    private int currentHp = 6;
    public Sprite brokenHP;
    public Sprite HP;
    private int canNumber = 0;
    

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
    public int getDamage()
    {
        
        return Random.Range(damage-2, damage +2);
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }
    public int getHp()
    {
        return hp;
    }
    public int getCurrentHP()
    {
        return currentHp;
    }

    public void setCurrentHP(int currentHP)
    {
        this.currentHp = currentHP;
    }
    public int getCanNumber()
    {
        return canNumber;
    }
    public void setCanNumber(int canNumber)
    {
        this.canNumber = canNumber;
    }

    
    public void HPIndicator(){
        GameObject hpbar = GameObject.FindGameObjectWithTag("hpIndicator");
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


}
