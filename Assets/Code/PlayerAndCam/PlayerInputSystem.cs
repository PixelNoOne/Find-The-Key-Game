using System;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public float distanceToTake = 7f;
    public float rayLength = 7f;
    public GameObject furniture;
    public WorldFurniture furnitureINeedRemember;
    public event Action Interact;
    public bool isLookingBox;

    void Start()
    {

    }
    private void Update()
    {
        bool pressedE = Input.GetKeyDown(KeyCode.E);
        var eye = Camera.main.transform;
        Ray ray = new Ray(eye.position, eye.forward);
        RaycastHit hit;
        isLookingBox = false;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.GetComponent<WorldFurniture>())
            {
                furniture = hit.collider.gameObject;
                furnitureINeedRemember = furniture.GetComponent<WorldFurniture>();
                if (furnitureINeedRemember.youCanOpen == true)
                {
                    isLookingBox = true;
                }
            }
        }
        if(pressedE && isLookingBox)
        {
            Interact?.Invoke();
        }
    }
}
