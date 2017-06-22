using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMng : MonoBehaviour
{

    public GameObject[] Inventory;
    public int Inventory_Slot;
    public int ItemType;            // 아이템 타입

    public void SetPosition()
    {
        gameObject.transform.position =
            new Vector3(gameObject.transform.position.x
            , 100f
            , gameObject.transform.position.z);
    }

    // 인벤토리 비어있는지 체크
    public bool CheckInventory()
    {
        bool InventoryCheck = false;
        for (int i = 0; i < Inventory_Slot; i++)
        {
            if (Inventory[i].GetComponent<InventoryMng>().ItemType.Equals(0))
                InventoryCheck = true;
        }
        return InventoryCheck;
    }

    // 빈공간에 넣기
    public void Inventory_Insert(int ItemType,GameObject Char)
    {
        for (int i = 0; i < Inventory_Slot; i++)
        {
            if (Inventory[i].GetComponent<InventoryMng>().ItemType.Equals(0))
            {
                Insert(Inventory[i], ItemType);
                Inventory[i].GetComponent<Image>().sprite = Char.GetComponent<ImageManager>().material[ItemType];
                Inventory[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
                break;
            }
        }
    }

    void Insert(GameObject inven, int ItemType)
    {
        inven.GetComponent<InventoryMng>().ItemType = ItemType;
    }
}
