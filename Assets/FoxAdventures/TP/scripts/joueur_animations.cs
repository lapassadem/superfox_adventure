using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueur_animations : MonoBehaviour
{
    public joueur_caractere_controleur playerCharacterController = null;

    public float HorizontalInput {
        get {
            if (this.playerCharacterController != null) {
                return this.playerCharacterController.horizontalInput;
            }

            return 0f;
        }
    }
    
    public Animator animator = null;

    void LateUpdate() {
        if (this.animator != null) {
            this.animator.SetBool("IsGrounded", this.playerCharacterController.isGrounded);
            this.animator.SetFloat("Horizontal", this.HorizontalInput);
        }
    }
}

