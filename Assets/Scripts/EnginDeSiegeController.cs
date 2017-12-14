using UnityEngine;

[DisallowMultipleComponent]
public class EnginDeSiegeController : MonoBehaviour {
    
    public float vitesse = 100;
    public EnginDeSiege enginDeSiege;
    [ExposeProperty] public bool ModeDeplacement {
        get { return enginDeSiege.ModeDeplacement; }
        set { enginDeSiege.ModeDeplacement = value; }
    }

	// Use this for initialization
	void Awake () {
        enginDeSiege.RigidBody = enginDeSiege.GetComponent<Rigidbody>();
        ModeDeplacement = true;
    }

    // FixedUpdate is called once per physic update
    void FixedUpdate () {
        // This is the mode used to roam the scene
        if (ModeDeplacement) {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Longitudinal"));
            enginDeSiege.RigidBody.velocity = movement * vitesse;
        // This is the mode used to adjust and shoot
        } else {
            Vector3 rotation = new Vector3(Input.GetAxis("Longitudinal"), Input.GetAxis("Horizontal"), 0f);
            enginDeSiege.RigidBody.MoveRotation(enginDeSiege.RigidBody.rotation * Quaternion.Euler(rotation * vitesse / 50));
        }
    }

    public void TirerEngin() {
        if (!ModeDeplacement) {
            enginDeSiege.Tirer();
        } else {
            Debug.Log("Un engin de siège ne peut pas tirer en mode déplacement.");
        }
    }

}
