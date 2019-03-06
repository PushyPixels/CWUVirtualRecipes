namespace VRTK.Examples
{
    using UnityEngine;

    public class SpawnerTool : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public GameObject projectile;
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
            if (projectile != null && projectileSpawnPoint != null)
            {
                GameObject clonedProjectile = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            }
        }
    }
}