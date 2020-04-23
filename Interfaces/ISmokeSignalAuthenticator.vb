Imports System.Collections

Public Interface ISmokeSignalAuthenticator

    ''' <summary>Authenticates the current user</summary>
    ''' <returns>True if the user is correct, false if otherwise.</returns>
    Function Authenticate(Username As String, Password As String) As ISmokeSignalUser

    ''' <summary>Get all users this authenticator has</summary>
    Function GetAllUsers() As ArrayList

    ''' <summary>Register a new user</summary>
    ''' <returns>True if the user could be registered, False otherwise</returns>
    Function RegistierUser(Username As String, Password As String) As Boolean

End Interface
