using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemsHandler",menuName = "ScriptableObject/ItemsHandler",order = 20)]
public class ItemsHandler : ScriptableObject
{
    [SerializeField] private List<ItemData> _items;

    public List<ItemData> Items => _items;
}
