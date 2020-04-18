using System;
using UnityEngine;

public class HealthSystem {
    
    private int _health;
    private int _maxHealth;    
    public event EventHandler OnHealthChanges;
    public event EventHandler OnHealthZero;
    
    
    public HealthSystem(int health) {
        _maxHealth = health;
        _health = _maxHealth;
    }

    public int GetHealth() {
        return _health;
    }

    public void Kill() {
        Damage(_health);
    }

    public void Damage(int damage) {
        if (_health - damage >= 0) {
            _health -= damage;    
        } else {
            _health = 0;
        }
        OnHealthChanges?.Invoke(this, EventArgs.Empty);

        if (_health == 0) {
            OnHealthZero?.Invoke(this, EventArgs.Empty);
        }
        
    }

    public void Heal(int amount) {
        if (_health + amount <= _maxHealth) {
            _health += amount;    
        } else {
            _health = _maxHealth;
        }
        OnHealthChanges?.Invoke(this, EventArgs.Empty);
    }

    public float GetHealthPercentage() {
        return (float) _health / _maxHealth;
    }

}
