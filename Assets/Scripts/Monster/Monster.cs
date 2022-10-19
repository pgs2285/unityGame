using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster:MonoBehaviour
{
    protected int hp = 10;
    
    public int getHP()
    {
        return hp;
    }
    public int setHP(int hp)
    {
        return this.hp = hp;
    }
}
