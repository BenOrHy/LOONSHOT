using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private playerAttack attack;
    [SerializeField] private playerMove move;
    [SerializeField] private playerLevel level;
    [SerializeField] private UI ui;

    public GameObject air;

    void Awake()
    {
        playerProperty property = new playerProperty();
        attack.Init(property);
        move.Init(property);
        ui.Init(property, attack, move);

        property.mainhandItem = air;
    }
}
