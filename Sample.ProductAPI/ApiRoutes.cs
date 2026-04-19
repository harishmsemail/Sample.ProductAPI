namespace Sample.ProductAPI
{
    /// <summary>
    /// Defines constant values for API routes.
    /// </summary>
    public static class ApiRoutes
    {
        /// <summary>
        /// Defines routes for the Products controller.
        /// </summary>
        public static class Products
        {
            public const string Base = "api/products";
            
            // the action-specific route segments.
            public const string GetById = "{id}";
            public const string GetAttributes = "{id}/attributes";
        }
    }
}
