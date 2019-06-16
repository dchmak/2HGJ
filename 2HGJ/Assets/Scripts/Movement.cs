/*
 * Created by Daniel Mak
 */

using UnityEngine;

namespace Daniel {
	public class Movement : MonoBehaviour {
		[SerializeField] private Rigidbody2D rigidbody2d = null;
		[SerializeField] private float speed = 0;
		[SerializeField] private float turnBonus = 1;

		public void Move (Vector2 moveVector) {
			Vector2 forceToAdd = moveVector * speed;
			if (Vector2.Dot (rigidbody2d.velocity, moveVector) < 0) {
				forceToAdd *= turnBonus;
			}

			rigidbody2d.AddForce (forceToAdd);
		}
	}
}