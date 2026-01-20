using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayController : MonoBehaviour
{
    [SerializeField] private List<Image> itemImages;
    [SerializeField] private RectTransform selectorRectTransform;

    public void UpdateItemImages(List<Seed> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            itemImages[i].sprite = items[i].InSoilSprite;
        }
        for (int i = items.Count; i < itemImages.Count; i++)
        {
            itemImages[i].sprite = null;
        }
    }

    public void MoveSelector(int selectorIndex)
    {
        selectorRectTransform.anchoredPosition
            = itemImages[selectorIndex].rectTransform.anchoredPosition;
    }
}
