using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueur : MonoBehaviour
{
    public Vector3 spawnPosition = new Vector3();
    public joueur_caractere_controleur playerController = null;
    public follow_position cameraFollowPosition = null;

    // UI death screen
    public GameObject deathScreen = null;
    
    // Start is called before the first frame update
    void Start()
    {
        this.spawnPosition = this.playerController.transform.position;
        // Hide death screen
        this.deathScreen.SetActive(false);
    }

    public void Die() {
        Debug.LogWarning("Player " + this.gameObject.name + " est mort");

        // Show death screen
        this.deathScreen.SetActive(true);

        // Player Controller - Stop receiving input
        this.playerController.enabled = false;

        // Camera - Stop following player
        this.cameraFollowPosition.enabled = false;
    }

    public void Respawn() {
        Debug.LogWarning("RESPAWN");
        // Hide death screen
        this.deathScreen.SetActive(false);

        // Player - Teleport back to spawn
        this.playerController.transform.position = this.spawnPosition;

        // Rigidbody
        this.playerController.Rigidbody2D.velocity = Vector3.zero;

        // Player Controller - Stop receiving input
        this.playerController.enabled = true;

        // Camera - Stop following player
        this.cameraFollowPosition.enabled = true;
    }
}
