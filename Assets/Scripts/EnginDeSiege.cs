using UnityEngine;
using ReadOnlyDrawer;

[DisallowMultipleComponent]
public class EnginDeSiege : MonoBehaviour {
    public ProjectilePhysics ammunition;
    public float puissance;
    [SerializeField] Vector3 projectileSpawnPosition;

    // Use this for initialization
    void Awake() {
        Recharger();
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
    }

    public void LancerProjectile() {
        // First check if there's a projectile loaded
        Rigidbody loadedProjectile = null;
        ProjectilePhysics childrenComponent = GetComponentInChildren<ProjectilePhysics>();
        if (childrenComponent) { loadedProjectile = childrenComponent.GetComponent<Rigidbody>(); }
        // If so, launch it!
        if (loadedProjectile) {
            loadedProjectile.isKinematic = false;
            loadedProjectile.velocity = transform.forward * puissance;
        }
    }
}
