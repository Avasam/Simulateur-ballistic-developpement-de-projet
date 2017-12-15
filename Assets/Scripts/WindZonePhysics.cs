using UnityEngine;
//Must comment out for build
//using ReadOnlyDrawer;

[DisallowMultipleComponent]
[RequireComponent(typeof(WindZone))]
public class WindZonePhysics : MonoBehaviour {
    public float Direction {
        get { return transform.rotation.y;  }
        set { transform.rotation = Quaternion.Euler(0f, value, 0f);  }
    }
    //Must comment out for build
    //[ReadOnly]
    public WindZone referedComponent;
    public float Strength {
        get { return referedComponent.windMain / windAdjustment; }
        set { referedComponent.windMain = value / windAdjustment; }
    }
    public float Turbulence {
        get { return referedComponent.windTurbulence; }
        set { referedComponent.windTurbulence = value; }
    }
    public string lookForTag = "Projectile";
    [SerializeField] int windAdjustment = 15;

    // Use this for initialization
    void Awake () {
        referedComponent = GetComponent<WindZone>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Rigidbody[] rbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody projectile in rbodies) {
            if (projectile.CompareTag(lookForTag)) {
                BlowOn(projectile);
            }

        }
    }

    private void BlowOn(Rigidbody projectile) {
        float turbulence = Turbulence * UnityEngine.Random.value;
        projectile.AddForce(transform.forward * turbulence * Strength * Mathf.Pow(windAdjustment,2.5f));
    }
}
