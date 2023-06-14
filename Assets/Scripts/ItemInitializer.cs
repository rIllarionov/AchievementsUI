using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInitializer : MonoBehaviour
{
    [SerializeField] private ItemsHandler _itemsHandler;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private RectTransform _parentObject;
    [SerializeField] private GameObject _moneyField;
    [SerializeField] private GameObject _crystalField;
    [SerializeField] private RectTransform _animationLayer;
    private void Start()
    {
        InitializeItems();
    }

    private void InitializeItems()
    {
        var itemsData = _itemsHandler.Items;
        foreach (var items in itemsData)
        {
            var itemObject = Instantiate(_itemPrefab, _parentObject, false);
            var item = itemObject.GetComponent<ItemController>();
            item.ItemInitializer(items,_moneyField,_crystalField,_animationLayer);
        }
    }
}
