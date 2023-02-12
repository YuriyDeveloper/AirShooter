using UnityEngine;
using System.Collections.Generic;

public class Services 
{
    private static Dictionary<string, IService> _allServices;
    public Dictionary<string, IService> AllServices { get { return _allServices; } }

    public Services()
    {
        _allServices = new Dictionary<string, IService>();
    }

    public void Register(string serviceName, IService service)
    {
        if (_allServices.TryGetValue(serviceName, out service))
        {
            return;
        }
        else
        {
            _allServices.Add(serviceName, service);
        }
        
    }
    public IService GetService(string serviceName)
    {
        if (_allServices.TryGetValue(serviceName, out IService service))
        {
            return _allServices[serviceName];
        }
        else
        {
            Debug.Log("this service is not registered");
            return null;
        }
    }
}
