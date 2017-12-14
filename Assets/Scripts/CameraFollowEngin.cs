using UnityEngine;

[RequireComponent(typeof(EnginDeSiegeController))]
[RequireComponent(typeof(Camera))]
public class CameraFollowEngin : MonoBehaviour {
    EnginDeSiegeController enginDeSiegeController;
    [SerializeField] float zoom = 1;
    public float Zoom {
        get { return zoom; }
        set { zoom = value; }
    }
    public const float maxZoomOut = 8;
    public float angle = 45f;
    public float zoomOut = 30f;

    private Camera myCamera;

    // Use this for initialization
    private void Start() {
        if ((myCamera = GetComponent<Camera>()) == null) {
            myCamera = gameObject.AddComponent<Camera>();
            Debug.LogWarning("A Camera Component is required for " + GetType().Name + " and has been added to " + gameObject.name + ".");
        }
        enginDeSiegeController = GetComponent<EnginDeSiegeController>();
        transform.parent = null;
    }


    // Update is called once per frame
    private void Update() {
        CameraUpdate();
    }

    private void CameraUpdate() {
        if (zoom < 1) zoom = 1;
        myCamera.orthographicSize = maxZoomOut / zoom;

        if (enginDeSiegeController.enginDeSiege) {
            Vector3 newRotation = enginDeSiegeController.enginDeSiege.transform.rotation.eulerAngles;
            newRotation.x = angle;
            transform.rotation = Quaternion.Euler(newRotation);

            // Reset the local position before using the angle to move away
            transform.position = enginDeSiegeController.enginDeSiege.transform.position;
            transform.position -= transform.forward * zoomOut;
        }
    }
}
