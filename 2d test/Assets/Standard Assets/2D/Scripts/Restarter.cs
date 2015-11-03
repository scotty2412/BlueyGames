using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerenter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
    }
}
