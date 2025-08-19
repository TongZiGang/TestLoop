using System;
using UnityEngine;

public class UIMain : MonoBehaviour
{
    
    public UIVirtualList.UIVirtualList ItemList;

    public void Awake()
    {
        
    }

    private void Start()
    {
        ItemList.ItemProvideHandler = ItemProvide;
        ItemList.ItemCount = 100;
    }

    private void ItemProvide(Transform listItem, int index){
        var item = listItem.GetComponent<MainListItem>();
        item.mianText.text = index.ToString();
    }
}