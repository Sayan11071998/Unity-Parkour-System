using UnityEngine;

public class ClimbController : MonoBehaviour
{
    private EnvironmentScanner envScanner;

    private void Awake()
    {
        envScanner = GetComponent<EnvironmentScanner>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            if (envScanner.ClimbLedgeCheck(transform.forward, out RaycastHit ledgeHit))
            {
                Debug.Log("Climb Ledge Found!");
            }
        }
    }
}