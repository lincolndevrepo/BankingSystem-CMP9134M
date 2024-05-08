namespace BankingSystem.Common.Utilities
{
    public static class StatusMessage
    {
        public const string Success = @"Success";
        public const string SuccessSqlConnection = @"Sql database successfully connected.";
        public const string SuccessInsert = @"Insert successful";
        public const string SuccessUpdate = @"Update successful";
        public const string SuccessDelete = @"Delete successful";
        public const string NotDeleted = @"Delete failed";
        public const string NotUpdated = @"Update failed";
        public const string BadRequest = @"Invalid data in request";
        public const string Unauthorized = @"You are not authorized to access requested data";
        public const string InvalidCredentials = @"Invalid Username or Password";
        public const string InvalidGoogleId = @"Invalid Google Account";
        public const string DuplicateRow = @"Duplicate record with similar key already exists";
        public const string NotFound = @"Requested information not found";
    }
}
