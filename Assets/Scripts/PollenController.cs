using UnityEngine;

namespace Assets.Scripts {
    public class PollenController : MonoBehaviour {
        public float pollenLifetime { get; set; }
        private float createdAt;

        private void Start() {
            createdAt = Time.time;
        }

        private void Update() {
            if (createdAt + pollenLifetime < Time.time) { 
                Destroy(gameObject);
            }
        }
    }
}
