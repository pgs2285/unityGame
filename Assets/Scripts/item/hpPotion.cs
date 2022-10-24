using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPotion : MonoBehaviour
{
    protected int hpRecovery = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // player °¡ Á¢ÃË½Ã
        {
            Debug.Log("Æ÷¼Ç ¸Ô±âÀü HP: "+MainCharacter.Instance.getCurrentHP());
            if(MainCharacter.Instance.getCurrentHP()<= MainCharacter.Instance.getHp()) MainCharacter.Instance.setCurrentHP(MainCharacter.Instance.getCurrentHP() + hpRecovery);
            Debug.Log("Æ÷¼Ç ¸ÔÀºÈÄ HP: " + MainCharacter.Instance.getCurrentHP());
            Destroy(gameObject);
        }
    }

}
