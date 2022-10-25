using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string stage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.CompareTag("Player"))
        {
            
            // 다음 스테이지로 넘어가는 코드
            SceneManager.LoadScene(string.Format("Stage{0}",stage)); // 1-2 스테이지로넘어감 
        }
    }
}
