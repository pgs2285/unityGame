using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawSkill : skill
{

    Vector3 _90 = new Vector3(0, 0, 90);

    void Start()
    {
        setDamage(1);    
    }

    GameObject[] trash;
    void destroyMarker()
    {
        trash = GameObject.FindGameObjectsWithTag("skillRangeMarker");
        foreach (GameObject trash in trash)
        {
            Destroy(trash);
        }
    }

    void Update()
    {
        destroyMarker();

    }


}
