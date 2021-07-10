using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryStats : MonoBehaviour
{
    [SerializeField]
    RawImage image;

    [SerializeField]
    bool hasOccupied = false;

    public bool IsOccupied()
    {
        return hasOccupied;
    }

    public void setOccupied(bool b)
    {
        hasOccupied = b;
    }
}
