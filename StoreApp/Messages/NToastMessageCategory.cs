namespace StoreApp.Messages
{
    public static class NToastMessageCategory
    {
        public static string Add(string message)
        {
            return $"The category named {message}  has been successfully added to the categories table";
        }

        public static string Update(string message)
        {
            return $"The category named {message} has been successfully updated";
        }

        public static string Delete(string message)
        {
            return $"The category named {message} has been successfully deleted from the categories table";
        }
    }
}
