using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ProjectilePhysics : MonoBehaviour {
    public const string defaultMaterialName = "Projectile";
    [SerializeField] int waterCollidingCount = 0;
    private SphereCollider sphereCollider;
    private Rigidbody rBody;

	// Use this for initialization
	void Awake () {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        rBody = gameObject.GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider trigger) {
        if (trigger.gameObject.layer == 4) {
            waterCollidingCount++;
            rBody.drag = 5;
        }
        
    }

    private void OnTriggerExit(Collider trigger) {
        if (trigger.gameObject.layer == 4) {
            waterCollidingCount--;
            if (waterCollidingCount <= 0) {
                rBody.drag = 0;
            }
        }
        
    }


    private void OnCollisionEnter(Collision collision) {
        AdaptPhysicMaterial(collision);
    }

    private void OnCollisionStay(Collision collision) {
        AdaptPhysicMaterial(collision);
    }

    private void AdaptPhysicMaterial(Collision collision) {
        if (collision.gameObject.GetComponent<Terrain>()) {
            // Get the texture name
            int surfaceIndex = TerrainSurface.GetMainTexture(transform.position);
            string textureName = TerrainTextureDictionnary.Textures[surfaceIndex];

            // Find the appropriate material
            if (textureName.Length >= 4) {
                string physicMatName = textureName.Substring(0, 4);
                PhysicMaterial physicMat = (PhysicMaterial)Resources.Load(physicMatName);
                if (physicMat != null) {
                    sphereCollider.material = physicMat;
            
            // Dealing with problems
                } else {
                    Debug.LogWarning("Can't find Physic Material called \"" + physicMatName + "\" for Texture \"" + textureName + "\". Default Material \"" + defaultMaterialName + "\" used instead.");
                    physicMat = (PhysicMaterial)Resources.Load(defaultMaterialName);
                    if (physicMat != null) {
                        sphereCollider.material = sphereCollider.material;
                    } else {
                        Debug.LogError("Default Material \"" + defaultMaterialName + "\" not found. Please make sure the required Physic Materials are in a \"Resources\" folder.");
                    }
                }
            } else {
                Debug.LogWarning("Texture \"" + textureName + "\"'s name is too short. The start of the name should match a Physic Material in a \"Resources\" folder.");
            }
        }
    }
}
