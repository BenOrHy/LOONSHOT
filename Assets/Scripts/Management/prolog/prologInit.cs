using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologInit : MonoBehaviour
{
    [SerializeField] private prologManager prolog;

    void Awake()
    {
        playerProperty property = new playerProperty();
        itemHandler give = new itemHandler(property);
        prolog.Init(give);
    }
}
