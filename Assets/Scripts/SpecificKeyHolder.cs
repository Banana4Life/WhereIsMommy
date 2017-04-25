using System.Collections.Generic;

public class SpecificKeyHolder : KeyHolder
{
    public List<string> key;

    private void Start()
    {
        key = new List<string>();
    }

    public override bool MayOpen(string requiredKey)
    {
        return requiredKey.Length == 0 || key.Contains(requiredKey);
    }
}