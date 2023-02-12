using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttack : MonoBehaviour
{
    int playerDamage;
    int damageCoefficient;

    private int totalDamage;

    public void Start()
    {
        playerDamage = MainCharacter.Instance.getDamage();
    }

    public int getTotalDamage()
    {
        damageCoefficient = 1;
        playerDamage =  MainCharacter.Instance.getDamage();
        totalDamage = playerDamage * damageCoefficient;
        
        return this.totalDamage;
    }
}
