using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerInfo : MonoBehaviour
{   
    public int nowHP,fullHP,Attack;
    GameObject hp;

    // Start is called before the first frame update
    void Start() 
    /* 첫화면 다음부턴  Update만 사용해야할듯? 
    이건 호출될때마다 이전 스테이지 상관없이 1칸으로 고정*/
    {
        // nowHP = PlayerPrefs.GetInt("nowHP", 2);
        // fullHP = PlayerPrefs.GetInt("HP", 3);
        // PlayerPrefs.SetInt("Attack", 5);
        // if(nowHP < 1){ //사망시 초기화 추후 다시시작 함수에 삽입예정
        //     PlayerPrefs.SetInt("nowHP", 2); 
        //     fPlayerPrefs.SetInt("HP", 3); 
        // }

        PlayerPrefs.SetInt("nowHP", 1); 
        PlayerPrefs.SetInt("HP", 1); 

    }

    // Update is called once per frame
    void Update()
    {
        nowHP = PlayerPrefs.GetInt("nowHP");
        fullHP = PlayerPrefs.GetInt("HP");
        for (int i = 0; i < fullHP; i++){
            hp = GameObject.Find("/UICanvas/HPIndicator/HP" + (i + 1));
            hp.SetActive(true);
        }
        for(int i = fullHP; i >nowHP ; i--){
            hp = GameObject.Find("/UICanvas/HPIndicator/HP" + (i));
            hp.SetActive(false);
        }
        if(nowHP == 0){

        }
    }
}
