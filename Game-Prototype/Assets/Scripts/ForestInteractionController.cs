using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ForestInteractionController : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 100f;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left-click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                switch (hit.collider.tag)
                {
                    case "RedMushroom":
                        Debug.Log("Clicked on RedMushroom");
                        //StartCoroutine(playPressBtnAnim());
                        break;

                    //case "Food":
                    //    Debug.Log("Clicked on Food");
                    //    hit.collider.gameObject.SetActive(false);
                    //    break;

                    //case "LightSwitch":
                    //    Debug.Log("Clicked on LightSwitch");
                    //    StartCoroutine(playPressBtnAnim());
                    //    toggleLight();
                    //    break;

                    default:
                        Debug.Log("Clicked on something else: " + hit.collider.tag);
                        break;
                }
            }
        }
    }

    //IEnumerator playPressBtnAnim()
    //{
    //    anim.SetBool("pressBtn", true);
    //    yield return new WaitForSeconds(1);
    //    anim.SetBool("pressBtn", false);
    //}
}