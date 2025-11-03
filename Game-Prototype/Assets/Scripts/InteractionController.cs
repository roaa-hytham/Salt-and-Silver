using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionController : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 100f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left-click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                switch (hit.collider.tag)
                {
                    case "CashRegister":
                        Debug.Log("Clicked on CashRegister");
                        StartCoroutine(playPressBtnAnim());
                        break;

                    case "Food":
                        Debug.Log("Clicked on Food");
                        hit.collider.gameObject.SetActive(false);
                        break;

                    default:
                        Debug.Log("Clicked on something else: " + hit.collider.tag);
                        break;
                }
            }
        }
    }

    IEnumerator playPressBtnAnim()
    {
        anim.SetBool("pressBtn", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("pressBtn", false);
    }

}