/*
 * Created by Daniel Mak
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Daniel {
	public class Player : MonoBehaviour {
		[SerializeField] private float maxHealth = 0;
		[SerializeField] private Image healthBarFill = null;

		private float health = 0;

		private void Start () {
			health = maxHealth;
		}

		private void OnTriggerEnter2D (Collider2D other) {
			Debug.Log ("TEST", other.gameObject);

			Bullet otherBullet = other.GetComponent<Bullet> ();
			if (otherBullet != null) {
				health -= otherBullet.Damage;
				healthBarFill.fillAmount = health / maxHealth;

				if (health <= 0) {
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
				}
			}
		}
	}
}