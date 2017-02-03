Module utils
    'contains pending speech file list
    Private speechArr As List(Of String) = New List(Of String)

    'tcp response argument
    Public Class TcpParameter
        Private mDataStr As String
        Private mStreamIdx As String

        Public Sub New(aDataStr As String, aStreamIdx As Integer)
            mDataStr = aDataStr
            mStreamIdx = aStreamIdx
        End Sub

        Public Function GetDataStr() As String
            Return mDataStr
        End Function

        Public Function GetStreamIdx() As String
            Return mStreamIdx
        End Function
    End Class

    'adds speech files in the pending list
    Public Sub Speech(speechFile As String)
        If gEnableSpeech = False Then
            Return
        End If

        Dim speech As String = My.Application.Info.DirectoryPath + "\speech\" + speechFile + ".mp3"
        Debug.Assert(My.Computer.FileSystem.FileExists(speech))

        'adding speech file in the list
        speechArr.Add(speech)
    End Sub

    'returns next speech file to be played
    Public Function GetSpeechFile() As String
        If speechArr.Count = 0 Then
            Return "empty"
        End If

        'pop the first speech file in the list
        Dim speechFile As String = speechArr(0)
        speechArr.RemoveAt(0)

        Return speechFile
    End Function

    'save enable speech check in a file
    Public Sub SaveSettings()
        Dim file As String = My.Application.Info.DirectoryPath + "\settings.ini"

        'dump settings
        FileOpen(1, file, OpenMode.Output)

        Print(1, Int(gEnableSpeech).ToString + "      :Enable Speech" + Environment.NewLine)

        FileClose(1)
    End Sub

    'restore enable speech check from a file
    Public Sub RestoreSettings()
        Dim file As String = My.Application.Info.DirectoryPath + "\settings.ini"
        If My.Computer.FileSystem.FileExists(file) = False Then
            Return
        End If

        FileOpen(1, file, OpenMode.Input)

        'enable speech check
        Dim data As String = LineInput(1)
        data = data.Substring(0, 5)
        gEnableSpeech = CBool(Int(data))
        homeCtrl.SpeechCheck.Checked = gEnableSpeech

        FileClose(1)
    End Sub

    'returns ip after reading a file
    Public Function GetIPFromFile(ipFile As String) As String
        If My.Computer.FileSystem.FileExists(ipFile) = False Then
            Return "-1"
        End If

        FileOpen(1, ipFile, OpenMode.Input)

        Dim rpiIp As String = ""
        Try
            rpiIp = LineInput(1)
        Catch ex As Exception
            Return "-1"
        End Try

        ' Split string based on ',' character
        Dim ips As String() = rpiIp.Split(New Char() {" "c})

        FileClose(1)

        If rpiIp = "" Then
            Return "-1"
        End If

        Return ips(0)
    End Function

End Module
