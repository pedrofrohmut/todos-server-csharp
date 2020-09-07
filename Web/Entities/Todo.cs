namespace TodoServer.Web.Entities
{
  public class Todo
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public string TaskId { get; set; }
    public Task Task { get; set; }
  }
}
