using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerProperty
{

    public float maxHp = 6;
    public float hp = 6;

    public float atk = 1;
    public float dff = 1;

    public int spd = 3;
    public int act = 2;
    public int maxAct = 2;

    public bool playerCanAttack = false;
    public bool playerCanMove = false;

    public List<GameObject> Items = new List<GameObject>();
    public GameObject mainhandItem;

}
