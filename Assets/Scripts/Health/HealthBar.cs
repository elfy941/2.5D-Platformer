using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
     
    private Transform _bar;
    private HealthSystem _healthSystem;

    void Start() {
        _bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized) {
        _bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void Setup(HealthSystem _healthSystem) {
        this._healthSystem = _healthSystem;
        _healthSystem.OnHealthChanges += HealthSystem_OnHealthChanges;
    }

    private void HealthSystem_OnHealthChanges(object sender, EventArgs e) {
        _bar.localScale = new Vector3(_healthSystem.GetHealthPercentage(), 1f);
    }
    
    public void SetColor(Color color) {
        _bar.Find("BarSprite").transform.GetComponent<SpriteRenderer>().color = color;
    }
    
    
    
}
