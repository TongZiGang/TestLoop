using System;
using UnityEngine;

public class UIMain : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public UIVirtualList.UIVirtualList ItemList;
    /// <summary>
    /// 
    /// </summary>
    public UIVirtualList.UIVirtualList ItemList1;

    public void Awake()
    {
        
    }

    private void Start()
    {
        ItemList.ItemProvideHandler = ItemProvide;
        ItemList.ItemCount = 100;

        ItemList1.ItemProvideHandler = ItemProvide;
        ItemList1.ItemCount = 100;
    }

    private void ItemProvide(Transform listItem, int index){
        var item = listItem.GetComponent<MainListItem>();
        item.mianText.text = index.ToString();
    }
}