using TabletopConnect.Common.Extensions;

namespace TabletopConnect.Common.Constants;
public static class ValidationMessages
{
    public static class Common
    {
        public static string EntityCreationFailture(string entityName)
            => $"Entity {entityName.MakeFirstLetterUppercase()} cannot be created.";
        public static string EntityAlreadyExists(string entityName, string propertyName = "this property", string? propertyValue = "") 
            => $"Entity {entityName.MakeFirstLetterUppercase()} with {propertyName.MakeFirstLetterLowercase()} {propertyValue} already exists.";

        public static string EntityNotExists(string entityName)
            => $"Such entity {entityName.MakeFirstLetterUppercase()} does not exist.";

        public static string EntityNotExists(string entityName, string propertyName, string? propertyValue = "") 
            => $"Entity {entityName.MakeFirstLetterUppercase()} with {propertyName.MakeFirstLetterLowercase()} {propertyValue} does not exist.";
    }
}
