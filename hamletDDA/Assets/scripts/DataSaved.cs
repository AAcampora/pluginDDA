using System.Collections.Generic;

public sealed class DataSaved
{
    public DataSaved(string name, List <float> value)
    {
        ValueName = name;
        Value = value;
    }

    public string ValueName { get; set; }
    public List <float> Value { get; set; }
}
