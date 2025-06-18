using UnityEngine;
using TMPro;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

public class CraftingManager : MonoBehaviour
{
    public List<Recipe> recipes;                     // Inspector에서 등록
    public List<CraftingSlot> inputSlots;            // 2개 이상 슬롯
    public CraftingSlot resultSlot;                  // 결과 표시용 슬롯
    public TMP_Text resultText;                      // 상태 메시지 표시

    public void TryCraft()
    {
        foreach (var recipe in recipes)
        {
            if (IsRecipeMatch(recipe))
            {
                resultSlot.SetItem(recipe.result);
                resultText.text = $"{recipe.result.itemName} 제작 성공!";
                return;
            }
        }

        resultSlot.Clear();
        resultText.text = "제작 실패!";
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
