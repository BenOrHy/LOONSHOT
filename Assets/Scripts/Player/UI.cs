using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public playerProperty property;
    public playerAttack attack;
    public playerMove move;

    public void Init(playerProperty pro, playerAttack atk, playerMove mov) {
        property = pro;
        attack = atk;
        move = mov;
    }

    public TextMeshProUGUI HPText;
    public Slider HPBar;

    public TextMeshProUGUI actText;
    public Button moveButton;
    public Button attackButton;
    public Button batonButton;
    public Button bladeButton;
    public Button gunButton;

    public Button propertyButton;

    public Slider turnCheckBar;

    public void atkClick() {
        attack.attackPlayer();
    }

    public void moveClick() {
        move.movePlayer();
    }

    public void setGun() { 
        
    }

    public void setBlade() { 
    
    }

    public void setBaton() { 
    
    }

    public void propertyClick() { }

    public void turnUpload() { }

    void Start()
    {
        HPBar.maxValue = property.maxHp;
        HPBar.minValue = 0;
    }

    void Update()
    {
        HPBar.value = property.hp;

        HPText.text = $"Hp : {property.hp}";
        HPText.color = new Color(255, 0, 0);

        actText.text = $"act : {property.act}";
        actText.color = new Color(0, 255, 0);
    }
}
