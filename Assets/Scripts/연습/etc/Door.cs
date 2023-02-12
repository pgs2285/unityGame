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
            
            // ���� ���������� �Ѿ�� �ڵ�
            SceneManager.LoadScene(string.Format("Stage{0}",stage)); // 1-2 ���������γѾ 
        }
    }
}
