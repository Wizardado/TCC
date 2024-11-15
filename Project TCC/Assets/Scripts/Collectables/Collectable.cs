using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Material normal;
    public Material ativo;
    public bool lookedAt;
    private Renderer render;

    public CollectableSpawner spawn;

    void Start()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    public void Collect()
    {
        if(this.gameObject.CompareTag("Fake"))
            spawn.EmptySpace(true);
        else
            spawn.EmptySpace(true);

        Destroy(this.gameObject);
    }

    public void Focus()
    {
        lookedAt = true;
        render.material = ativo;
    }

    public void Unfocus()
    {
        lookedAt = false;
        render.material = normal;
    }
}
