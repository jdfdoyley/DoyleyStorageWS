using SQLite;

namespace DoyleyStorageWS.Models;

public class SqLiteDb
{
	private readonly string _path;

	public SqLiteDb(string path)
	{
		_path = path;
	}

	public void Create()
	{
		using SQLiteConnection db = new SQLiteConnection(_path);
		db.CreateTable<Person>();
	}
}

public partial class Person
{
	[PrimaryKey, AutoIncrement]
	public Int64 Id { get; set; }

	[NotNull]
	public String? FirstName { get; set; }

	[NotNull]
	public String? LastName { get; set; }

	[NotNull]
	public DateTime Dob { get; set; }
}