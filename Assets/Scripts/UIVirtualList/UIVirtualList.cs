using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UIVirtualList
{
    public delegate void ItemProvideHandler(Transform item, int index);
    [RequireComponent(typeof(LoopScrollRect))]
    [DisallowMultipleComponent]
    public class UIVirtualList : MonoBehaviour, LoopScrollPrefabSource,LoopScrollDataSource
    {
        
        /// <summary>
        /// 子节点预制件
        /// </summary>
        public GameObject itemPrefab;
        
        private Stack<Transform> pool = new();
        
        public ItemProvideHandler ItemProvideHandler;
        private LoopScrollRect scrollRect;

        private void Awake()
        {
            scrollRect = GetComponent<LoopScrollRect>();
            scrollRect.prefabSource = this;
            scrollRect.dataSource = this;
        }

        public GameObject GetObject(int index) {
            if (pool.Count == 0) {
                return Instantiate(itemPrefab);
            }
            var item = pool.Pop();
            item.gameObject.SetActive(true);
            return item.gameObject;
        }

        public void ReturnObject(Transform trans) {
            trans.gameObject.SetActive(false);
            pool.Push(trans);
        }

        public void ProvideData(Transform transform, int idx) {
            Debug.Log($"ProvideData index = {idx}");
            ItemProvideHandler?.Invoke(transform, idx);
        }
        /// <summary>
        /// 列表元素数量
        /// </summary>
        public int ItemCount{
            get{
                return scrollRect.totalCount;
            }
            set {
                scrollRect.totalCount = value;
                scrollRect.RefillCells();
            }
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        public void Refresh() {
            scrollRect.RefreshCells();
        }
    }
}