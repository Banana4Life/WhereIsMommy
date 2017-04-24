
public class AnyKeyHolder : KeyHolder
{
    public override bool MayOpen(string requiredKey)
    {
        return true;
    }
}