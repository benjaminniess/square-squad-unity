using UnityEngine;

public class CustomCameraFollow : MonoBehaviour
{
    float minZoom = 1.0f;
    float maxZoom = 1.5f;
    float zoomSpeed = 16.0f;
    float targetZoom;
    bool isMin = true;
    bool isZooming = false;

    private float originalSize = 0f;

	public Rigidbody2D rb;
    private float speed;
	public float timeOffset;
	public Vector3 posOffset;

    private Camera thisCamera;
	private Vector3 velocity;
    private Vector3 lastPosition = Vector3.zero;

    void Start() {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    void Update() {
        // Speed calculation
        speed = 10 * (rb.transform.position - lastPosition).magnitude;
        lastPosition = rb.transform.position;
        
        if ( speed > 4 && ! isZooming && isMin ) {
            isZooming = true;
            targetZoom = maxZoom;
        } else if ( speed > 0 && speed < 1.5f && ! isZooming && ! isMin ) {
            isZooming = true;
            targetZoom = minZoom;
        }

        //transform.position = Vector3.SmoothDamp(transform.position, rb.transform.position + posOffset, ref velocity, timeOffset );
        
        if ( isZooming ) {
            float targetSize = originalSize * targetZoom;
            if (targetSize != thisCamera.orthographicSize) {
                //thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
            } else {
                isZooming = false;
                isMin = isMin == true ? false : true;
            }
        }
    }
}
