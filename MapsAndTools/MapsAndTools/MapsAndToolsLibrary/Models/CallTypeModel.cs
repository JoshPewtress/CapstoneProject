namespace MapsAndToolsLibrary.Models;

public class CallTypeModel
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public List<CallFlowModel> MissingProduct { get; set; } = new();
	public List<CallFlowModel> DamagedProduct { get; set; } = new();
}
