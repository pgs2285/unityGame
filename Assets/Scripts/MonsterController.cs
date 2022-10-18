using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Monster;

    
    void Start()
    {   
        for(int i = 0; i < Monster.Length; i++)
        {
          Instantiate(Monster[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
