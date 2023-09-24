using SQLite;

namespace DoyleyStorageWS.Models;

public partial class Person
{
	public string Name => $"{FirstName} {LastName}";
	public string StrDob => $"{Dob:d}";
}

public class Dal
{
	private readonly string _dbPath = Path.Combine(
		Environment.GetFolderPath(Environment.SpecialFolder.Personal),
		"PeopleDB.db"
	);

	public Dal()
	{
		// check to see if DB exists - if not, create it
		if (!File.Exists(_dbPath ))
		{
			SqLiteDb db = new SqLiteDb(_dbPath);
			db.Create();
		}
	}

	// method to save a person to the DB
	public void AddPerson(Person personToAdd)
	{
		using SQLiteConnection db = new SQLiteConnection(_dbPath);
		bool exists = false;

		// error checking to prevent adding same person twice
		foreach (Person p in db.Table<Person>())
		{
			if (p.FirstName == personToAdd.FirstName
			    && p.LastName == personToAdd.LastName
			    && p.Dob == personToAdd.Dob)
			{
				exists = true;
				break;
			}
		}

		// person doesn't exist in the DB, add the,
		if(!exists)
		{
			db.Insert(personToAdd);
		}
	}

	// method to get a list of all people in the DB
	public List<Person> GetAllPeople()
	{
		using SQLiteConnection db = new SQLiteConnection(_dbPath);
		List<Person> people = db.Table<Person>().ToList();

		return people;
	}
}