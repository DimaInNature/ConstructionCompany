namespace Features.Constructions.Commands;

public class UpdateConstructionCommand : IRequest
{
    public Construction? Construction { get; set; }

    public UpdateConstructionCommand(Construction construction) => Construction = construction;

    public UpdateConstructionCommand() { }
}