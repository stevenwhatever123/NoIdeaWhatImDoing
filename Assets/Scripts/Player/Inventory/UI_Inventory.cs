using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;

    //private Transform itemSlotContainer;
    //private Transform itemSlotTemplate;

    [SerializeField]
    private GameObject itemSlots;

    [SerializeField]
    private List<GameObject> allItemSlots;

    List<bool> itemStats;

    void Awake()
    {
        print(itemSlots.transform.childCount);
        //itemSlotContainer = transform.Find("itemSlotContainer0");
        //itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        itemStats = new List<bool>();
        for(int i = 0; i < itemSlots.transform.childCount; i++)
        {
            GameObject child = itemSlots.transform.GetChild(i).gameObject;
            allItemSlots.Add(child);
            //itemStats.Add(child.GetComponent<InventoryStats>());
        }
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        if(itemStats.Count > 0)
            itemStats.Clear();
        for(int i = 0; i < itemSlots.transform.childCount; i++)
        {
            GameObject child = itemSlots.transform.GetChild(i).gameObject;
            itemStats.Add(child.GetComponent<InventoryStats>().IsOccupied());
        }

        print("Size: " + itemStats.Count);

        foreach(Item item in inventory.GetItemList())
        {
            Transform itemSlotContainer = allItemSlots[0].transform;
            Transform itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
            int i;
            for(i = 0; i < allItemSlots.Count; i++)
            {
                if (!itemStats[i])
                {
                    print(i);
                    itemSlotContainer = allItemSlots[i].transform;
                    itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

                    allItemSlots[i].GetComponent<InventoryStats>().setOccupied(true);
                    itemStats[i] = true;
                    break;
                }
            }
            RectTransform itemSlotRecTransform =
                Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRecTransform.gameObject.SetActive(true);
        }
    }
}
