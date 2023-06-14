using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _rewardImage;
    [SerializeField] private TextMeshProUGUI _rewardCount;

    private RectTransform _anchor;
    private RectTransform _animationLayer;
    
    private RewardAnimation _rewardAnimation;

    private GameObject _moneyField;
    private GameObject _crystalField;

    private ItemData _itemData;

    private void Awake()
    {
        _rewardAnimation = GetComponent<RewardAnimation>();
        _anchor = _rewardImage.GetComponent<RectTransform>();
    }

    public void ItemInitializer(ItemData itemData,GameObject moneyField,GameObject crystalField,RectTransform animationLayer)
    {
        _itemData = itemData;
        _moneyField = moneyField;
        _crystalField = crystalField;
        _animationLayer = animationLayer;

        _itemImage.sprite = _itemData.ItemImage;
        _itemName.text = _itemData.ItemName;
        _description.text = _itemData.Description;
        _rewardImage.sprite = _itemData.RewardImage;
        
        if (_itemData.RewardCount != 0)
        {
            _rewardCount.text = _itemData.RewardCount.ToString();
        }
        else
        {
            _rewardCount.text = null;
        }
    }

    public void ChooseAnimation()
    {
        switch (_itemData.ItemType)
        {
            case "Gold" : PlayRewardAnimation(_moneyField);
                break;
            
            case "Crystal" : PlayRewardAnimation(_crystalField);
                break;
            
            case "Technic" : ShowItem();
                break;
            
            case "Level" : ShowItem();
                break;
        }
    }

    private void PlayRewardAnimation(GameObject target)
    {
        _rewardAnimation.StartAnimation(_anchor, target,_itemData.AnimationSprite,_animationLayer,_itemData.RewardCount);
    }
    

    private void ShowItem()
    {
        Instantiate(_itemData.AnimationPrefab,_animationLayer,false);
    }

}
