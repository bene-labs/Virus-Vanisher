using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D collider) {
            Debug.Log("hit detected!");
        }
}
