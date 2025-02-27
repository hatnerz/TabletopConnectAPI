using TabletopConnect.Common.Extensions;

namespace TabletopConnect.Common.Constants;
public static class ValidationMessages
{
    public static class Common
    {
        public static string UnknownError => "An unknown error occurred.";
        public static string EntityCreationFailture(string entityName)
            => $"{entityName.MakeFirstLetterUppercase()} cannot be created.";

        public static string EntityAlreadyExists(string entityName, string propertyName = "this property", string propertyValue = "") 
            => $"{entityName.MakeFirstLetterUppercase()} with this {propertyName.MakeFirstLetterLowercase()}{(propertyValue == "" ? "" : " ")}{propertyValue} already exists.";

        public static string EntityNotExists(string entityName)
            => $"Such {entityName.MakeFirstLetterLowercase()} does not exist.";

        public static string EntityNotExists(string entityName, string propertyName, string? propertyValue = "") 
            => $"{entityName.MakeFirstLetterUppercase()} with {propertyName.MakeFirstLetterLowercase()}{(propertyValue == "" ? "" : " ")}{propertyValue} does not exist.";
    
        //public static string 
    }
}
