using UnityEngine;

public class CollectableLocalControl : MonoBehaviour
{
    public CollectableSpawner [] spawns;
    public int fruitMinimum;

    [Header("Publico que set automático, não mude")]
    public MasterCollectable master;
    public int spanwNumber;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CreateCollectables(bool animalHere)
    {
        int spawnsNow = Random.Range(fruitMinimum, spawns.Length);

        while(spawnsNow > 0)
        {
            int randomSpawn = Random.Range(0, spawns.Length);
            
            if(spawns[randomSpawn].full)
                continue;

            spawns[randomSpawn].CreateFake();

            spawnsNow--;
        }

        if(animalHere)
        {
            SpawnAnimal();
        }
    }

    public void SpawnAnimal()
    {
        bool animalCreated = false;

        while(!animalCreated)
        {
            int randomSpawn = Random.Range(0, spawns.Length);
            
            if(spawns[randomSpawn].full)
                continue;
            
            spawns[randomSpawn].CreateAnimal();
            animalCreated = true;
        }
    }

    public void ClearCollectables()
    {
        for(int i = 0; i < spawns.Length; i++)
        {
            spawns[i].ClearSpaces();
        }
    }

    public void ScareAnimal()
    {
        for(int i = 0; i < spawns.Length; i++)
        {
            spawns[i].AnimalRun();
        }
    }
}
