namespace Todo.Core.Models;

public class TodoItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    
    // TODO: This should be a reference to a User object
    public string Assignee { get; set; }
}