namespace MapsAndToolsLibrary.Models;

public class TeamMemberModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public Dictionary<string, string>? AssignedHours { get; set; } = new Dictionary<string, string>();
}
