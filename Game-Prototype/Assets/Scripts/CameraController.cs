using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject firstPersonRig;
    public GameObject thirdPersonRig;
    private bool isFirstPerson = false;

    void Start()
    {
        SetCameraMode(isFirstPerson);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            SetCameraMode(isFirstPerson);
        }
    }

    private void SetCameraMode(bool firstPerson)
    {
        if (firstPersonRig != null)
            firstPersonRig.SetActive(firstPerson);

        if (thirdPersonRig != null)
            thirdPersonRig.SetActive(!firstPerson);
    }
}