using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnginDeSiegeController))]
public class EnginDeSiege : MonoBehaviour {
    EnginDeSiegeController controller;
    [SerializeField] Collider colliderForProjectileToIgnore;
    public ProjectilePhysics ammunition;
    public float puissance = 50f;
    [SerializeField] Vector3 projectileSpawnPosition;
    [SerializeField] Vector3 projectileSpawnRotation;

    // Use this for initialization
    void Awake() {
        if (ammunition != null) {
            if (colliderForProjectileToIgnore != null) {

                controller = GetComponent<EnginDeSiegeController>();
                Recharger();

            } else {
                Debug.LogError("\"" + name + "\"'s " + GetType().Name + ".colliderForProjectileToIgnore attribute cannot be null.");
            }
        } else {
            Debug.LogError("\"" + name + "\"'s " + GetType().Name + ".ammunition attribute cannot be null.");
        }
    }

    // Useful as UI can't directly edit the ammunition used
    public void ChangerProjectile(ProjectilePhysics projectile) {
        ammunition = projectile.GetComponent<ProjectilePhysics>();
    }

    private void Recharger() {
        ProjectilePhysics loadedProjectile = Instantiate(ammunition, transform);
        loadedProjectile.transform.localPosition = projectileSpawnPosition;
        loadedProjectile.transform.localRotation = Quaternion.Euler(projectileSpawnRotation);
        loadedProjectile.GetComponent<Rigidbody>().isKinematic = true;
        foreach (Collider collider in loadedProjectile.GetComponentsInChildren<Collider>()) {
            Physics.IgnoreCollision(colliderForProjectileToIgnore, collider, true);
        }
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
            } else {
                Debug.Log("Il n'y a aucun projectile à tirer.");
            }
        } else {
            Debug.Log("Un engin de siège ne peut pas tirer en mode déplacement.");
        }
    }
}
