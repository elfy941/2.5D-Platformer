using System;
using Interfaces;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class Coin : MonoBehaviour, ICollectible {
        // Event object is static in order for every object of class Coin
        // to have the same event referece, otherwise the subriber won't work'
        public static event EventHandler OnCoinCollected; 
        
        //  OnCoinCollected?.Invoke(this, EventArgs.Empty);
        //               ||
        //  if(OnCoinCollected != null) {
        // OnCoinCollected(this, EventArgs.Empty); }
        //  
        public void Collect() {
            OnCoinCollected?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
}