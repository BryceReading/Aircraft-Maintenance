using UnityEngine;

public class twmp : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float cameraDistance = 10.0f;
    public float cameraHeight = 5.0f;

    private Vector3 meshCenter;
    private Vector3 meshSize;
    public Camera top;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = top.transform;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        Bounds bounds = mesh.bounds;
        top.clearFlags = CameraClearFlags.SolidColor;
        top.backgroundColor = Color.gray;

        top.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - bounds.size.z *transform.localScale.z);

        float maxDimension = Mathf.Max(bounds.size.x*transform.localScale.x, bounds.size.y * transform.localScale.y, bounds.size.z * transform.localScale.z);
        top.orthographicSize = maxDimension;
    }

    void Update()
    {
        
    }
}