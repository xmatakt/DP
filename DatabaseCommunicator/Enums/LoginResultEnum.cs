namespace DatabaseCommunicator.Enums
{
    /// <summary>
    /// Enum used to identify the result of login attempt into system
    /// </summary>
    public enum LoginResultEnum
    {
        SuccesfullyLoggedIn = 1,
        BadLoginData = 2,
        InactiveUser = 3,
    }
}
