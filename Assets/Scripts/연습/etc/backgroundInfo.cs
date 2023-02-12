using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class backgroundInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI canNumber;
    private void Update()
    {
        canNumber.text = MainCharacter.Instance.getCanNumber().ToString();
    }
}
