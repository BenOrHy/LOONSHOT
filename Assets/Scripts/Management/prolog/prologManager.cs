using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologManager : MonoBehaviour
{
    public itemHandler give;

    public void Init(itemHandler commandGive) {
        give = commandGive;
    }

    public GameObject item1;
    public GameObject item2;

    void Start()
    {
        give.commandGive(item1);
        give.commandGive(item2);
    }

    void LateUpdate()
    {
        
    }
}
