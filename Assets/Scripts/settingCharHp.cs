using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingCharHp : MonoBehaviour
{
    public Text maxHp;
    public Text currentHp;
    public float maxHpValue;
    public float currentHpValue;

    public 
    void Start()
    {
        // Char Code: 1 = Son, 2 = Rhabu, 3 = Secate
        if(globalVariable.charCode == 1) {
            maxHpValue = 120;
            currentHpValue = 120;
            maxHp.text = maxHpValue.ToString();
            currentHp.text = currentHpValue.ToString();
        } else if(globalVariable.charCode == 2) {
            maxHpValue = 90;
            currentHpValue = 90;
            maxHp.text = maxHpValue.ToString();
            currentHp.text = currentHpValue.ToString();
        } else if(globalVariable.charCode == 3) {
            maxHpValue = 110;
            currentHpValue = 110;
            maxHp.text = maxHpValue.ToString();
            currentHp.text = currentHpValue.ToString();
        }
    }
}
