''' <summary>Interface that holds a SmokeSignal user </summary>
Public Interface ISmokeSignalUser

    ''' <summary>Gets the username of this user</summary>
    Function getUsername() As String

    ''' <summary>Get the password of this user</summary>
    Function getPassword() As String

    Function GetUserType() As ISmokeSignalUserType

End Interface
