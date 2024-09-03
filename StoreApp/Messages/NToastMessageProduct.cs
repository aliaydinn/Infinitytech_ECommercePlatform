namespace StoreApp.Messages
{
    public static class NToastMessageProduct
    {
        public static string Add(string message)
        {
            return $"The product named {message}  has been successfully added to the products table";
        }

        public static string Update(string message)
        {
            return $"The product named {message} has been successfully updated";
        }

        public static string Delete(string message)
        {
            return $"The product named {message} has been successfully deleted from the products table";
        }
    }
}
