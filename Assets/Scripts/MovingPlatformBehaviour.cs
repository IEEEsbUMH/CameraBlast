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
				//Checks if the distance to the target is less than the wanted to default
				if (Mathf.Abs (transform.position.x - pr_targetX) <= defaultToTargetValue) {
						transform.position.Set (pr_targetX, transform.position.y, transform.position.z);
						pr_targetX = pr_targetX == StartX ? pr_endX : StartX;
				}

				if (transform.position.x < pr_targetX) {
						transform.Translate (MoveSpeed * Time.deltaTime, 0, 0);
				}

				if (transform.position.x > pr_targetX) {
						transform.Translate (-MoveSpeed * Time.deltaTime, 0, 0);
				}
		}
}
