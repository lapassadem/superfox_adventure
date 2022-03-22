using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_position : MonoBehaviour
{
    public Transform targetTransform = null;

    // Update is called once per frame
    void Update()
    {
        // Nullcheck
        if (this.transform.position != null) {
            // Affecte la position
            this.transform.position = new Vector3(this.targetTransform.position.x, this.targetTransform.position.y, this.transform.position.z);
        }
    }
}
