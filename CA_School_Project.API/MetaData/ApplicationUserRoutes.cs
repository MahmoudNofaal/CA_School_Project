namespace CA_School_Project.API.MetaData;

public static class ApplicationUserRoutes
{
   public const string Prefix = ApiRoutes.Base + "/users";

   public const string GetList = Prefix + "/list";
   public const string Paginated = Prefix + "/paginated";
   public const string GetById = Prefix + ApiRoutes.SingleRoute;
   public const string Create = Prefix + "/create";
   public const string Edit = Prefix + "/edit";
   public const string Delete = Prefix + "/delete" + ApiRoutes.SingleRoute;

}

