using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform startTranform = null;
    public Transform endTransform = null;
    public float moveSpeed = 1.0f;

    public float percentage = 0.0f; // 0.0 <=> 1.0

    public bool movingDirection = false; // false => up; true => down

    // Rigidbody s'occupe du mouvement
    public Rigidbody2D Rigidbody2D = null;

    void Update() {
        if (this.movingDirection) {
            this.percentage = Mathf.Clamp01(this.percentage + this.moveSpeed * Time.deltaTime);
            if (this.percentage == 1.0f) {
                this.movingDirection = !this.movingDirection;
            }
        } else {
            this.percentage = Mathf.Clamp01(this.percentage - this.moveSpeed * Time.deltaTime);
            if (this.percentage == 0.0f) {
                this.movingDirection = !this.movingDirection;
            }
        }
    }

    void FixedUpdate() {
        if (this.Rigidbody2D != null) {
            Vector2 newPosition = Vector2.Lerp(this.startTranform.position, this.endTransform.position, this.percentage);
            this.Rigidbody2D.MovePosition(newPosition);
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawLine(this.startTranform.position, this.endTransform.position);
    }
}
