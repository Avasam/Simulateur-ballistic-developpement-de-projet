using UnityEngine;

[DisallowMultipleComponent]
public class EnginDeSiegeController : MonoBehaviour {
    
    public float vitesse = 100;
    public EnginDeSiege enginDeSiege;

	// Use this for initialization
	void Awake () {
        enginDeSiege.RigidBody = enginDeSiege.GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physic update
    void FixedUpdate () {
        // This is the mode used to roam the scene
        Vector3 movement = new Vector3(Input.GetAxis("Lateral"), Input.GetAxis("Vertical"), Input.GetAxis("Longitudinal"));
        enginDeSiege.RigidBody.velocity = enginDeSiege.transform.TransformDirection(movement * vitesse);

        // This is the mode used to adjust and shoot
        Vector3 rotation = new Vector3(0f, Input.GetAxis("Horizontal"), 0f);
        enginDeSiege.RigidBody.MoveRotation(enginDeSiege.RigidBody.rotation * Quaternion.Euler(rotation * vitesse / 50));
    }

    public void TirerEngin() {
        enginDeSiege.Tirer();
    }

}
