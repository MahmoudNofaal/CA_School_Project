namespace CA_School_Project.API.MetaData;

public static class StudentRoutes
{
   public const string Prefix = ApiRoutes.Base + "/students";

   public const string GetList = Prefix + "/list";
   public const string GetById = Prefix + ApiRoutes.SingleRoute;
   public const string Create = Prefix + "/create";
   public const string Edit = Prefix + "/edit";
   public const string Delete = Prefix + "/delete" + ApiRoutes.SingleRoute;

}
