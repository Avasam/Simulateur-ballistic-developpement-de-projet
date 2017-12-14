using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowEngin : MonoBehaviour {
    public Transform target;
    [SerializeField] float zoom = 1;
    public float Zoom {
        get { return zoom; }
        set { zoom = value; }
    }
    public const float maxZoomOut = 8;

    private Camera myCamera;

    // Use this for initialization
    private void Start() {
        if ((myCamera = GetComponent<Camera>()) == null) {
            myCamera = gameObject.AddComponent<Camera>();
            Debug.LogWarning("A Camera Component is required for " + GetType().Name + " and has been added to " + gameObject.name + ".");
        }
        transform.parent = null;
    }


    // Update is called once per frame
    private void Update() {
        CameraUpdate();
    }

    private void CameraUpdate() {
        if (zoom < 1) zoom = 1;
        myCamera.orthographicSize = maxZoomOut / zoom;

        if (target) {
            Quaternion newRotation = target.rotation;
            transform.rotation = newRotation;
            //transform.position = newPos;
            //transform.SetPositionAndRotation(newPosition, newRotation)

        }
    }
}
