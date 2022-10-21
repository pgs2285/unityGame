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
        playerDamage = GameObject.Find("MainCat").GetComponent<MainCharacter>().getDamage();
    }

    public int getTotalDamage()
    {
        damageCoefficient = 1;
        playerDamage = GameObject.Find("MainCat").GetComponent<MainCharacter>().getDamage();
        totalDamage = playerDamage * damageCoefficient;
        
        return this.totalDamage;
    }
}
