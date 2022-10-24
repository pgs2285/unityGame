using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class turnManagement : MonoBehaviour
{      
    public bool isMyturn = true;
    
    public GameObject gameoverPanel;

    public int enemiesActionCount = 0;

    public int enemyNumber = 0;

    public TextMeshProUGUI leftTurn;

    private CharacterMovement cm;

    private void Start()
    {
        cm = GameObject.Find("MainCat").GetComponent<CharacterMovement>();
        
    }
    void Update()
    {

        if(enemiesActionCount  >= enemyNumber)
        {
            isMyturn = true; // �� �̵� ��
            leftTurn.text = "5";
 
            enemiesActionCount = 0;
        }
        if (PlayerPrefs.GetInt("nowHP") == 0)
        {
            gameoverPanel.SetActive(true);
        }
    }

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

}

