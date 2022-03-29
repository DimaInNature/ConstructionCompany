namespace Features.Constructions.Commands;

public class DeleteConstructionCommand : IRequest
{
    public int Id { get; set; }

    public DeleteConstructionCommand(int id) => Id = id;

    public DeleteConstructionCommand() { }
}