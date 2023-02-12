using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{
    protected int damage = 1;
    protected int skillLevel = 1;
    public GameObject RangeMarker;
    public GameObject skillEffect;

    protected const int LEFT = 1;
    protected const int RIGHT = 2;
    protected const int DOWN = 3;
    protected const int UP = 4;
    protected const int ERROR = 0;
    protected Vector3 mousePosition;
    public float scale = 0.8f;

    const double EPSILON = 0.0001; // 허용오차

    private bool isEqual(float x, float y) // 비교 함수.

    {

        return (((x - EPSILON) < y) && (y < (x + EPSILON)));

    }


    public int getDamage()
    {
        return this.damage;
    }
    public void setDamage(int damage)
    {
        damage = this.damage;
    }


    public int getSkillLevel()
    {
        return this.skillLevel;
    }
    public void setSKillLevel(int skillLevel)
    {
        this.skillLevel = skillLevel;
    }


    public int MousePosition(float range)
    {
        mousePosition = transform.position;
        for (int i = 1; i <= range; i++)
        {
            if (isEqual(mousePosition.x, transform.position.x - i * scale) && isEqual(mousePosition.y, (transform.position.y))) { mousePosition.x -= 1; return LEFT; }  // 캐릭터기준 좌측 클릭시
            else if (isEqual(mousePosition.x, transform.position.x + i * scale) && isEqual(mousePosition.y, transform.position.y)) { mousePosition.x += 1; return RIGHT; } // 캐릭터기준 우측클릭시
            else if (isEqual(mousePosition.x, transform.position.x) && isEqual(mousePosition.y, transform.position.y + i * scale)) { mousePosition.y -= 1; return UP; } //캐릭터기준 아래클릭시
            else if (isEqual(mousePosition.x, transform.position.x) && isEqual(mousePosition.y, transform.position.y - i * scale)) { mousePosition.y += 1; return DOWN; }
          
        }
        return ERROR;
    }

}
