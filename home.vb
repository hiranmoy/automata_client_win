﻿'Imports System.Net.Sockets
Imports System.IO
Imports WMPLib              'Media Player in virtual form

Public Class homeCtrl
    'global variables
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'surveillance directory path
    Private gCurSurveillanceDir As String = "\\RPI3\backups\surveillance\"



    'form load
    Private Sub homeCtrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'position the window in the middle
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - Me.Width / 2
        Me.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2

        'RestoreSettings
        RestoreSettings()
        gLoading = False

        'Welcome speech
        Speech("Welcome_Hiranmoy_")

        'start reconnect timer
        ReconnectTimer.Start()

        'Start speech timer
        SpeechTimer.Start()
    End Sub



    'buttons
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'connect to RPI
    Private Sub connect_Click(sender As Object, e As EventArgs) Handles Connect.Click
        If gFetching(0) = False Then
            Dim connected As Boolean = False

            'read rpi2 ip
            Dim host As String = GetIPFromFile("\\RPI2\backups\ip.txt")
            'MsgBox(host)

            If host <> "-1" Then
                If ConnectIP(host, 0) = True Then
                    connected = True
                End If

                If connected = True Then
                    'connected to rpi2
                    gFetching(0) = True
                End If
            End If
        End If

        If gFetching(1) = False Then
            Dim connected As Boolean = False

            'read rpi3 ip
            Dim host As String = GetIPFromFile("\\RPI3\backups\ip.txt")
            'MsgBox(host)

            If host <> "-1" Then
                If ConnectIP(host, 1) = True Then
                    connected = True
                End If

                If connected = True Then
                    'connected to rpi3
                    gFetching(1) = True
                End If

                EnableAllWidgets()
            End If
        End If

        FetchData()
    End Sub

    'debug only, incomplete codes here
    Private Sub debug_Click(sender As Object, e As EventArgs) Handles debugButton.Click
        Dim tcpParam As TcpParameter = New TcpParameter(Packet.Text, StreamIdx.Value)
        MsgBox(GetResponse(tcpParam))
    End Sub

    'Fatch data
    Private Sub Fetch_Click(sender As Object, e As EventArgs) Handles Fetch.Click
        FetchData()
    End Sub

    'toggle LED light
    Private Sub Toggleled_Click(sender As Object, e As EventArgs) Handles Toggleled.Click
        ToggleLEDLight()
    End Sub

    'toggle fluorescent light
    Private Sub FluLight_Click(sender As Object, e As EventArgs) Handles FluLight.Click
        gFluLight.Toggle()
    End Sub

    'toggle plug0 (good night connected)
    Private Sub Plug0_Click(sender As Object, e As EventArgs) Handles Plug0.Click
        gPlug0.Toggle()
    End Sub

    'toggle fan
    Private Sub fan_Click(sender As Object, e As EventArgs) Handles Fan.Click
        gFan.Toggle()
    End Sub

    'toggle balcony light
    Private Sub balconyLight_Click(sender As Object, e As EventArgs) Handles BalconyLight.Click
        gBalconyLight.Toggle()
    End Sub

    'toggle light bulb
    Private Sub LightBulb_Click(sender As Object, e As EventArgs) Handles LightBulb.Click
        gLightBulb.Toggle()
    End Sub

    'toggle plug1 (laptop connected)
    Private Sub Plug1_Click(sender As Object, e As EventArgs) Handles Plug1.Click
        gPlug1.Toggle()
    End Sub

    'power on scheduling settings
    Private Sub LightingSettings_Click(sender As Object, e As EventArgs) Handles LightingSettings.Click
        'toggle light settings flag
        gLightSettingsMode = Not gLightSettingsMode

        If gLightSettingsMode = True Then
            'enable all radio buttons and setings widgets
            EnableAllRadioButtons()
            SettingsGrp.Enabled = True

            'change settings button text to "Apply"
            LightingSettings.Text = "Apply"

            'disable power profile button 
            ShowPowerHist.Enabled = False
        Else
            'disable setings widgets
            SettingsGrp.Enabled = False

            'change settings button text back to "Settings"
            LightingSettings.Text = "Settings"

            If EnableLightSchedule.Checked = True Then
                'set schduling interval
                SetApplianceSchedule(((hr0.Value * 3600) + (min0.Value * 60) + sec0.Value),
                                     ((hr1.Value * 3600) + (min1.Value * 60) + sec1.Value))
            End If

            If ToggleLightings.Checked = True Then
                'set toggle timer
                SetApplianceTimer((hr2.Value * 3600) + (min2.Value * 60) + sec2.Value)
            End If

            'uncheck scheduling and timer checks
            EnableLightSchedule.Checked = False
            ToggleLightings.Checked = False

            'disable all radio buttons
            DisableAllRadioButtons()

            'disable scheduling and timer checks after disabling the radio buttons
            EnableLightSchedule.Enabled = False
            ToggleLightings.Enabled = False

            'enable power profile button 
            ShowPowerHist.Enabled = True
        End If
    End Sub

    'reset power on scheduling settings
    Private Sub ResetSchedule_Click(sender As Object, e As EventArgs) Handles ResetSchedule.Click
        ResetScheduleAppliances()
    End Sub

    'display power profile
    Private Sub ShowPowerHist_Click(sender As Object, e As EventArgs) Handles ShowPowerHist.Click
        'toggle power profile mode
        gPowerHistSelectMode = Not gPowerHistSelectMode

        If gPowerHistSelectMode = True Then
            'disable power settings button
            LightingSettings.Enabled = False

            'change power profile button text to "Finish"
            ShowPowerHist.Text = "Finish"

            'enable all radio buttons
            EnableAllRadioButtons()
        Else
            'enable power settings button
            LightingSettings.Enabled = True

            'change power profile button text back to "Power Profile"
            ShowPowerHist.Text = "Power" + Environment.NewLine + "Profile"

            'disable all radio buttons
            DisableAllRadioButtons()
        End If
    End Sub

    'clear power profile graph
    Private Sub ClearHist_Click(sender As Object, e As EventArgs) Handles ClearHist.Click
        pwHist.Series.Clear()
        Dim col As String = "Power on Time"
        pwHist.Series.Add(col)
    End Sub

    'populate surveillance clip list
    Private Sub surveillance_Click(sender As Object, e As EventArgs) Handles Surveillance.Click
        gCurSurveillanceDir = gSurveillanceDir + "\motion_detection"

        Call YearList()
    End Sub

    'populate recodings list
    Private Sub Recordings_Click(sender As Object, e As EventArgs) Handles Recordings.Click
        gCurSurveillanceDir = gSurveillanceDir + "\recordings"

        Call YearList()
    End Sub

    'open surveillance video
    Private Sub VideoOpen_Click(sender As Object, e As EventArgs) Handles VideoOpen.Click
        Dim videoFile As String = gCurSurveillanceDir + "\" +
                                  yrList.SelectedItem + "-" +
                                  monthList.SelectedItem + "-" +
                                  dayList.SelectedItem + "\" +
                                  hrList.SelectedItem + "-" +
                                  minList.SelectedItem + "-" +
                                  secList.SelectedItem + ".h264"

        If My.Computer.FileSystem.FileExists(videoFile) = False Then
            MsgBox("Surveillance video doesn't exist")
            Return
        End If

        Process.Start("explorer.exe", videoFile)
    End Sub

    'open surveillance audio
    Private Sub AudioOpen_Click(sender As Object, e As EventArgs) Handles AudioOpen.Click
        Dim audioFile As String = gCurSurveillanceDir + "\" +
                                 yrList.SelectedItem + "-" +
                                 monthList.SelectedItem + "-" +
                                 dayList.SelectedItem + "\" +
                                 hrList.SelectedItem + "-" +
                                 minList.SelectedItem + "-" +
                                 secList.SelectedItem + ".wav"

        If My.Computer.FileSystem.FileExists(audioFile) = False Then
            MsgBox("Surveillance audio doesn't exist")
            Return
        End If

        Process.Start("explorer.exe", audioFile)
    End Sub

    'open surveillance directory
    Private Sub OpenDir_Click(sender As Object, e As EventArgs) Handles OpenDir.Click
        Process.Start("explorer.exe", gSurveillanceDir)
    End Sub

    'clear monitor status
    Private Sub ClearMonitorStatus_Click(sender As Object, e As EventArgs) Handles ClearMonitorStatus.Click
        MonitorStatus.Clear()
    End Sub

    'live feed
    Private Sub LiveFeed_Click(sender As Object, e As EventArgs) Handles LiveFeed.Click
        gCameraOn = Not gCameraOn

        If gCameraOn = True Then
            'change live feed button text to stop feed
            LiveFeed.Text = "Stop" + Environment.NewLine + "Live Feed"
            LiveFeed.BackColor = Color.FromArgb(255, 128, 128)

            'disable record button
            Record.Enabled = False
            'disable video check
            VideoCheck.Enabled = False

            If gDisableVideo = False Then
                'start live feed through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StartLiveFeed", 1)
                Dim feedStatus As String = GetResponse(tcpParam)
                Debug.Assert(feedStatus = "on")

                'open the link in default web broswer
                Dim host As String = GetIPFromFile("\\RPI3\backups\ip.txt")
                Process.Start("http://" + host + ":8080/?action=stream")
            End If
        Else
            'change live feed button text to start feed
            LiveFeed.Text = "Live" + Environment.NewLine + "Feed"
            LiveFeed.BackColor = Color.FromArgb(192, 192, 255)

            'enable record button
            Record.Enabled = True
            'enable video check
            VideoCheck.Enabled = True

            'stop live feed through RPI
            Dim tcpParam As TcpParameter = New TcpParameter("StopLiveFeed", 1)
            Dim feedStatus As String = GetResponse(tcpParam)
            Debug.Assert(feedStatus = "off")
        End If

        'disable surveillance box
        SurveillanceGrp.Enabled = False
    End Sub

    'video recording
    Private Sub Record_Click(sender As Object, e As EventArgs) Handles Record.Click
        gCameraOn = Not gCameraOn

        If gCameraOn = True Then
            'change record button text to stop recording
            Record.Text = "Stop" + Environment.NewLine + "Record"
            Record.BackColor = Color.Salmon

            'disable record button
            LiveFeed.Enabled = False
            'disable video check
            VideoCheck.Enabled = False
            'disable audio check
            AudioCheck.Enabled = False

            If gDisableVideo = False Then
                'start video recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StartVideoRec", 1)
                Dim feedStatus As String = GetResponse(tcpParam)
                Debug.Assert(feedStatus = "on")
            End If

            If gDisableAudio = False Then
                'start audio recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StartAudioRec", 1)
                Dim audioFeedStatus As String = GetResponse(tcpParam)
                Debug.Assert(audioFeedStatus = "on")
            End If
        Else
            'change record button text to start recording
            Record.Text = "Record"
            Record.BackColor = Color.PaleGreen

            'enable record button
            LiveFeed.Enabled = True
            'enable video check
            VideoCheck.Enabled = True
            'enable audio check
            AudioCheck.Enabled = True

            If gDisableVideo = False Then
                'stop video recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StopVideoRec", 1)
                Dim feedStatus As String = GetResponse(tcpParam)
                Debug.Assert(feedStatus = "off")
            End If

            If gDisableAudio = False Then
                'stop audio recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StopAudioRec", 1)
                Dim audioFeedStatus As String = GetResponse(tcpParam)
                Debug.Assert(audioFeedStatus = "off")
            End If
        End If

        'disable surveillance box
        SurveillanceGrp.Enabled = False
    End Sub



    'TrackBar(s)
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'motion sensor activation delay
    Private Sub MotionActDelay_Scroll(sender As Object, e As EventArgs) Handles MotionActDelay.Scroll
        gMotionActDelay = MotionActDelay.Value * 5
        MotionActDelayLabel.Text = "Motion Activation Delay : " + gMotionActDelay.ToString + " sec."
    End Sub



    'Checkboxes
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'enable/disable motion detection
    Private Sub MotionDetectCheck_CheckedChanged(sender As Object, e As EventArgs) Handles MotionDetectCheck.CheckedChanged
        UpdateMotionDetectCheckColor()

        'update color only during loading phase
        If gLoading = True Then
            Return
        End If

        If MotionDetectCheck.Checked = True Then
            'start timer and enable motion tcp command once the timer gets hit
            MotionDetectTimer.Start()

            'disable motion detect check and trackbar
            MotionDetectCheck.Enabled = False
            MotionActDelay.Enabled = False

            'enabling motion detect speech
            Speech("Enabling_motion_detection")
        Else
            Dim enableMotionDetectFlag As Boolean = EnableMotionDetect(Int(MotionDetectCheck.Checked))
            Debug.Assert((gFetching(1) = False) Or (enableMotionDetectFlag = MotionDetectCheck.Checked))

            'disable motion detect speech
            Speech("Motion_detection_disabled")
        End If
    End Sub

    'enable/disable video recording when motion is detected
    Private Sub VideoCheck_CheckedChanged(sender As Object, e As EventArgs) Handles VideoCheck.CheckedChanged
        UpdateVideoCheckColor()

        'update color only during loading phase
        If gLoading = True Then
            Return
        End If

        Dim disableVideoFlag As Boolean = DisableVideo(Int(VideoCheck.Checked))
        Debug.Assert((gFetching(1) = False) Or (disableVideoFlag = VideoCheck.Checked))
    End Sub

    'enable/disable audio recording when motion is detected
    Private Sub AudioCheck_CheckedChanged(sender As Object, e As EventArgs) Handles AudioCheck.CheckedChanged
        UpdateAudioCheckColor()

        'update color only during loading phase
        If gLoading = True Then
            Return
        End If

        Dim disableAudioFlag As Boolean = DisableAudio(Int(AudioCheck.Checked))
        Debug.Assert((gFetching(1) = False) Or (disableAudioFlag = AudioCheck.Checked))
    End Sub

    'enable/disable power on scheduler
    Private Sub EnableLightSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles EnableLightSchedule.CheckedChanged
        StartTimeGrp.Enabled = EnableLightSchedule.Checked
        EndTimeGrp.Enabled = EnableLightSchedule.Checked
    End Sub

    'enable/disable power on timer
    Private Sub ToggleLightings_CheckedChanged(sender As Object, e As EventArgs) Handles ToggleLightings.CheckedChanged
        TimerGrp.Enabled = ToggleLightings.Checked
    End Sub

    'enable/disable speech
    Private Sub SpeechCheck_CheckedChanged(sender As Object, e As EventArgs) Handles SpeechCheck.CheckedChanged
        UpdateSpeechCheckColor()

        'update color only during loading phase
        If gLoading = True Then
            Return
        End If

        gEnableSpeech = SpeechCheck.Checked
        SaveSettings()
    End Sub



    'Radio buttons
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'plug0 select
    Private Sub SelectPlug0_CheckedChanged(sender As Object, e As EventArgs) Handles SelectPlug0.CheckedChanged
        If SelectPlug0.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gPlug0.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gPlug0.GetPowerHistogram()
            End If
        End If
    End Sub

    'fluorescent light select
    Private Sub SelectFluLight_CheckedChanged(sender As Object, e As EventArgs) Handles SelectFluLight.CheckedChanged
        If SelectFluLight.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gFluLight.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gFluLight.GetPowerHistogram()
            End If
        End If
    End Sub

    'balcony light select
    Private Sub SelectBalconyLight_CheckedChanged(sender As Object, e As EventArgs) Handles SelectBalconyLight.CheckedChanged
        If SelectBalconyLight.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gBalconyLight.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gBalconyLight.GetPowerHistogram()
            End If
        End If
    End Sub

    'fan select
    Private Sub SelectFan_CheckedChanged(sender As Object, e As EventArgs) Handles SelectFan.CheckedChanged
        If SelectFan.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gFan.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gFan.GetPowerHistogram()
            End If
        End If
    End Sub

    'light bulb select
    Private Sub SelectLightBulb_CheckedChanged(sender As Object, e As EventArgs) Handles SelectLightBulb.CheckedChanged
        If SelectLightBulb.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gLightBulb.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gLightBulb.GetPowerHistogram()
            End If
        End If
    End Sub

    'plug1 select
    Private Sub SelectPlug1_CheckedChanged(sender As Object, e As EventArgs) Handles SelectPlug1.CheckedChanged
        If SelectPlug1.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gPlug1.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gPlug1.GetPowerHistogram()
            End If
        End If
    End Sub



    'timers
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'fetch weather and motion detection status
    Private Sub Timer10s_Tick(sender As Object, e As EventArgs) Handles Timer10s.Tick
        GetWeatherInfo()
        GetMonitorStatus()
    End Sub

    'updates time remaining motion detect activation
    Private Sub MotionDetectTimer_Tick(sender As Object, e As EventArgs) Handles MotionDetectTimer.Tick
        Debug.Assert(gLoading = False)

        gMotionActDelay -= 1
        MotionActDelayLabel.Text = "Activating motion sensor in " + gMotionActDelay.ToString + " sec"

        If gMotionActDelay <= 0 Then
            MotionDetectTimer.Stop()

            'enable motion detect check and trackbar
            MotionDetectCheck.Enabled = True
            MotionActDelay.Enabled = True

            'restore motion label
            gMotionActDelay = MotionActDelay.Value * 5
            MotionActDelayLabel.Text = "Motion Activation Delay : " + gMotionActDelay.ToString + " sec."

            Dim enableMotionDetectFlag As Boolean = EnableMotionDetect(Int(MotionDetectCheck.Checked))
            Debug.Assert((gFetching(1) = False) Or (enableMotionDetectFlag = MotionDetectCheck.Checked))
            'MsgBox("motion detection enabled")

            'enable motion detect speech
            Speech("Motion_detection_enabled")
        End If
    End Sub

    'check for timer and scheduler for appliances
    Private Sub LightingsTimer_Tick(sender As Object, e As EventArgs) Handles LightingsTimer.Tick
        ToggleAppliancesIfNeeded()
        ScheduleAppliances()
    End Sub

    'play one speech file at a time
    Private Sub SpeechTimer_Tick(sender As Object, e As EventArgs) Handles SpeechTimer.Tick
        SpeechTimer.Stop()

        Dim speechFile As String = GetSpeechFile()
        If speechFile <> "empty" Then
            Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

            ' create the playlist
            Dim urls() As String = {speechFile}
            For Each u In urls
                Player.URL = u
                Player.controls.play()
            Next
        End If

        SpeechTimer.Start()
    End Sub

    'If connection is broken, try to reconnect to rpi at every minute
    Private Sub ReconnectTimer_Tick(sender As Object, e As EventArgs) Handles ReconnectTimer.Tick
        For idx = 0 To gFetching.Length - 1
            If gFetching(idx) = False Then
                Connect.PerformClick()
                Return
            End If
        Next
    End Sub

    'If tcp response from the RPI is received within 10 sec, kill the thread waiting for response.
    Private Sub TcpTimer_Tick(sender As Object, e As EventArgs) Handles TcpTimer.Tick
        TcpTimer.Stop()

        If gTcpResponseTrd.IsAlive = True Then
            gTcpResponseTrd.Abort()
        End If
    End Sub



    'combo listboxes
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'yr selection changed
    Private Sub yrList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yrList.SelectedIndexChanged
        monthList.Items.Clear()
        Dim yr As String = yrList.SelectedItem

        Dim dataDir As DirectoryInfo = New DirectoryInfo(gCurSurveillanceDir)
        Dim dates() As DirectoryInfo = dataDir.GetDirectories()

        For idx = 0 To dates.Length - 1
            Dim dir As String = dates(idx).ToString

            ' Split string based on '-' character
            Dim params As String() = dir.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 3)

            Dim month As String = params(1)

            If dir.Contains(yr + "-") = False Then
                Continue For
            End If

            'populate month list
            If monthList.Items.Contains(month) = False Then
                monthList.Items.Add(month)
            End If
        Next
        monthList.SelectedItem = monthList.Items(monthList.Items.Count - 1)
    End Sub

    'month selection changed
    Private Sub monthList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles monthList.SelectedIndexChanged
        dayList.Items.Clear()
        Dim yr As String = yrList.SelectedItem.ToString
        Dim month As String = monthList.SelectedItem

        Dim dataDir As DirectoryInfo = New DirectoryInfo(gCurSurveillanceDir)
        Dim dates() As DirectoryInfo = dataDir.GetDirectories()

        For idx = 0 To dates.Length - 1
            Dim dir As String = dates(idx).ToString

            ' Split string based on '-' character
            Dim params As String() = dir.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 3)

            Dim day As String = params(2)

            If dir.Contains(yr + "-" + month + "-") = False Then
                Continue For
            End If

            'populate day list
            If dayList.Items.Contains(day) = False Then
                dayList.Items.Add(day)
            End If
        Next
        dayList.SelectedItem = dayList.Items(dayList.Items.Count - 1)
    End Sub

    'day selection changed
    Private Sub dayList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dayList.SelectedIndexChanged
        hrList.Items.Clear()

        Dim dayDir As String = gCurSurveillanceDir + "\" +
                               yrList.SelectedItem + "-" +
                               monthList.SelectedItem + "-" +
                               dayList.SelectedItem
        Dim clipDir As DirectoryInfo = New DirectoryInfo(dayDir)
        Dim clips() As FileInfo = clipDir.GetFiles("*.h264")
        Dim audioClips() As FileInfo = clipDir.GetFiles("*.wav")
        ReDim Preserve clips(clips.Length + audioClips.Length - 1)
        audioClips.CopyTo(clips, clips.Length - audioClips.Length)

        If clips.Length = 0 Then
            Return
        End If
        For idx = 0 To clips.Length - 1
            ' Split string based on '-' character
            Dim fileName As String = clips(idx).ToString
            Dim params As String() = fileName.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 3)

            Dim hr As String = params(0)

            'populate hour list
            If hrList.Items.Contains(hr) = False Then
                hrList.Items.Add(hr)
            End If
        Next
        hrList.SelectedItem = hrList.Items(hrList.Items.Count - 1)
    End Sub

    'hour selection changed
    Private Sub hrList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hrList.SelectedIndexChanged
        minList.Items.Clear()
        Dim hr As String = hrList.SelectedItem

        Dim dayDir As String = gCurSurveillanceDir + "\" +
                               yrList.SelectedItem + "-" +
                               monthList.SelectedItem + "-" +
                               dayList.SelectedItem
        Dim clipDir As DirectoryInfo = New DirectoryInfo(dayDir)
        Dim clips() As FileInfo = clipDir.GetFiles("*.h264")
        Dim audioClips() As FileInfo = clipDir.GetFiles("*.wav")
        ReDim Preserve clips(clips.Length + audioClips.Length - 1)
        audioClips.CopyTo(clips, clips.Length - audioClips.Length)

        If clips.Length = 0 Then
            Return
        End If
        For idx = 0 To clips.Length - 1
            ' Split string based on '-' character
            Dim fileName As String = clips(idx).ToString
            Dim params As String() = fileName.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 3)

            Dim min As String = params(1)

            If fileName.Contains(hr + "-") = False Then
                Continue For
            End If

            'populate minute list
            If minList.Items.Contains(min) = False Then
                minList.Items.Add(min)
            End If
        Next
        minList.SelectedItem = minList.Items(minList.Items.Count - 1)
    End Sub

    'minute selection changed
    Private Sub minList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles minList.SelectedIndexChanged
        secList.Items.Clear()
        Dim hr As String = hrList.SelectedItem.ToString
        Dim min As String = minList.SelectedItem

        Dim dayDir As String = gCurSurveillanceDir + "\" +
                               yrList.SelectedItem + "-" +
                               monthList.SelectedItem + "-" +
                               dayList.SelectedItem
        Dim clipDir As DirectoryInfo = New DirectoryInfo(dayDir)
        Dim clips() As FileInfo = clipDir.GetFiles("*.h264")
        Dim audioClips() As FileInfo = clipDir.GetFiles("*.wav")
        ReDim Preserve clips(clips.Length + audioClips.Length - 1)
        audioClips.CopyTo(clips, clips.Length - audioClips.Length)

        If clips.Length = 0 Then
            Return
        End If
        For idx = 0 To clips.Length - 1
            ' Split string based on '-' character
            Dim fileName As String = clips(idx).ToString
            Dim params As String() = fileName.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 3)

            Dim sec As String = params(2)
            Dim secParams As String() = sec.Split(New Char() {"."c})
            Debug.Assert(secParams.Length() = 2)

            If fileName.Contains(hr + "-" + min + "-") = False Then
                Continue For
            End If

            'populate sec list
            If secList.Items.Contains(secParams(0)) = False Then
                secList.Items.Add(secParams(0))
            End If
        Next
        secList.SelectedItem = secList.Items(secList.Items.Count - 1)
    End Sub



    'others
    '--------------------------------------------------------------------------------------------------------------------------

    'enable widgets
    Private Sub EnableAllWidgets()
        Fetch.Enabled = True
        debugButton.Enabled = True
        Toggleled.Enabled = True

        Tabs.Enabled = True

        Timer10s.Start()
        LightingsTimer.Start()

        'change connect button text to "Connected"
        Connect.Text = "Connected"

        'change connect button color sky blue
        Connect.BackColor = Color.LightSkyBlue
    End Sub

    'disable widgets
    Public Sub DisableAllWidgets()
        Fetch.Enabled = False
        debugButton.Enabled = False
        Toggleled.Enabled = False

        Tabs.Enabled = False

        Timer10s.Stop()
        LightingsTimer.Stop()

        'change connect button text to "Connect"
        Connect.Text = "Connect"

        'change connect button color to reddish
        Connect.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    'enable all radio buttons
    Private Sub EnableAllRadioButtons()
        SelectPlug1.Visible = True
        SelectLightBulb.Visible = True
        SelectFan.Visible = True
        SelectFluLight.Visible = True
        SelectPlug0.Visible = True
        SelectBalconyLight.Visible = True
    End Sub

    'disable and de-select all radio buttons
    Private Sub DisableAllRadioButtons()
        SelectPlug1.Visible = False
        SelectLightBulb.Visible = False
        SelectFan.Visible = False
        SelectFluLight.Visible = False
        SelectPlug0.Visible = False
        SelectBalconyLight.Visible = False

        SelectPlug1.Checked = False
        SelectLightBulb.Checked = False
        SelectFan.Checked = False
        SelectFluLight.Checked = False
        SelectPlug0.Checked = False
        SelectBalconyLight.Checked = False
    End Sub

    'populate all yr list
    Private Sub YearList()
        If My.Computer.FileSystem.DirectoryExists(gCurSurveillanceDir) = False Then
            MsgBox("Surveillance directory doesn't exist")
            Return
        End If

        SurveillanceGrp.Enabled = True
        yrList.Items.Clear()

        Dim dataDir As DirectoryInfo = New DirectoryInfo(gCurSurveillanceDir)
        Dim dates() As DirectoryInfo = dataDir.GetDirectories()

        If dates.Length = 0 Then
            Return
        End If

        For idx = 0 To dates.Length - 1
            ' Split string based on '-' character
            Dim params As String() = dates(idx).ToString.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 3)

            Dim yr As String = params(0)

            'populate year list
            If yrList.Items.Contains(yr) = False Then
                yrList.Items.Add(yr)
            End If
        Next
        yrList.SelectedItem = yrList.Items(yrList.Items.Count - 1)
    End Sub

End Class