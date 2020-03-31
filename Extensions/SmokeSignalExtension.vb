''' <summary>
''' An interface to develop extensions 
''' </summary>
Public Interface SmokeSignalExtension
    ''' <summary>
    ''' Returns the response to the specified parsable command.
    ''' </summary>
    ''' <param name="Command"></param>
    ''' <returns>An actual string if it could parse it, otherwise null</returns>
    Function Parse(Command As String) As String
    Sub Tick()

End Interface
