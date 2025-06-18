using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Image iconImage;
    public ItemData currentItem;
    public int itemCount = 1;

    public void SetItem(ItemData item)
    {
        currentItem = item;
        iconImage.sprite = item.icon;
        iconImage.enabled = true;
    }

    public void Clear()
    {
        currentItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
    }

    public bool HasItem() => currentItem != null;
}