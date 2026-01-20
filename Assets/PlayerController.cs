using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed = 1f;

    [SerializeField] private Seed seed;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();

        playerTransform.position += (Vector3) movement * Time.deltaTime * speed;

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
                    plantation.Plant(seed);
                else if (plantation.IsReadyToHarvert)
                {
                    // On peut faire des trucs avec la récolte!!
                }
            }
        }
        

        
    }
}
