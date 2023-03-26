using System.Collections.Generic;

public interface IGameData : IService
{
    public void DataSave();
    public void DataLoad();
    public void IncreaseInt(string parameterName, int value = 1);
    public void IncreaseFloat(string parameterName, float value = 1f);
    public List<string> GetListInt();
    public List<string> GetListString();
    public int GetInt(string parameterName, int defaultInt = 0);
    public float GetFloat(string parameterName, float defaultFloat = 0);
    public string GetString(string parameterName, string defaultString = null);
    public void Set<T>(string parameterName, T value);

}