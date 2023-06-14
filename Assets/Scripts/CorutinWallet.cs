using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorutinWallet : MonoBehaviour
{
    private TextMeshProUGUI _wallet;

    private float _currentCount;
    private float _finishCount;

    public void StartCorutine(GameObject wallet,int rewardCount)
    {
        _wallet = wallet.GetComponentInChildren<TextMeshProUGUI>();
        _currentCount = Convert.ToInt32(_wallet.text);
        _finishCount = _currentCount + rewardCount;

        StartCoroutine(MoveToTarget());
    }


    private IEnumerator MoveToTarget()
    {
        var time = 2f;
        var currentTime = 0f;

        while (currentTime <= time)
        {
            _wallet.text =
                Mathf.Lerp(_currentCount, _finishCount, currentTime / time).ToString("0");

            currentTime += Time.deltaTime;

            yield return null;
        }

    }
}