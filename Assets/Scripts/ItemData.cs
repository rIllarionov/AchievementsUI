using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "ItemData",menuName = "ScriptableObject/ItemSettings",order = 30)]
public class ItemData : ScriptableObject
{
    [SerializeField] private Sprite _itemImage;
    [SerializeField] private string _itemName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _rewardImage;
    [SerializeField] private int _rewardCount;
    [SerializeField] private string _itemType;
    [SerializeField] private Sprite _animationSprite;
    [SerializeField] private GameObject _animationPrefab;

    public Sprite ItemImage => _itemImage;
    public string ItemName => _itemName;
    public string Description => _description;
    public Sprite RewardImage => _rewardImage;
    public int RewardCount => _rewardCount;
    public string ItemType => _itemType;
    public Sprite AnimationSprite => _animationSprite;

    public GameObject AnimationPrefab => _animationPrefab;
}
