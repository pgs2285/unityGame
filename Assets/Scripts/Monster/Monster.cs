using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster:MonoBehaviour
{
    protected int hp = 10;
    protected int damage = 1;
    
    public int getHP()
    {
        return this.hp;
    }
    public void setHP(int hp)
    {
        this.hp = hp;
    }
    public int getDamage(){
        return damage;
    }
    public void setDamage(int damage){
        this.damage = damage;
    }
}
