using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField]
    GameObject UI_Canvas;

    [SerializeField]
    UI_Inventory UI_Inventory;

    Player controls;

    Player.ActionMovementActions actionMovement;

    private Inventory inventory;

    void Awake()
    {
        controls = new Player();

        actionMovement = controls.ActionMovement;
        actionMovement.Inventory.performed += ctx => Inventory();

        inventory = new Inventory();

        UI_Inventory.SetInventory(inventory);
    }

    void Inventory()
    {
        if (UI_Canvas.active)
        {
            UI_Canvas.active = false;
            Time.timeScale = 1f;
        }
        else
        {
            UI_Canvas.active = true;
            Time.timeScale = 0f;
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestory()
    {
        controls.Disable();
    }
}
