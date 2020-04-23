Imports System.Collections

Public Interface ISmokeSignalAuthenticator

    ''' <summary>Authenticates the current user</summary>
    ''' <returns>True if the user is correct, false if otherwise.</returns>
    Function Authenticate(User As String, Password As String) As ISmokeSignalUser

    ''' <summary>Gets an arraylist of all active users</summary>
    Function GetActiveUsers() As ArrayList

    ''' <summary>Get all users this authenticator has</summary>
    Function GetAllUsers() As ArrayList

    ''' <summary>Register a new user</summary>
    ''' <returns>True if the user could be registered, False otherwise</returns>
    Function RegistierUser(User As String, Password As String) As Boolean

End Interface
