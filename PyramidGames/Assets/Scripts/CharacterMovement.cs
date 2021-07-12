using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public int moveSpeed;
    public LayerMask fog;
    private Vector3 destination;
    private new Camera camera;
   

    void Start()
    {
        camera = Camera.main;
        destination = transform.position;
    }

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 35f, ~fog))
            {
                destination = hit.point;
            }
        }
    }

    private void FixedUpdate()
    {

        float dis = Vector3.Distance(transform.position, destination);
        if (dis > 0)
        {
            float moveDis = Mathf.Clamp(moveSpeed * Time.fixedDeltaTime, 0, dis);

            Vector3 move = (destination - transform.position).normalized * moveDis;
            transform.Translate(move);
        }
    }
}
