using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("���罺������ 1-1");
        if (collision.collider.CompareTag("Player"))
        {
            
            // ���� ���������� �Ѿ�� �ڵ�
            SceneManager.LoadScene("Stage1-2"); // 1-2 ���������γѾ 
        }
    }
}
