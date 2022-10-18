using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeChange : MonoBehaviour
{

    public void ModeChange()
    {
        GetComponent<CharacterMovement>().enabled = false;
        GetComponent<CharacterAttack>().enabled = true;
    }

}
