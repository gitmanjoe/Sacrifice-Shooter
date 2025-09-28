    using UnityEngine;

    public class FollowGun: MonoBehaviour
    {
        public Transform targetObject; 
        public float rotationSpeed = 15f; 

        void LateUpdate()
        {
		// Calculate the desired rotation
		Quaternion targetRotation = targetObject.rotation;

		// Smoothly interpolate towards the target rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
