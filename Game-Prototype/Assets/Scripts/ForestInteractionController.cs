using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ForestInteractionController : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 100f;
    private Animator anim;
    public PlayerData playerData;

    void Start()
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
                    case "RedMushroom":
                        Debug.Log("Clicked on RedMushroom");
                        StartCoroutine(playPickingUpAnim());
                        hit.collider.gameObject.SetActive(false);
                        playerData.redMushroomsCollected++;
                        break;
                    case "YellowMushroom":
                        Debug.Log("Clicked on YellowMushroom");
                        StartCoroutine(playPickingUpAnim());
                        hit.collider.gameObject.SetActive(false);
                        playerData.yellowMushroomsCollected++;
                        break;
                    case "SpiderLilies":
                        Debug.Log("Clicked on SpiderLilies");
                        StartCoroutine(playPickingUpAnim());
                        hit.collider.gameObject.SetActive(false);
                        playerData.spiderLiliesCollected++;
                        break;
                    default:
                        Debug.Log("Clicked on something else: " + hit.collider.tag);
                        break;
                }
            }
        }
    }

    IEnumerator playPickingUpAnim()
    {
        anim.SetBool("pickingUp", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("pickingUp", false);
    }
}