//Code written by Héctor Barreras Almarcha aka Dechcaudron

using UnityEngine;
using System.Collections;

public class MovingPlatformBehaviour : MonoBehaviour
{
		public float StartX;
		public float RelativeEndX;
		public bool takePositionAsStartX;
		public float MoveSpeed;
		public float defaultToTargetValue;
		protected float pr_targetX;
		protected float pr_endX;
		protected float h_lastX;
		public float currentSpeed;

		void Start ()
		{
				if (takePositionAsStartX) {
						StartX = transform.position.x;
				} else {
						transform.position.Set (StartX, transform.position.y, transform.position.z);
				}

				pr_endX = StartX + RelativeEndX;

				pr_targetX = pr_endX;
		}

		void FixedUpdate ()
		{
				if (transform.position.x < pr_targetX) {

						transform.Translate (MoveSpeed * Time.deltaTime, 0, 0);
				}
		
				if (transform.position.x > pr_targetX) {
						transform.Translate (-MoveSpeed * Time.deltaTime, 0, 0);
				}
		
				//Checks if the distance to the target is less than the wanted to default
				if (Mathf.Abs (transform.position.x - pr_targetX) <= defaultToTargetValue) {
						changeTarget ();
				}

				currentSpeed = transform.position.x - h_lastX;
				h_lastX = transform.position.x;
		}

		void changeTarget ()
		{
				pr_targetX = pr_targetX == StartX ? pr_endX : StartX;
		}
}