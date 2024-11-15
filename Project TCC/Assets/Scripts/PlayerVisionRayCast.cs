using UnityEngine;

public class PlayerVisionRayCast : MonoBehaviour
{
    Vector2 centro;
    public float distance;

    public bool closer;
    public UIControl UIcontrol;

    [Header("Coletavel")]

    public Collectable collectable;
    private Collectable oldCollectable;
    public GameObject tip;

    [Header("Animal Control")] //May change this code location later

    public int animalCaptured;
    public int animalCaptureLimit;
    public bool animalInHands;
    public GameObject animalBeingHeld;
    
    void Start()
    {
        centro = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        if(UIcontrol.paused)
            return;

        Ray visionRay = Camera.main.ScreenPointToRay(centro);

        //Debug.DrawRay(visionRay.origin, visionRay.direction, Color.magenta, distance);

        RaycastHit hit;

        if(animalInHands) // May change this to check to end level in the future
            return;

        if (Physics.Raycast(visionRay, out hit, distance/10))
        {
            if (hit.collider.CompareTag("Animal") || hit.collider.CompareTag("Fake"))
            {
                collectable = hit.transform.GetComponent<Collectable>();

                if(oldCollectable != collectable && oldCollectable != null)
                    oldCollectable.Unfocus();

                oldCollectable = collectable;
                closer = true;

                if(!collectable.lookedAt)
                {
                    collectable.Focus();
                }
            }
        }
        else
        {
            closer = false;
        }

        if(closer)
        {
            if(!tip.activeSelf)
                tip.SetActive(true);

            if(Input.GetMouseButtonDown(0))
            {
                collectable.Collect();
                collectable = null;

                if (hit.collider.CompareTag("Animal"))
                {
                    animalCaptured++;
                }
            }
        }
        else
        {
            if(tip.activeSelf)
                tip.SetActive(false);

            if(collectable != null)
            {
                if(collectable.lookedAt)
                    collectable.Unfocus();
            }
        }

        if(animalCaptured >= animalCaptureLimit) //may ChangeLocation Later
        {
            animalInHands = true;
            tip.SetActive(false);
            animalBeingHeld.SetActive(true);
        }
    }
}
