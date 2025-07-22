using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHandler
{
    public playerProperty property;
    public itemHandler(playerProperty pro) {
        property = pro;
    }
    public void commandGive(GameObject item) 
    {
        property.Items.Add(item);
    }

    public void commandStole(GameObject item)
    {
        if (property.Items.Contains(item)) {
            property.Items.Remove(item);
        }
    }
}
