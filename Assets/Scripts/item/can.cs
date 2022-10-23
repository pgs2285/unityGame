using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MainCharacter.Instance.setCanNumber(MainCharacter.Instance.getCanNumber() + 1);
            Destroy(gameObject);
        }
    }
}
