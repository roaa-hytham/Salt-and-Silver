using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MarketInteractionController : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 100f;
    private Animator anim;
    public Animator ArabGirlAnim;
    public PlayerData playerData;
    public GameObject GroceryBag;
    public GameObject DialoguePanel;
    public TMP_Text DialogueTxt;
    private int totalCoins = 0;

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
                    case "Tomato":
                        Debug.Log("Clicked on Tomato");
                        StartCoroutine(playPickingUpAnim());
                        hit.collider.gameObject.SetActive(false);
                        playerData.tomatoesBought++;
                        totalCoins += 5;
                        break;
                    case "Bread":
                        Debug.Log("Clicked on Bread");
                        StartCoroutine(playPickingUpAnim());
                        hit.collider.gameObject.SetActive(false);
                        playerData.breadBought++;
                        totalCoins += 2;
                        break;
                    case "Eggplant":
                        Debug.Log("Clicked on Eggplant");
                        StartCoroutine(playPickingUpAnim());
                        hit.collider.gameObject.SetActive(false);
                        playerData.eggplantsBought++;
                        totalCoins += 3;
                        break;
                    case "ArabGirl":
                        Debug.Log("Clicked on ArabGirl");
                        StartCoroutine(talkingWithArabGirl());
                        break;
                    case "GroceryBag":
                        Debug.Log("Clicked on GroceryBag");
                        hit.collider.gameObject.SetActive(false);
                        playerData.hasGroceryBag = true;
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

    IEnumerator talkingWithArabGirl()
    {
        //ArabGirlAnim.SetBool("isTalking", true);
        //anim.SetBool("isTalking", true);
        DialoguePanel.SetActive(true);
        DialogueTxt.text = "Megan: I would like to buy these, please.";
        yield return new WaitForSeconds(2f);
        DialogueTxt.text = "Market Girl: Sure, This will be " + totalCoins + " coins in total.";
        yield return new WaitForSeconds(2f);
        DialogueTxt.text = "Megan: Here you go.";
        playerData.coins -= totalCoins;
        yield return new WaitForSeconds(2f);
        //anim.SetBool("isTalking", false);
        //ArabGirlAnim.SetBool("isTalking", false);
        DialoguePanel.SetActive(false);
        GroceryBag.SetActive(true);
    }
}
