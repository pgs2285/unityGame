using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class monsterHPbar : MonoBehaviour
{
    [SerializeField] Slider hpbar = null;
    List<Transform> enemyTransforms = new List<Transform>();
    List<Slider> hpBarList = new List<Slider>();

    Camera m_cam;


    GameObject backgroundSetting = GameObject.Find("backgroundSettings");

    void Start()
    {
        GameObject backgroundSetting = GameObject.Find("backgroundSettings");

        GameObject[] targetEnemy = backgroundSetting.GetComponent<MonsterController>().Monster;
        Debug.Log(targetEnemy.Length);
        Destroy(targetEnemy[0]);
        for (int i = 0; i < targetEnemy.Length; i++)
        {
            enemyTransforms.Add(targetEnemy[i].transform);
            Slider t_hpnar = Instantiate(hpbar, targetEnemy[i].transform.position, Quaternion.identity, transform);
            hpBarList.Add(t_hpnar);
        }
    }

    void Update()
    {   

      

        for (int i = 0; i < enemyTransforms.Count; i++)
        {
            
            hpBarList[i].transform.position = m_cam.WorldToScreenPoint(enemyTransforms[i].position + new Vector3(0, 0.5f, 0));
        }
    }
    public void SetMaxHealth(int health)
    {   
        hpbar.maxValue = health;
        hpbar.value = health;
    }

    IEnumerable waitTime()
    {
        yield return new WaitForSeconds(3.5f);
    }
}
