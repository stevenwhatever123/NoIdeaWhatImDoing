using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField]
    Raycast raycast;

    public void Take()
    {
        raycast.OnSelect();
    }
}
