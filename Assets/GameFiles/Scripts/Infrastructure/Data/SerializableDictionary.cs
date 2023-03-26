using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    public SerializableDictionary()
    {
    }
    public SerializableDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    public List<TKey> keys = new List<TKey>();

    public List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        Clear();

        if (keys.Count != values.Count)
            throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < keys.Count; i++)
        {
            Add(keys[i], values[i]);
        }
    }
}

[Serializable]
public class StatsDataSet : SerializableDictionary<string, ISerializationCallbackReceiver>
{
    public StatsDataSet()
    {
    }
    public StatsDataSet(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class DictionaryStringInt : SerializableDictionary<string, int>
{
    public DictionaryStringInt()
    {
    }
    public DictionaryStringInt(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class DictionaryStringFloat : SerializableDictionary<string, float>
{
    public DictionaryStringFloat()
    {
    }
    public DictionaryStringFloat(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class DictionaryStringString : SerializableDictionary<string, string>
{
    public DictionaryStringString()
    {
    }
    public DictionaryStringString(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
