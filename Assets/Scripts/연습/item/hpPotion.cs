using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPotion : MonoBehaviour
{
    protected int hpRecovery = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // player �� ���˽�
        {
            Debug.Log("���� �Ա��� HP: "+MainCharacter.Instance.getCurrentHP());
            if(MainCharacter.Instance.getCurrentHP()<= MainCharacter.Instance.getHp()) MainCharacter.Instance.setCurrentHP(MainCharacter.Instance.getCurrentHP() + hpRecovery);
            Debug.Log("���� ������ HP: " + MainCharacter.Instance.getCurrentHP());
            Destroy(gameObject);
        }
    }

}
