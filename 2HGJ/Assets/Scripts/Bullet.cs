/*
 * Created by Daniel Mak
 */

using System.Collections.Generic;
using UnityEngine;

namespace Daniel {
	public class Bullet : MonoBehaviour {
		[SerializeField] private RockPaperScissorsType rockPaperScissorsType = RockPaperScissorsType.Rock;
		[SerializeField] private Rigidbody2D rigidbody2d = null;
		[SerializeField] private float speed = 0;
		[SerializeField] private Bounds turnArea = new Bounds ();
		[SerializeField] private float turnSpeedBonus = 1;
		[SerializeField] private float damage = 0;

		private bool turned = false;

		public float Damage { get => damage; }

		public Judgement Judge (RockPaperScissorsType other) {
			if (rockPaperScissorsType == other) {
				return Judgement.Draw;
			}

			if (((int) other - (int) rockPaperScissorsType + 3) % 3 == 1) {
				// other wins
				return Judgement.Victory;
			}

			return Judgement.Loss;
		}

		private void Start () {
			rigidbody2d.velocity = transform.up * speed;
			Destroy (gameObject, 10);

			turned = false;
		}

		private void Update () {
			if (!turned && turnArea.Contains (transform.position)) {
				GameObject player = GameObject.FindWithTag ("Player"); // TODO: I don't like this.
				if (player != null) {
					transform.up = (player.transform.position - transform.position).normalized;
					rigidbody2d.velocity = transform.up * speed * turnSpeedBonus;

					turned = true;
				}
			}
		}

		private void OnTriggerEnter2D (Collider2D other) {
			Bullet otherBullet = other.GetComponent<Bullet> ();
			Player otherPlayer = other.GetComponent<Player> ();

			if (otherBullet != null) {
				switch (otherBullet.Judge (rockPaperScissorsType)) {
					case Judgement.Victory:
						Destroy (other.gameObject);
						break;
					case Judgement.Draw:
						Destroy (other.gameObject);
						Destroy (gameObject);
						break;
					case Judgement.Loss:
						Destroy (gameObject);
						break;
				}
			} else if (otherPlayer != null) {
				Destroy (gameObject);
			}
		}

		private void OnDrawGizmosSelected () {
			Gizmos.DrawWireCube (turnArea.center, turnArea.size);
		}
	}
}