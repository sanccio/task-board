namespace TaskBoard.BLL.Exceptions;
internal class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException()
    {
    }

    public ObjectNotFoundException(string message) : base(message)
    {
    }

    public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ObjectNotFoundException(string objectName, int objectId)
            : base($"The object '{objectName}' with id '{objectId}' was not found.")
    {
    }
}
