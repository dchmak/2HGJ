/*
 * Created by Daniel Mak
 */

using UnityEngine;
using UnityEngine.Events;

namespace Daniel.InputSystem {
	public class InputSystem : MonoBehaviour {
		[SerializeField] private Vector2Event move = null;
		[SerializeField] private UnityEvent act = null;

		private Vector2 moveVector = Vector2.zero;
		private bool actBool = false;

		private void Update () {
			moveVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			actBool = Input.GetButtonUp ("Fire1");
		}

		private void FixedUpdate () {
			move?.Invoke (moveVector.normalized);
			if (actBool) {
				act?.Invoke ();
			}
		}
	}
}