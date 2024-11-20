using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;

    private GameManager manager;

    public float interactionRange;

    public Transform interactor;

    private IInteracteable interactable;

    public UnityEvent OnInteractionStarted;
    public UnityEvent OnInteractionStopped;
    private IInteracteable cachedInteractionTarget;

    [SerializeField] Rigidbody rb;


    [SerializeField] float impulseForce;

    [SerializeField]private float impulseCooldown;
    private float currentImpulseCooldown;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.Fire();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                if (currentImpulseCooldown <= 0)
                {
                    rb.AddRelativeForce(Vector3.forward * impulseForce, ForceMode.Impulse);
                    currentImpulseCooldown = impulseCooldown;
                }
            }

            if (Input.GetButtonDown("Reload"))
            {
                weapon.Reload();
            }


            RaycastHit hit;
            Ray r = new Ray(interactor.position, interactor.forward);


            if (Physics.Raycast(r, out hit, interactionRange))
            {
                interactable = hit.transform.GetComponent<IInteracteable>();

                
            } else
            {
                interactable = null;
            }


            if (interactable != cachedInteractionTarget)
            {
                cachedInteractionTarget = interactable;

                if (interactable != null)
                {
                    if (OnInteractionStarted != null)
                    {
                        OnInteractionStarted.Invoke();
                    }
                } else
                {
                    if (OnInteractionStopped != null)
                    {
                        OnInteractionStopped.Invoke();
                    }
                }
            }



            if (Input.GetButtonDown("Interact"))
            {
                if (interactable != null)
                {
                    interactable.Interact(gameObject);

                }
            }

            if (currentImpulseCooldown >= 0)
            {
                currentImpulseCooldown -= Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            manager.ChangePauseState();
        }
    }
}
