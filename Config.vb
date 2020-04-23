''' <summary>This module holds all configurable data for this SmokeSigal Server</summary>
Module Config

    'Default IP and Port
    Public IP As String = "127.0.0.1"
    Public Port As Integer = 797

    'SERVER SETUP
    Public Const SERVER_NAME As String = "SmokeSignal Base Server"
    Public Const SERVER_VERSION As String = "1.0"
    Public Const HEADER_BACK_COLOR As ConsoleColor = ConsoleColor.DarkBlue
    Public Const HEADER_FONT_COLOR As ConsoleColor = ConsoleColor.White

    Public Sub RegisterAuthenticator()

        'Register your authenticator here.
        Authenticator = New DummyAuthenticator("DummyAuthenticatorUser.txt")

    End Sub

    Public Sub RegisterAllExtensions()

        'Add your extensions. When creating the extension, the extension should initialize
        Extensions = {New DummyExtension()}
        AuthenticatedExtensions = {New DummyAuthenticatedExtension()}

    End Sub



End Module
