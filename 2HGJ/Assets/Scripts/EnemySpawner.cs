/*
 * Created by Daniel Mak
 */

using UnityEngine;

namespace Daniel {
	public class EnemySpawner : MonoBehaviour {
		[SerializeField] private GameObject[] bulletsPrefabs = null;
		[SerializeField] private Bounds spawnArea = new Bounds ();
		[SerializeField] private float timeBetweenSpawn = 0;

		private GameObject nextBullet = null;
		private float timestamp = 0;

		private void Start () {
			timestamp = Time.time + timeBetweenSpawn;
			ShuffleNextBullet ();
		}

		private void Update () {
			if (Time.time > timestamp) {
				Vector2 spawnPosition = new Vector2 (
					Random.Range (spawnArea.min.x, spawnArea.max.x),
					Random.Range (spawnArea.min.y, spawnArea.max.y)
				);

				GameObject spawned = Instantiate (nextBullet, spawnPosition, Quaternion.identity);
				spawned.transform.up = Vector2.down;
				ShuffleNextBullet ();

				timestamp = Time.time + timeBetweenSpawn;
			}
		}

		private void OnDrawGizmos () {
			Gizmos.DrawWireCube (spawnArea.center, spawnArea.size);
		}

		private void ShuffleNextBullet () {
			nextBullet = bulletsPrefabs[Random.Range (0, bulletsPrefabs.Length)];
		}
	}
}