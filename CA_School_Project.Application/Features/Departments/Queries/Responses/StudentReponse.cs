namespace CA_School_Project.Application.Features.Departments.Queries.Responses;

public class StudentReponse
{
   public StudentReponse(int id, string name)
   {
      Id = id;
      Name = name;
   }

   public int Id { get; set; }
   public string Name { get; set; }
}
