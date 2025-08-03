namespace LibrarySystem.Models.Enums
{
    public enum OpStatusEnum
    {
        None = 0,
        Success = 1,
        Failed = 2,
        NotFound = 3,
        AlreadyExists = 4,
        InvalidInput = 5,
        Unauthorized = 6,
        Forbidden = 7,
        Conflict = 8,
        InternalServerError = 9
    }
}
