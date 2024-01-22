// See https://aka.ms/new-console-template for more information
using DatabaseExample;
using DatabaseExample.Entities;
using DatabaseExample.Repositories;
using DatabaseExample.Extensions;
using Newtonsoft.Json;

IList<User>? UsersList = JsonConvert.DeserializeObject<IList<User>>(Datas.UsersData);

Console.WriteLine("Hello, World!");

ExampleDbContext db = new ExampleDbContext();

int count = 0;
UsersList.ToList().ForEach(user =>
{
    User newUser = new User
    {
        UserName = user.UserName,
        Password = user.Password,
        FirstName = user.FirstName,
        LastName = user.LastName,
        IdentificationNumber = user.IdentificationNumber,
        IsActive = user.IsActive
    };
    db.Users.Add(newUser);
    count++;
    if (count < 30)
    {
        db.Personals.Add(new Personal
        {
            UserId = newUser.Id,
            Salary = new Random().Next(70, 120),
            SSN = "" + new Random().Next(100, 900) + "-" + new Random().Next(100, 900) + "-" + new Random().Next(100, 900),
        });
    }
    else if (count < 60)
    {
        db.Students.Add(new Student
        {
            UserId = newUser.Id,
            Number = "" + new Random().Next(1000000, 2000000),
            Marks = (byte)new Random().Next(0, 100),
            Absenteeism = (byte)new Random().Next(0, 100)
        });
    }
    else if (count < 90 )
    {
        db.Jobbers.Add(new Jobber
        {
            UserId = newUser.Id,
            Plate = "" + new Random().Next(100, 900) + "-" + new Random().Next(100, 900),
            WorkArea = "jobber" + count
        });
    }
    else 
    {
        db.Personals.Add(new Personal
        {
            UserId = newUser.Id,
            Salary = new Random().Next(70, 120),
            SSN = "" + new Random().Next(100, 900) + "-" + new Random().Next(100, 900) + "-" + new Random().Next(100, 900),

        });
        db.Students.Add(new Student
        {
            UserId = newUser.Id,
            Number = "" + new Random().Next(1000000, 2000000),
            Marks = (byte)new Random().Next(0, 100),
            Absenteeism = (byte)new Random().Next(0, 100)
        });
        db.Jobbers.Add(new Jobber
        {
            UserId = newUser.Id,
            Plate = "" + new Random().Next(100, 900) + "-" + new Random().Next(100, 900),
            WorkArea = "jobber" + count
        });
    }
});
db.SaveChanges();
//db.Users.Remove();