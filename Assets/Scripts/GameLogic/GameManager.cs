using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Player player;
    
    private HealthSystem _healthSystem;
    
    [SerializeField]
    private HealthBar healthBar;
    
    private void Start() {
        InitHealthSystem();
    }
    
    private void InitHealthSystem() {
        _healthSystem = new HealthSystem(100);
        _healthSystem.OnHealthZero += ReloadScene_OnHealthZero;
        healthBar.Setup(_healthSystem);
        player.SetHealthSystem(_healthSystem);
        
    }

    private void ReloadScene_OnHealthZero(object sender, EventArgs eventArgs) {
        SceneManager.LoadScene(Constants.TestScene);
    }
}
