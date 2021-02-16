namespace Models
{
  public class Employee
  {
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //NULLABLE PROPERTIES
    #nullable enable
    public string? Email { get; set; }
    public string? Title { get; set; }
    public int? ReportsTo { get; set; }
    public int? BirthDate { get; set; }
    public int? HireDate { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    #nullable disable
  }
}
