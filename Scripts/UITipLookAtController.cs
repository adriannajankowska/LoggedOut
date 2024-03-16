using UnityEngine;

public class UITipLookAtController : MonoBehaviour
{
    public Transform target;
    private Vector3 diffRotation = new Vector3(275.1f, -4.4f, -0.1f);

    private float minDistance = 0.5f;
    private float maxDistance = 3f;
    private float minScale = 0.5f;
    private float maxScale = 1f;

    private void Start()
    {
        var oldRotation = transform.rotation;
        transform.LookAt(target.position);
        transform.eulerAngles = transform.eulerAngles - diffRotation;
    }
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minDistance, maxDistance, distance));
        transform.localScale = new Vector3(scale, scale, scale);

        transform.LookAt(target);
        transform.eulerAngles = transform.eulerAngles - diffRotation;
    }
}