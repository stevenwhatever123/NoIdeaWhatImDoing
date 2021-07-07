using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    float rayLength = 2f;

    void Update()
    {
        // Draw ray on Gizmos
        Vector3 forward = transform.TransformDirection(Vector3.forward) * rayLength;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    public void OnSelect()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        // Shoot Ray for object selection, if it hits, do something.
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            float distanceError = rayLength - hit.distance;
            if(distanceError > 0)
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    print(selectionRenderer.name);
                    /*
                    Vector3 raycastEndPoint = forward;
                    selection.transform.position = raycastEndPoint;
                    */
                }
            }
        }
    }
}
