Imports System.Collections
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Imports BasicRender
Imports Utils

''' <summary>
''' SMOKESIGNAL SERVER VERSION 1
''' </summary>
Public Module Main

    Public IP As String = "127.0.0.1"
    Public Port As Integer = 797
    Public Extensions As SmokeSignalExtension()
    'I would make that an arraylist to be simple pero no puedo sadly. Oh well.

    'SERVER SETUP
    Public Const ServerName As String = "SmokeSignal Base Server"
    Public Const ServerVersion As String = "1.0"

    '(pls do not touch me)
    Public Const SmokeSignalVersion As String = "1.0"

    Public Sub RegisterAllExtensions()
        ReDim Extensions(0) 'Redim the Extensions array to the size of the number of extensions you want.

        'Add your extensions
        Extensions(0) = New DummyExtension()
    End Sub

    Public Sub Main()

        'Console Size (Remember to update on BasicRender if u want to change this)
        Console.SetBufferSize(120, 30)
        Console.SetWindowSize(120, 30)

        'Server Initialization
        Console.Title = ServerName & " [Version " & ServerVersion & "]"
        DrawHeader()
        Color(ConsoleColor.White)
        Color(ConsoleColor.Gray)
        Console.WriteLine("")
        Console.WriteLine("")
        ToConsole("Starting Server...")

        'Read settings
        If (File.Exists("SmokeSettings.cfg")) Then
            'Set Settings
            Dim Settings As String() = ReadFromFile("SmokeSettings.cfg").Split(",")
            IP = Settings(0)
            Port = Integer.Parse(Settings(1))
            FileClose(1)
        Else
            ToFile("SmokeSettings.cfg", IP & "," & Port)
            ToConsole("Could Not Find Settings.cfg in current directory, rendered default one")
        End If

        'Extensions Registering
        RegisterAllExtensions()

        'Actually start the server
        Dim tcpListener As TcpListener = New TcpListener(IPAddress.Parse(IP), Port)
        Dim tcpClient As TcpClient = New TcpClient()
        tcpListener.Start()

        Color(ConsoleColor.Green)
        ToConsole("Server Started!")
        Color(ConsoleColor.Gray)

        Dim ClientMSG As String
        Color(ConsoleColor.Yellow)
        ToConsole("Waiting for connection...")
        DrawHeader()

        'The bulk loop
        While True

            'Check if we have a pending connection
            If tcpListener.Pending Then

                'Accept it...
                Dim networkStream As NetworkStream = New NetworkStream(tcpListener.AcceptSocket())
                Dim binaryWriter As BinaryWriter = New BinaryWriter(networkStream)
                Dim binaryReader As BinaryReader = New BinaryReader(networkStream)

                Color(ConsoleColor.Green)
                ToConsole("Connected! Waiting for string...")
                Color(ConsoleColor.Gray)

                'Try to take the string, and parse it
                Try
                    ClientMSG = binaryReader.ReadString().Trim()
                    ToConsole("Received (" & ClientMSG & ")")
                    binaryWriter.Write(ParseCommand(ClientMSG))
                Catch ex As Exception
                    ErrorToConsole("Could not read string for some reason.", ex)
                End Try

                'Return to the waiting state
                Color(ConsoleColor.Yellow)
                ToConsole("Waiting for connection...")
                DrawHeader()
            End If

            'Tick each time we can.
            For Each SmokeSignal In Extensions
                SmokeSignal.Tick()
            Next

            'S P E E N
            Spinner(Console.CursorLeft, Console.CursorTop)

            'Wait for another go around
            Sleep(1000)

        End While
    End Sub

    Public Sub DrawHeader()
        Box(ConsoleColor.DarkBlue, 120, 2, 0, 0)
        SetPos(0, 0)
        Color(ConsoleColor.DarkBlue, ConsoleColor.White)
        CenterText(ServerName + " [Version " & ServerVersion & "] | Running on SmokeSignal V" & SmokeSignalVersion)
        SetPos(0, 1)
        CenterText("Listening on " & IP & ":" & Port & " ")
    End Sub


    Function ParseCommand(ClientMSG As String) As String
        Dim Result As String
        For Each SmokeSignal In Extensions
            Result = SmokeSignal.Parse(ClientMSG)
            If Not String.IsNullOrEmpty(Result) Then Return Result
        Next

        'Invalid Packet
        ToConsole("Invalid Packet Sent")
        Return "invalid Packet Sent"
    End Function


End Module