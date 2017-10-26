using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnginDeSiegeController))]
public class EnginDeSiege : MonoBehaviour {
    EnginDeSiegeController controller;
    [SerializeField] Collider colliderForProjectileToIgnore;
    public ProjectilePhysics ammunition;
    public float puissance = 50f;
    [SerializeField] Vector3 projectileSpawnPosition;

    // Use this for initialization
    void Awake() {
        if (colliderForProjectileToIgnore != null) {
            controller = GetComponent<EnginDeSiegeController>();
            Recharger();
        } else {
            Debug.LogError("\""+name+"\"'s colliderForProjectileToIgnore attribute cannot be null.");
        }
    }

    // Useful as UI can't directly edit the ammunition used
    public void ChangerProjectile(string projectileName) {
        ammunition = ((GameObject)Resources.Load(projectileName)).GetComponent<ProjectilePhysics>();
        if (ammunition != null) {
            ammunition.GetComponent<Rigidbody>().isKinematic = true;
            ammunition.transform.position = projectileSpawnPosition;
        } else {
            Debug.LogError("Projectile named " + projectileName + " not found. Please make sure the Projectile is in a \"Resources\" folder.");
        }
    }

    private void Recharger() {
        if (ammunition == null) { ChangerProjectile("Boulet"); }
        ProjectilePhysics loadedProjectile = Instantiate(ammunition, transform);
        Physics.IgnoreCollision(colliderForProjectileToIgnore, loadedProjectile.GetComponent<Collider>(), true);
    }

    public void LancerProjectile() {
        // First, check if the engin is in the right mode
        if (!controller.ModeDeplacement) {
            // Then, check if there's a projectile loaded
            Rigidbody loadedProjectile = null;
            ProjectilePhysics childrenComponent = GetComponentInChildren<ProjectilePhysics>();
            if (childrenComponent) { loadedProjectile = childrenComponent.GetComponent<Rigidbody>();
                // If so, launch it!
                loadedProjectile.isKinematic = false;
                loadedProjectile.velocity = transform.forward * puissance;
            }
        }
    }
}
