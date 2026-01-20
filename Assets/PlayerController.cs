using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed = 1f;
    [SerializeField] private InventoryDisplayController inventoryDisplayController;

    [SerializeField] private List<Seed> startSeeds;

    private List<Seed> seeds;
    private int selectionIndex;

    private void Start()
    {
        seeds = new List<Seed>(startSeeds);
        inventoryDisplayController.UpdateItemImages(seeds);
        selectionIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();

        playerTransform.position += (Vector3) movement * Time.deltaTime * speed;

        if (playerInput.actions["SwitchItemLeft"].WasPerformedThisFrame()) {
            selectionIndex--;
            if (selectionIndex < 0)
                selectionIndex = seeds.Count - 1;
        } else if (playerInput.actions["SwitchItemRight"].WasPerformedThisFrame()) {
            selectionIndex++;
            if (selectionIndex >= seeds.Count)
                selectionIndex = 0;
        }

        RaycastHit2D hit = Physics2D.Raycast(
                playerTransform.position - Vector3.forward,
                Vector3.forward,
                2f,
                LayerMask.GetMask("Plantation"));
        if (hit)
        {
            PlantationController plantation = hit.collider.GetComponent<PlantationController>();

            if (playerInput.actions["Interact"].WasPerformedThisFrame())
            {
                if (plantation.plantedSeed == null)
                {
                    if (seeds.Count > 0)
                    {
                        plantation.Plant(seeds[selectionIndex]);
                        seeds.RemoveAt(selectionIndex);
                        if (selectionIndex != 0)
                            selectionIndex--;
                        inventoryDisplayController.UpdateItemImages(seeds);
                    }
                }
                else if (plantation.IsReadyToHarvert)
                {
                    // On peut faire des trucs avec la récolte!!
                }
            }
        }
    }
}
