using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;
    public Text textScore;

    public void AstroidDestroyed(Astroid astroid) {
        this.explosion.transform.position = astroid.transform.position;
        this.explosion.Play();

        if(astroid.size < 0.75f) {
            this.score += 100;
        } else if (astroid.size < 1.2f) {
            this.score += 50;
        } else {
            this.score += 25;
        }
    }

    public void PlayerDied() {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn() {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions() {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver() {
        this.lives = 3;
        this.score = 0;
        Invoke(nameof(Respawn), this.respawnTime);
    }
}
