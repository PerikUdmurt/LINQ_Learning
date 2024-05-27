using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoggerWrapper : MonoBehaviour
{
    private UnityLogger logger = new();

    public UnityLogger Logger => logger;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            List<string> stringsList = new List<string>() { "STR", "StringTwo", "StringThree" };
            string[] stringsArray = new string[] { "STRARR", "StringArrTwo" };
            IEnumerable<string> onlyUpperCase = stringsList.Where(str => str.All(ch => char.IsUpper(ch))); // �������� �� ������, ��� ������� � upperCase

            Logger.LogCollection(stringsList);
            Logger.LogCollection(stringsArray);
            Logger.LogCollection(onlyUpperCase);
        }
    }
}

public class UnityLogger
{
    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void Log(int message)
    {
        Debug.Log(message);
    }

    public void Log(bool message)
    {
        Debug.Log(message); 
    }

    public void LogCollection(IEnumerable<string> strs)
    {
        foreach (string str in strs)
        {
            Log(str);
        }
    }
    public void LogCollection(IEnumerable<int> ints)
    {
        foreach (int i in ints)
        {
            Log(i);
        }
    }
    public void LogCollection(bool value)
    {
            Log(value);
    }
}



