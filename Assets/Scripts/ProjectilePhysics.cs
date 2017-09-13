using UnityEngine;

public class ProjectilePhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

    }

    private void OnCollisionEnter(Collision collision) {
        Foo(collision);
    }

    private void OnCollisionStay(Collision collision) {
        Foo(collision);
    }

    private void Foo(Collision collision) {
        if (collision.gameObject.GetComponent<Terrain>()) {
            var surfaceIndex = TerrainSurface.GetMainTexture(transform.position);
            Debug.Log(TerrainTextureDictionnary.Textures[surfaceIndex]);
        }
    }
}
