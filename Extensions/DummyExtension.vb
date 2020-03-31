Imports Utils
''' <summary>
''' Dummy extension for demonstration purposes 
''' </summary>
Public Class DummyExtension
    ''Specify that we're implementing SmokeSignalExtension
    Implements SmokeSignalExtension

    Public Sub New()
        ''Here's where initialization goes.
        ''If your extension requires the use of a settings file, you can read it here, and set the values here.
        ''additionally if you need to setup any arrays or cosas asi, now is the time.
    End Sub

    Public Function Parse(Command As String) As String Implements SmokeSignalExtension.Parse

        If Command = "CONNECTED" Then
            ToConsole("Classic Packet, replied.")
            Return "You've connected to the server! Congrats."
        End If

        Return ""
    End Function

    Public Sub Tick() Implements SmokeSignalExtension.Tick
        ''Here's where things that need to occur each second can be done.
    End Sub


End Class
