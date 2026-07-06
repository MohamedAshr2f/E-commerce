namespace Ecommerce.Data.AppMetaData
{
    public static class Router
    {
        public const string SignleRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public static class CategoryRouting
        {
            public const string Prefix = Rule + "Category";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + SignleRoute;
            public const string Pagination = Prefix + "/Pagination";
        }

            public static class ProductRouting
            {
                public const string Prefix = Rule + "Product";
                public const string List = Prefix + "/List";
                public const string GetByID = Prefix + SignleRoute;
            }
        }

}
