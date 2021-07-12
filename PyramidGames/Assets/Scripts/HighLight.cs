using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HighLight : MonoBehaviour
{
    public Color HighlightColor = Color.gray;
    public LayerMask fog;
    private Collider hitObject;
    private Material hitObjectMaterial;
    private new Camera camera;
    private RaycastHit hit;
    private void Start()
    {
        camera = Camera.main;
    }
    public void Update()
    {
        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 35f, ~fog) && (hit.collider.CompareTag("Chest") || hit.collider.CompareTag("Doors")))
        {
            MarkObject();
        }
        else if (hitObject != null)
        {
            UnMarkObject();
        }
    }

    public void MarkObject()
    {
        hitObject = hit.collider;

        if (hitObject != null)
        {
            hitObjectMaterial = hitObject.GetComponent<Renderer>().material;
            hitObjectMaterial.color = HighlightColor;
        }
    }

    public void UnMarkObject()
    {
        hitObjectMaterial.color = Color.white;
        hitObject = null;
        hitObjectMaterial = null;
    }

}
