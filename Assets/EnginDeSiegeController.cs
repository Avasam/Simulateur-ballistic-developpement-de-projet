using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class EnginDeSiegeController : MonoBehaviour {
    private Rigidbody rigidBody;
    public float vitesse = 100;
    public bool controlled;
    [HideInInspector, SerializeField] private bool modeDeplacement = true;
    [ExposeProperty] public bool ModeDeplacement {
        get { return modeDeplacement; }
        set {
            if (value) {
                rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            } else {
                rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
            modeDeplacement = value;
        }
    }

	// Use this for initialization
	void Awake () {
        rigidBody = GetComponent<Rigidbody>();
        ModeDeplacement = true;
    }

    // FixedUpdate is called once per physic update
    void FixedUpdate () {
        // Only act on the siege engine if it's currently being controlled
        if (controlled) {
            // This is the mode used to roam the scene
            if (ModeDeplacement) {
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Longitudinal"));
                rigidBody.velocity = movement * vitesse;
            // This is the mode used to adjust and shoot
            } else {
                Vector3 rotation = new Vector3(0f, Input.GetAxis("Horizontal"), 0f);
                rigidBody.angularVelocity = rotation * vitesse / 50;
            }
        }
    }

    public void SetControlled(bool control) {
        controlled = control;
    }

}
