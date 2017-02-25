Imports System.Threading
Imports WMPLib

Module utils
    'global variables
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'contains pending speech file list
    Private gSpeechArr As List(Of String) = New List(Of String)

    'contains alarm list
    Private mAlarmArr As List(Of Integer) = New List(Of Integer)

    'alarm music file
    Private mAlarmMusic As String = Application.StartupPath

    'media player
    Private gMediaPlayer As WindowsMediaPlayer = New WindowsMediaPlayer



    'adds speech files in the pending list
    Public Sub Speech(speechFile As String)
        If gEnableSpeech = False Then
            Return
        End If

        Dim speech As String = My.Application.Info.DirectoryPath + "\speech\" + speechFile + ".mp3"
        Debug.Assert(My.Computer.FileSystem.FileExists(speech))

        'adding speech file in the list
        gSpeechArr.Add(speech)
    End Sub

    'returns next speech file to be played
    Public Function GetSpeechFile() As String
        If gSpeechArr.Count = 0 Then
            Return "empty"
        End If

        'pop the first speech file in the list
        Dim speechFile As String = gSpeechArr(0)
        gSpeechArr.RemoveAt(0)

        Return speechFile
    End Function

    'save enable speech check in a file
    Public Sub SaveSettings()
        Dim file As String = My.Application.Info.DirectoryPath + "\settings.ini"

        'dump settings
        FileOpen(1, file, OpenMode.Output)

        Print(1, Int(gEnableSpeech).ToString + "      :Enable Speech" + Environment.NewLine)
        Print(1, mAlarmMusic + Environment.NewLine)

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

        'set music file
        mAlarmMusic = LineInput(1)
        homeCtrl.MusicAlarmLabel.Text = My.Computer.FileSystem.GetName(mAlarmMusic)

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

    'add alarm
    Public Sub AddAlarmInList(hr As Integer, min As Integer)
        Dim timeInMin As Integer = (hr + 12 * homeCtrl.AmPmAlarm.SelectedIndex) * 60 + min
        If mAlarmArr.Contains(timeInMin) = True Then
            Exit Sub
        End If

        mAlarmArr.Add(timeInMin)
        mAlarmArr.Sort()

        UpdateAlarmList()
    End Sub

    'remove alarm
    Public Sub DeleteAlarmFromList(alarmIdx As Integer)
        If alarmIdx < 1 Or alarmIdx > homeCtrl.AlarmList.Items.Count - 1 Then
            Return
        End If

        homeCtrl.AlarmList.Items.RemoveAt(alarmIdx)
        mAlarmArr.RemoveAt(alarmIdx - 1)

        UpdateAlarmList()
    End Sub

    'browse music
    Public Sub SelectMusic()
        homeCtrl.MusicFileBrowse.InitialDirectory = My.Computer.FileSystem.GetParentPath(mAlarmMusic)
        homeCtrl.MusicFileBrowse.ShowDialog()

        If mAlarmMusic = homeCtrl.MusicFileBrowse.FileName Or homeCtrl.MusicFileBrowse.FileName = "OpenFileDialog1" Then
            Exit Sub
        End If

        mAlarmMusic = homeCtrl.MusicFileBrowse.FileName
        SaveSettings()
        homeCtrl.MusicAlarmLabel.Text = My.Computer.FileSystem.GetName(mAlarmMusic)

        'test music
        PlayMusic()
    End Sub

    'play music
    Public Sub PlayMusic()
        gMediaPlayer.URL = mAlarmMusic
    End Sub

    'kill music
    Public Sub KillMusic()
        gMediaPlayer.close()
    End Sub

    'update alarm lists
    Private Sub UpdateAlarmList()
        homeCtrl.AlarmList.Items.Clear()
        homeCtrl.AlarmList.Items.Add("Alarms set : " + CStr(mAlarmArr.Count))

        For idx = 0 To mAlarmArr.Count - 1
            Dim curMin As Integer = mAlarmArr(idx) Mod 60
            Dim curHr As Integer = Int((mAlarmArr(idx) / 60))
            Dim amPm As String = If(curHr > 12, "PM", "AM")
            Dim curTimeStr As String = (curHr Mod 12).ToString + " : " + curMin.ToString + " " + amPm
            homeCtrl.AlarmList.Items.Add(curTimeStr)
        Next

        homeCtrl.AlarmList.SelectedIndex = -1
    End Sub

    'check and trigger alarm
    Public Sub CheckAndTriggerAlarm()
        If mAlarmArr.Count = 0 Then
            Exit Sub
        End If

        For alarmIdx = 0 To mAlarmArr.Count - 1
            Dim curMin As Integer = mAlarmArr(alarmIdx) Mod 60
            Dim curHr As Integer = Int((mAlarmArr(alarmIdx) / 60))

            If curHr = Now.TimeOfDay.Hours And curMin = Now.TimeOfDay.Minutes And Now.TimeOfDay.Seconds = 0 Then
                'alarm triggered

                mAlarmArr.RemoveAt(alarmIdx)
                UpdateAlarmList()

                'play music
                PlayMusic()

                'start timer start
                homeCtrl.TimerAlarm.Start()
            End If
        Next
    End Sub

End Module
