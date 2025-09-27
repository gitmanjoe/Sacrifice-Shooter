    using UnityEngine;

    public class FollowGun: MonoBehaviour
    {
        public Transform targetObject; 
        public float rotationSpeed = 5f; 

        void LateUpdate()
        {
            if (targetObject == null)
            {
                Debug.LogWarning("Target Object not assigned in SmoothRotationFollower script!");
                return;
            }

            // Calculate the desired rotation
            Quaternion targetRotation = targetObject.rotation;

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
