using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject animal;
    public GameObject fake;
    public bool full;
    public bool animalSpawned;

    private Collectable collectableHere;
    public CollectableLocalControl control;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CreateFake()
    {
        GameObject CollectableInstantiated = (GameObject) Instantiate(fake, this.transform.position, this.transform.rotation, this.transform);
        collectableHere = CollectableInstantiated.GetComponent<Collectable>();
        collectableHere.spawn = this;
        full = true;
    }

    public void CreateAnimal()
    {
        GameObject CollectableInstantiated = (GameObject) Instantiate(animal, this.transform.position, this.transform.rotation, this.transform);
        collectableHere = CollectableInstantiated.GetComponent<Collectable>();
        collectableHere.spawn = this;
        full = true;
        animalSpawned = true;
    }

    public void ClearSpaces()
    {
        full = false;
        if(collectableHere == null)
            return;

        Destroy(collectableHere.gameObject);
        collectableHere = null;
    }

    public void EmptySpace(bool fake)
    {
        full = false;

        if(fake)
            control.ScareAnimal();
    }

    public void AnimalRun()
    {
        if(!animalSpawned)
            return;

        Destroy(collectableHere.gameObject);
        collectableHere = null;

        animalSpawned = false;
        full = false;

        control.master.RecreateAnimal(control.spanwNumber);
    }
}
