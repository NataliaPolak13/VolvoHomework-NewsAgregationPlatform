namespace AllAroundNews.RouteConstraints
{
    public class CategoryConstraint :IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
           RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
                return false;

            var category = values[routeKey] as string;

            return !string.IsNullOrWhiteSpace(category) &&
                   (category == "transport" || category == "entertainment" || category == "culture");
        }
    }
}
