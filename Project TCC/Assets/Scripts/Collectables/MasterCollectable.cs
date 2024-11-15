using UnityEngine;

public class MasterCollectable : MonoBehaviour
{
    public CollectableLocalControl[] controls;
    public PlayerVisionRayCast animalCount;

    void Start()
    {
        SetControls();
        CreateAllCollectables();
    }

    void Update()
    {
        
    }

    public void CreateAllCollectables()
    {
        int animalPlace = Random.Range(0, controls.Length);

        for(int i = 0; i < controls.Length; i++)
        {
            if(i == animalPlace)
                controls[i].CreateCollectables(true);
            else
                controls[i].CreateCollectables(false);
        }
        
    }

    public void RecreateAnimal(int lastPlace)
    {
        if(animalCount.animalCaptured >= animalCount.animalCaptureLimit -1)
            return;

        int animalPlace = Random.Range(0, controls.Length);

        while(animalPlace == lastPlace)
        {
            animalPlace = Random.Range(0, controls.Length);
        }

        controls[animalPlace].SpawnAnimal();
    }

    void SetControls()
    {
        for(int i = 0; i < controls.Length; i++)
        {
            controls[i].master = this;
            controls[i].spanwNumber = i;
        }
    }
}
