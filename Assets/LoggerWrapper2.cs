using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Net.WebSockets;

public class LoggerWrapper2 : MonoBehaviour
{
    private UnityLogger logger = new();
    public UnityLogger Logger => logger;
    
    private int[] ints = new int[100];

    private void Awake()
    {
        for(int i = 0; i < ints.Length; i++)
        {
            ints[i] = Random.Range(0, 100);
        }
        Debug.Log("Массив создан");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { Logger.LogCollection(SearchMoreThan(10,ints)); }

        if (Input.GetKeyDown(KeyCode.W)) { Logger.LogCollection(DivisibleBy(5, ints)); }

        if (Input.GetKeyDown(KeyCode.E)) { Logger.LogCollection(SearchAnyPositive(ints)); }

        if (Input.GetKeyDown(KeyCode.R)) { Logger.LogCollection(SearchAllPositive(ints)); }

        if (Input.GetKeyDown(KeyCode.T)) 
        {
            var result = SearchMoreThan(10, ints).ToList<int>();
            Debug.Log($"Массив переведен в список. Результат:");
            Logger.LogCollection(result);
        }
    }

    private IEnumerable<int> SearchMoreThan(int n,IEnumerable<int> list)
    {
        var result = from i in list
                     where i > n
                     orderby i
                     select i;
        return result;
    }

    private bool DivisibleBy(int n,IEnumerable<int> list)
    {
        var result = list.Any(i => i % n == 0);

        return result;
    }

    private bool SearchAnyPositive(IEnumerable<int> list) 
    {
        var result = list.Any(i => i >= 0);
        return result;
    }

    private bool SearchAllPositive(IEnumerable<int> list)
    {
        var result = list.All(i => i >= 0);
        return result;
    }
}
