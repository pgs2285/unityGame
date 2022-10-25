using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster:MonoBehaviour
{
    protected int currentHp = 10;
    protected int damage = 1;
    protected int fullHP = 10;
    
    public int getHP()
    {
        return this.currentHp;
    }
    public void setHP(int currentHp)
    {
        this.currentHp = currentHp;
    }

    public int getFullHP()
    {
        return this.fullHP;
    }
    public void setFullHP(int Fullhp)
    {
        this.fullHP = Fullhp;
    }
    public int getDamage(){
        return damage;
    }
    public void setDamage(int damage){
        this.damage = damage;
    }
    public bool collisionPrevent(Vector3 expectedPath)
    {
        bool isOverlap = false;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i].transform.position == expectedPath) isOverlap = true;
        }
  
        return isOverlap;
    }

}
