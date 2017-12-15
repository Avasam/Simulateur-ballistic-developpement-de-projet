using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectilePhysics : MonoBehaviour {
    public const string defaultMaterialName = "Dirt";
    [SerializeField] int waterCollidingCount = 0;
    [SerializeField] Collider dynamicCollider;
    private Rigidbody rBody;
    private int waterLayerID;
    private bool noCollisionYet = true;

    // Use this for initialization
    void Awake () {
        if (dynamicCollider != null) {
            waterCollidingCount = 0;
            noCollisionYet = true;
            rBody = gameObject.GetComponent<Rigidbody>();
            waterLayerID = LayerMask.NameToLayer("Water");
        } else {
            Debug.LogError("\"" + name + "\"'s "+ GetType().Name + ".dynamicCollider attribute cannot be null.");
        }
    }

    private void Update() {
        Debug.DrawRay(transform.position, rBody.velocity);
    }

    private void FixedUpdate() {
        // Only check if the projectile is moving
        if (!(rBody.velocity == Vector3.zero || rBody.isKinematic)) {
            RaycastHit hitInfo = new RaycastHit();
            bool raycastHit = rBody.SweepTest(rBody.velocity, out hitInfo);
            if (raycastHit) {
                AdaptPhysicMaterial(hitInfo);
            }
            if (noCollisionYet) {
                rBody.MoveRotation(Quaternion.Euler(rBody.velocity));
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        noCollisionYet = false;
    }

    private void OnTriggerEnter(Collider trigger) {
        if (trigger.gameObject.layer == waterLayerID) {
            waterCollidingCount++;
            rBody.drag = 5;
        }
        
    }

    private void OnTriggerExit(Collider trigger) {
        if (trigger.gameObject.layer == waterLayerID) {
            waterCollidingCount--;
            if (waterCollidingCount <= 0) {
                rBody.drag = 0;
            }
        }
        
    }

    private void AdaptPhysicMaterial(RaycastHit hitInfo) {
        if (hitInfo.collider.GetComponent<Terrain>()) {
            if (TerrainTextureDictionnary.Textures != null) {
                // Get the texture name
                int surfaceIndex = TerrainSurface.GetMainTexture(hitInfo.point);
                string textureName = TerrainTextureDictionnary.Textures[surfaceIndex];

                // Find the appropriate material
                if (textureName.Length >= 4) {
                    string physicMatName = textureName.Substring(0, 4);
                    PhysicMaterial physicMat = (PhysicMaterial)Resources.Load(physicMatName);
                    if (physicMat != null) {
                        this.dynamicCollider.material = physicMat;

              // Dealing with problems
                    } else {
                        Debug.LogWarning("Can't find Physic Material called \"" + physicMatName + "\" for Texture \"" + textureName + "\". Default Material \"" + defaultMaterialName + "\" used instead.");
                        physicMat = (PhysicMaterial)Resources.Load(defaultMaterialName);
                        if (physicMat != null) {
                            this.dynamicCollider.material = this.dynamicCollider.material;
                        } else {
                            Debug.LogError("Default Material \"" + defaultMaterialName + "\" not found. Please make sure the required Physic Materials are in a \"Resources\" folder.");
                        }
                    }
                } else {
                    Debug.LogWarning("Texture \"" + textureName + "\"'s name is too short. The start of the name should match a Physic Material in a \"Resources\" folder.");
                }
            } else {
                Debug.LogError("TerrainTextureDictionnary.Textures not set. Please make sure the Terrain \"" + hitInfo.collider.name + "\" has a TerrainTextureDictionnary Component.");
            }
        }
    }
}
