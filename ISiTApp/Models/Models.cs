using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ISiTApp.Models
{
    public record class Person(int Id, string Name, int Age, Company Work);
    public record class Company(int Id, string Name, string Country);
    public record class OtherPerson(string Name, int Age, OtherCompany? Company);
    public record class OtherCompany(string Name);
    public class User
    {
        public int Id { get; set; }
        [BindRequired]
        public string Name { get; set; } = "";
        public int Age { get; set; }
        [BindNever]
        public bool HasRight { get; set; }
    }
    // СОЗДАНИЕ ПРИВЯЗЧИКА МОДЕЛИ
    public class Event
    {
        public string? Id { get; set; }
        public string? Name { get; set; }       // название события
        public DateTime EventDate { get; set; } // дата и время событие
    }
}
