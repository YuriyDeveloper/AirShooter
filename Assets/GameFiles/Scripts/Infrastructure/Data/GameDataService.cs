using System.Collections.Generic;

public class GameDataService : IGameData
{
    private const string STATS_INT = "intStats";
    private const string STATS_FLOAT = "floatStats";
    private const string STATS_STRING = "stringStats";
    private static SaveSystem _saveSystem;
    public static StatsDataSet statsDataSet;
    private static DictionaryStringInt intStats = new DictionaryStringInt();
    private static DictionaryStringFloat floatStats = new DictionaryStringFloat();
    private static DictionaryStringString stringStats = new DictionaryStringString();

    private StatsDataSet GetStatsDataSet()
    {
        if (statsDataSet == null)
        {
            statsDataSet = new StatsDataSet();
        }
        return statsDataSet;
    }
    private SaveSystem GetSaveSystem()
    {
        if (_saveSystem == null)
        {
            _saveSystem = new SaveSystem();
        }
        return _saveSystem;
    }
    public void DataSave()
    {
        GetStatsDataSet();
        if (statsDataSet.Count == 0)
        {
            statsDataSet.Add(STATS_INT, intStats);
            statsDataSet.Add(STATS_FLOAT, floatStats);
            statsDataSet.Add(STATS_STRING, stringStats);
        }
        GetSaveSystem().Save(statsDataSet);
    }
    public void DataLoad()
    {
        statsDataSet = GetSaveSystem().Load();
        if (statsDataSet != null)
        {
            intStats = (DictionaryStringInt)statsDataSet[STATS_INT];
            floatStats = (DictionaryStringFloat)statsDataSet[STATS_FLOAT];
            stringStats = (DictionaryStringString)statsDataSet[STATS_STRING];
        }
    }

    public void IncreaseInt(string parameterName, int value = 1)
    {
        int defaultValue = 0;
        if (!intStats.TryGetValue(parameterName, out defaultValue))
        {
            intStats.Add(parameterName, defaultValue + value);
        }
        else
        {
            intStats[parameterName] += value;
        }

        //GameManager.instance.SearchGotAchievement(parameterName);
    }

    public void IncreaseFloat(string parameterName, float value = 1f)
    {
        float defaultValue = 0;
        if (!floatStats.TryGetValue(parameterName, out defaultValue))
        {
            floatStats.Add(parameterName, defaultValue + value);
        }
        else
        {
            floatStats[parameterName] += value;
        }
       // GameManager.instance.SearchGotAchievement(parameterName);
    }

    public List<string> GetListInt()
    {
        return new List<string>(intStats.Keys);
    }

    public List<string> GetListString()
    {
        return new List<string>(stringStats.Keys);
    }

    public int GetInt(string parameterName, int defaultInt = 0)
    {
        if (intStats.ContainsKey(parameterName))
        {
            if (intStats[parameterName] != 0) { return intStats[parameterName]; }
        }
        return defaultInt;
    }

    public float GetFloat(string parameterName, float defaultFloat = 0)
    {
        if (floatStats.ContainsKey(parameterName))
        {
            if (floatStats[parameterName] != 0) { return floatStats[parameterName]; }
        }
        return defaultFloat;
    }

    public string GetString(string parameterName, string defaultString = null)
    {
        if (stringStats.ContainsKey(parameterName))
        {
            if (stringStats[parameterName] != null) { return stringStats[parameterName]; }
        }
        return defaultString;
    }

    public void Set<T>(string parameterName, T value)
    {
        if (value is int)
        {
            int someValue = (int)(object)value;
            if (intStats.ContainsKey(parameterName))
            {
                intStats[parameterName] = someValue;
            }
            else { intStats.Add(parameterName, someValue); }
        }
        else if (value is float)
        {
            float someValue = (float)(object)value;
            if (intStats.ContainsKey(parameterName))
            {
                floatStats[parameterName] = someValue;
            }
            else { floatStats.Add(parameterName, someValue); }
        }
        else if (value is string)
        {
            string someValue = (string)(object)value;
            if (stringStats.ContainsKey(parameterName))
            {
                stringStats[parameterName] = someValue;
            }
            else { stringStats.Add(parameterName, someValue); }
        }
        else { return; }
    }
}
