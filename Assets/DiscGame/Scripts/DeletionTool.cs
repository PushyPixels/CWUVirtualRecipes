namespace VRTK.Examples
{
    using UnityEngine;

    public class DeletionTool : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public Transform projectileSpawnPoint;

        protected virtual void OnEnable()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            FireProjectile();
        }

        protected virtual void FireProjectile()
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(projectileSpawnPoint.position,projectileSpawnPoint.forward,out hitInfo))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}