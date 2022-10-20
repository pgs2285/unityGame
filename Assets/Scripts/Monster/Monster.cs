using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster:MonoBehaviour
{
    protected int hp = 10;
    
    public int getHP()
    {
        return this.hp;
    }
    public void setHP(int hp)
    {
        this.hp = hp;
    }
}
