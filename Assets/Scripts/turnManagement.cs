using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManagement : MonoBehaviour
{      
    public bool isMyturn = true;

    public GameObject gameoverPanel;
    
    public void TurnEndButton(){
        isMyturn = false;
    }
    public bool getIsMyTurn()
    {
        return isMyturn;
    }

    public void setIsMyTurn(bool turn){
        isMyturn = turn;
    }
    void Update(){
        if(PlayerPrefs.GetInt("nowHP") == 0){
            gameoverPanel.SetActive(true);
        }
    }
}

