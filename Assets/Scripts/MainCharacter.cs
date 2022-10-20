using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private int damage = 5;
    private int hp = 3;

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
    public int getDamage()
    {
        Debug.Log("damage = " + damage);
        return damage;
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }
    public int getHp()
    {
        return hp;
    }
}
