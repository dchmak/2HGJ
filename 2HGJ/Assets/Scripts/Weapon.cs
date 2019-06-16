/*
 * Created by Daniel Mak
 */

using UnityEngine;
using UnityEngine.UI;

namespace Daniel {
	public class Weapon : MonoBehaviour {
		[SerializeField] private GameObject[] bulletsPrefabs = null;
		[SerializeField] private Transform shotPoint = null;
		[SerializeField] private float cooldown = 0;
		[SerializeField] private Image nextBulletIcon = null;
		[SerializeField] private Sprite[] bulletIcons = null;

		private GameObject nextBullet = null;
		private float timestamp = 0;

		public void Shoot () {
			if (Time.time > timestamp) {
				Instantiate (nextBullet, shotPoint.position, Quaternion.identity);
				ShuffleNextBullet ();

				timestamp = Time.time + cooldown;
			}
		}

		private void Start () {
			ShuffleNextBullet ();
		}

		private void ShuffleNextBullet () {
			int random = Random.Range (0, bulletsPrefabs.Length);
			nextBullet = bulletsPrefabs[random];

			nextBulletIcon.sprite = bulletIcons[random];  // TODO: Don't like this.
		}
	}
}