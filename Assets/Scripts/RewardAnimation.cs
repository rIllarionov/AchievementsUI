using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RewardAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _rewardImagePrefab;
    [SerializeField] private CorutinWallet _corutinWallet;
    
    private Sprite _rewardSprite;
    private GameObject _target;
    private GameObject[] _sprites = new GameObject[5];
    private Vector3 _offset = new(2, 2);
    private RectTransform _parent;
    private RectTransform _animationLayer;
    private int _rewardCount;


    public void StartAnimation(RectTransform parent, GameObject target, Sprite rewardSprite,
        RectTransform animationLayer,int rewardCount)
    {
        _parent = parent;
        _target = target;
        _rewardSprite = rewardSprite;
        _animationLayer = animationLayer;
        _rewardCount = rewardCount;

        _rewardImagePrefab.GetComponent<Image>().sprite = _rewardSprite;
        StartCoroutine(ShowItems());
        _corutinWallet.StartCorutine(target,_rewardCount);
    }


    private IEnumerator ShowItems()
    {
        for (int i = 0; i < _sprites.Length; i++)
        {
            _sprites[i] = Instantiate(_rewardImagePrefab, _parent, false);
            _sprites[i].transform.SetParent(_animationLayer);
            _sprites[i].transform.position += _offset;
            _offset += _offset;
            StartCoroutine(MoveToTarget());
            yield return null;
        }
    }

    private IEnumerator MoveToTarget()
    {
        for (int i = 0; i < _sprites.Length; i++)
        {
            var time = 1f;
            var currentTime = 0f;
            var startPosition = _sprites[i].transform.position;

            while (currentTime < time)
            {
                _sprites[i].transform.position =
                    Vector3.Lerp(startPosition, _target.transform.position, currentTime / time);

                currentTime += Time.deltaTime * 2;

                yield return null;
            }

            _sprites[i].SetActive(false);
        }
    }
}