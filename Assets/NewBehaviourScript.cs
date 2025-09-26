using UnityEngine;
using VContainer.Unity;

public class NewBehaviourScript : MonoBehaviour
{
    public VContainerSettings _settings;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _settings.GetOrCreateRootLifetimeScopeInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
