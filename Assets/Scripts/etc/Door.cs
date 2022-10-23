using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("현재스테이지 1-1");
        if (collision.collider.CompareTag("Player"))
        {
            
            // 다음 스테이지로 넘어가는 코드
            SceneManager.LoadScene("Stage1-2"); // 1-2 스테이지로넘어감 
        }
    }
}
