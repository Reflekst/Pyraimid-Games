using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterUse : MonoBehaviour
{
    
    private  Camera camera;
    public GameObject dialogWindow;
    public LayerMask fog;
    private DialogPrinter dialogPrinter;
    private GameRules rules;

    void Start()
    {
        camera = Camera.main;
        
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 35f, ~fog))
            {
                if (hit.collider.CompareTag("Chest"))
                {
                    GetComponents();
                    if (!rules.keySpawned)
                    {
                        dialogPrinter.PrintMiddleText("chest","Open?" , true);
                    }
                    else
                    {
                        dialogPrinter.PrintMiddleText("chest","You already open the chest", false);
                    }
                }
                else if(hit.collider.CompareTag("Door"))
                {
                    GetComponents();
                    if (!rules.hasKey)
                    {
                        dialogPrinter.PrintMiddleText("door","“You need a key!", false);
                    }
                    else
                    {
                        dialogPrinter.PrintMiddleText("door", "Open?", true);
                    }
                }
                else if (hit.collider.CompareTag("Key"))
                {
                    dialogPrinter.PrintMiddleText("key","Take?", true);
                    //Destroy key
                }

            }
        }
    }

    void GetComponents()
    {
        dialogPrinter = dialogWindow.GetComponent<DialogPrinter>();
        rules = GetComponent<GameRules>();
    }
}
