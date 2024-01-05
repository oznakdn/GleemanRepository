namespace Gleeman.Repository.MongoDriver.Extensions;

public static class PluralExtension
{
    public static string AddPlural(this string collectionName)
    {
        if (collectionName.EndsWith('o') || collectionName.EndsWith('x') || collectionName.EndsWith('s') || collectionName.EndsWith('h') || collectionName.EndsWith('z'))
        {
            collectionName += "es";
        }
        else if (collectionName.EndsWith('y'))
        {
            collectionName = collectionName.Remove(collectionName.Length - 1, 1);
            collectionName += "ies";
        }
        else if (collectionName.EndsWith('f'))
        {
            collectionName = collectionName.Remove(collectionName.Length - 1, 1);
            collectionName += "ves";
        }
        else
        {
            collectionName += "s";
        }

        return collectionName;
    }
}