using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manageCharHp : MonoBehaviour
{
    public float hp;
    public GameObject hpValue;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hp = hpValue.GetComponent<settingCharHp>().currentHpValue;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered by: " + collider.gameObject.name);

        if (hp > 0) {
            GameObject enemyBody = collider.gameObject;

            if (enemyBody.TryGetComponent<enemyMove>(out enemyMove enemy)) {
                Debug.Log("Enemy Damage: " + enemy.damage);
                float enemyDamage = enemy.damage;
                hp -= enemyDamage; 
                hpText.text = hp.ToString();

                if (hp <= 0)
                {
                    hp = 0;
                    hpText.text = hp.ToString();

                    // cemhow game over
                }
            }
            else {
                Debug.Log("Collider is not an enemy (missing enemyMove component).");
            }
        }
        else {
            hp = 0;
            hpText.text = hp.ToString();
        }
    }
}
