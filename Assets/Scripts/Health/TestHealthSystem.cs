using System;
using CodeMonkey.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Health {
    public class TestHealthSystem : MonoBehaviour {

        [SerializeField] private HealthBar healthBar;
        HealthSystem hs = new HealthSystem(30);
        private void Start() {
            
            
            healthBar.Setup(hs);
            hs.Damage(35);
            Debug.Log(hs.GetHealth());
            hs.Heal(35);
            Debug.Log(hs.GetHealth());
            hs.Damage(10);
            Debug.Log(hs.GetHealthPercentage());

            
            
            // healthBar.SetSize(.4f);
            // healthBar.SetColor(Color.green);
            // float health = 1f;
            // //function that is executed on a timer
            // FunctionPeriodic.Create(() => {
            //     if (health > .01f) {
            //         health -= .01f;
            //         healthBar.SetSize(health);
            //         
            //         //create flashing annimation
            //         if (health < .3f) {
            //             if (Random.Range(1f, 10f) > 4f) {
            //                 healthBar.SetColor(Color.white);
            //             } else {
            //                 healthBar.SetColor(Color.red);
            //             }
            //         }
            //     }
            // }, .03f);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                hs.Damage(10);
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                hs.Heal(10);
            }
        }
    }
}