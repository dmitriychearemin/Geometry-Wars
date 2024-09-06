using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForBarHPStamina : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayersCharacteristics player;
    [SerializeField] Image HPBar;
    [SerializeField] Image StaminaBar;

    void Start()
    {
        //player = GameObject.Find("PLayer").GetComponent<PlayersCharacteristics>();
        //print(1);
        //HPBar = GameObject.Find("BarHP").GetComponent<Image>();
        //print(2);
        //StaminaBar = GameObject.Find("BarStamina").GetComponent<Image>();
        //print(3);

    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = player.getCurHP() / player.getMaxHP();
        StaminaBar.fillAmount= player.getCurStamina() / player.getMaxStamina();

    }
}
