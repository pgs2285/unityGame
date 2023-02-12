using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MainCharacter.Instance.setCurrentHP(MainCharacter.Instance.getCurrentHP() - 1);
            Destroy(gameObject);
        }
    }
}
