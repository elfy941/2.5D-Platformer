using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;


public class UiManager : MonoBehaviour {
    [SerializeField] private Text coinsCollected;

    private int _coins;

    private void Start() {
        Coin.OnCoinCollected += UpdateUiWhenCoinCollected_OnCoinCollected;
    }

    private void Update() {
        coinsCollected.text = "Coins: " + _coins;
    }

    private void UpdateUiWhenCoinCollected_OnCoinCollected(object sender, EventArgs eventArgs) {
        _coins++;
    }
}
