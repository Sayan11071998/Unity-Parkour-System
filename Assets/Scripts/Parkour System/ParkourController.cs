using System.Collections;
using UnityEngine;

public class ParkourController : MonoBehaviour
{

    private EnvironmentScanner environmentScanner;
    private Animator animator;
    private PlayerController playerController;

    private bool inAction;

    private void Awake()
    {
        environmentScanner = GetComponent<EnvironmentScanner>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && !inAction)
        {
            var hitData = environmentScanner.ObstacleCheck();

            if (hitData.forwardHitFound)
            {
                StartCoroutine(DoParkourAction());
            }
        }
    }

    IEnumerator DoParkourAction()
    {
        inAction = true;
        playerController.SetControl(false);
        animator.CrossFade("StepUp", 0.2f);
        yield return null;

        var animState = animator.GetNextAnimatorStateInfo(0);
        yield return new WaitForSeconds(animState.length);

        playerController.SetControl(true);
        inAction = false;
    }
}