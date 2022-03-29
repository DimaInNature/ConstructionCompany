namespace Features.Constructions.Commands;

public class CreateConstructionCommand : IRequest
{
    public Construction? Construction { get; set; }

    public CreateConstructionCommand(Construction construction) => Construction = construction;

    public CreateConstructionCommand() { }
}