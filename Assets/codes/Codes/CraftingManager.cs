using UnityEngine;
using TMPro;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

public class CraftingManager : MonoBehaviour
{
    public List<Recipe> recipes;                     // Inspector���� ���
    public List<CraftingSlot> inputSlots;            // 2�� �̻� ����
    public CraftingSlot resultSlot;                  // ��� ǥ�ÿ� ����
    public TMP_Text resultText;                      // ���� �޽��� ǥ��

    public void TryCraft()
    {
        foreach (var recipe in recipes)
        {
            if (IsRecipeMatch(recipe))
            {
                resultSlot.SetItem(recipe.result);
                resultText.text = $"{recipe.result.itemName} ���� ����!";
                return;
            }
        }

        resultSlot.Clear();
        resultText.text = "���� ����!";
    }

    private bool IsRecipeMatch(Recipe recipe)
    {
        Dictionary<ItemData, int> inputCounts = new();

        foreach (var slot in inputSlots)
        {
            if (!slot.HasItem()) continue;

            if (!inputCounts.ContainsKey(slot.currentItem))
                inputCounts[slot.currentItem] = 0;

            inputCounts[slot.currentItem]++;
        }

        foreach (var req in recipe.materials)
        {
            if (!inputCounts.ContainsKey(req.item)) return false;
            if (inputCounts[req.item] < req.quantity) return false;
        }

        return true;
    }
}
