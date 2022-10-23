using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestOpen : MonoBehaviour
{
    public GameObject[] dropItemList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))// 플레이어가 상자 접촉시
        {
             // 아이템 드랍 코드
             for (int i = 0; i < dropItemList.Length; i++)
             {
                float x = Random.Range(-1.0f, 1.1f);
                float y = Random.Range(-1.0f, 1.1f);
                if (dropItemList[i].name == "Can") {
                    for (int j = 0; j < Random.Range(1, 4); j++)
                    {
                        Instantiate(dropItemList[i], transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        x = Random.Range(-1.0f, 1.1f);
                        y = Random.Range(-1.0f, 1.1f);
                    }
                }
                else if (dropItemList[i].name == "hpPot0  ion" && Percent(55))  { Instantiate(dropItemList[i], transform.position + new Vector3(x, y, 0), Quaternion.identity); } // 15% 확률로 생성
                else if(dropItemList[i].name.Contains("Accesary") && Percent(5)) { Instantiate(dropItemList[i], transform.position + new Vector3(x, y, 0), Quaternion.identity); } //5% 확률로 생성
             }
            Destroy(gameObject);
        }
    }

    private bool Percent(int percent)
    {
        int num = Random.Range(0, 100);
        for(int i =0; i< percent; i++)
        {
            int winning = Random.Range(0, 100);
            if (winning == num) return true; // 당첨
        }
        return false;

        
    }

}
