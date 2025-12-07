using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionController : MonoBehaviour
{
    public PlayerData PlayerData;
    public Camera cam;
    public float rayDistance = 100f;
    private Animator anim;
    public Light light;
    public Light light2;

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
                        PlayerData.coins += PlayerData.coinsCollected;
                        PlayerData.coinsRegistered = true;
                        break;

                    case "Food":
                        Debug.Log("Clicked on Food");
                        hit.collider.gameObject.SetActive(false);
                        PlayerData.foodCollected++;
                        break;

                    case "LightSwitch":
                        Debug.Log("Clicked on LightSwitch");
                        StartCoroutine(playPressBtnAnim());
                        toggleLight();
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
        yield return new WaitForSeconds(1);
        anim.SetBool("pressBtn", false);
    }

    private void toggleLight()
    {
        light.enabled = !light.enabled;
        light2.enabled = light.enabled;
        if (light.enabled)
        {
            PlayerData.restaurantLightsOff = false;
        }
        else
        {
            PlayerData.restaurantLightsOff = true;
        }
        Debug.Log("Light toggled. Now: " + (light.enabled ? "ON" : "OFF"));
        Debug.Log("Light2 toggled. Now: " + (light2.enabled ? "ON" : "OFF"));
    }

}