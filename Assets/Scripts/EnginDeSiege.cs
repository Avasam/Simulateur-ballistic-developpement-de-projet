using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EnginDeSiegeController))]
[RequireComponent(typeof(Animator))]
public class EnginDeSiege : MonoBehaviour {
    EnginDeSiegeController controller;
    Animator animator;
    [SerializeField] GameObject childContainingProjectile;
    public ProjectilePhysics ammunition;
    public float puissance = 50f;
    [SerializeField] Vector3 projectileSpawnPosition;
    [SerializeField] Vector3 projectileSpawnRotation;

    // Use this for initialization
    void Awake() {
        if (ammunition != null) {
            if (childContainingProjectile != null) {

                animator = GetComponent<Animator>();
                controller = GetComponent<EnginDeSiegeController>();
                Recharger();

            } else {
                Debug.LogError("\"" + name + "\"'s " + GetType().Name + ".childContainingProjectile attribute cannot be null.");
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
        ProjectilePhysics loadedProjectile = Instantiate(ammunition, childContainingProjectile.transform);
        loadedProjectile.transform.localPosition = projectileSpawnPosition;
        loadedProjectile.transform.localRotation = Quaternion.Euler(projectileSpawnRotation);
        loadedProjectile.GetComponent<Rigidbody>().isKinematic = true;

        animator.SetBool("Tirer", false);
    }

    public void Tirer() {
        // First, check if the engin is in the right mode
        if (!controller.ModeDeplacement) {
            animator.SetBool("Tirer", true);
        } else {
            Debug.Log("Un engin de siège ne peut pas tirer en mode déplacement.");
        }
    }

    private void AnimLancerProjectile() {
        // Check if there's a projectile loaded
        Rigidbody loadedProjectile = null;
        ProjectilePhysics childrenComponent = GetComponentInChildren<ProjectilePhysics>();
        if (childrenComponent) {
            loadedProjectile = childrenComponent.GetComponent<Rigidbody>();
            // If so, launch it!
            loadedProjectile.transform.SetParent(null);
            loadedProjectile.isKinematic = false;
            loadedProjectile.velocity = loadedProjectile.transform.forward * puissance;
        } else {
            Debug.Log("Il n'y a aucun projectile à tirer.");
        }
    }
}
