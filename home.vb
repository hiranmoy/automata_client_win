' -*- Visual basic -*-

'*****************************************************************
'
'              Copyright 2016 Hiranmoy Basak
'
'                  All Rights Reserved.
'
'           THIS WORK CONTAINS TRADE SECRET And
'       PROPRIETARY INFORMATION WHICH Is THE PROPERTY
'            OF HIRANMOY BASAK OR ITS LICENSOR
'            AND IS SUBJECT TO LICENSE TERMS.
'
'*****************************************************************/
'
' No part of this file may be reproduced, stored in a retrieval system,
' Or transmitted in any form Or by any means --- electronic, mechanical,
' photocopying, recording, Or otherwise --- without prior written permission
' of Hiranmoy Basak.
'
' WARRANTY:
' Use all material in this file at your own risk. Hiranmoy Basak.
' makes no claims about any material contained in this file.
' 
' Author: Hiranmoy Basak (hiranmoy.iitkgp@gmail.com)


Imports System.IO
Imports WMPLib
Imports System.Threading


Public Class homeCtrl
    'global variables
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'surveillance directory path
    Private gCurSurveillanceDir As String = "\\RPI3\backups\surveillance\"



    'form load
    Private Sub homeCtrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'position the window in the middle
        'Me.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - Me.Width / 2
        'Me.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2

        'disable maximize button
        'Me.MaximizeBox = False


        'set main thread name
        Thread.CurrentThread.Name() = "Automata_Main_Trd"


        'RestoreSettings
        RestoreSettings()


        'select AC cool mode
        ACCoolMode.Checked = True


        gLoading = False


        'disable all tabs
        For idx = 0 To Tabs.TabCount - 2
            Tabs.TabPages(idx).Enabled = False
        Next


        'Welcome speech
        Speech("Welcome_Hiranmoy_")


        'initialize am pm selector
        AmPmAlarm.SelectedIndex = 0


        'x-axis: min=0, max=23, interval=1
        pwHist.ChartAreas.Min.AxisX.Minimum = 0
        pwHist.ChartAreas.Min.AxisX.Maximum = 23
        pwHist.ChartAreas.Min.AxisX.Interval = 1

        'x-axis: min=0, max=23, interval=2
        TemperatureData.ChartAreas.Min.AxisX.Minimum = 0
        TemperatureData.ChartAreas.Min.AxisX.Maximum = 24
        TemperatureData.ChartAreas.Min.AxisX.Interval = 2

        HumidityData.ChartAreas.Min.AxisX.Minimum = 0
        HumidityData.ChartAreas.Min.AxisX.Maximum = 24
        HumidityData.ChartAreas.Min.AxisX.Interval = 2

        PressureData.ChartAreas.Min.AxisX.Minimum = 0
        PressureData.ChartAreas.Min.AxisX.Maximum = 24
        PressureData.ChartAreas.Min.AxisX.Interval = 2

        pwHist.ChartAreas.Min.AxisX.Minimum = 0
        pwHist.ChartAreas.Min.AxisX.Maximum = 24
        pwHist.ChartAreas.Min.AxisX.Interval = 2

        'set chart type
        TemperatureData.Series("Temperature (^C)").ChartType = DataVisualization.Charting.SeriesChartType.Line
        HumidityData.Series("Humidity").ChartType = DataVisualization.Charting.SeriesChartType.Line
        PressureData.Series("Air Pressure (Pa)").ChartType = DataVisualization.Charting.SeriesChartType.Line


        'clear and create debug directory
        'Try
        If My.Computer.FileSystem.DirectoryExists(gDebugFolder) Then
            My.Computer.FileSystem.DeleteDirectory(gDebugFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(gDebugFolder)
        'Catch
        'End Try
    End Sub

    'form closing
    Private Sub homeCtrl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        gTcpMgr.KillTcpReponseThreads()
    End Sub


    'buttons
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'connect to RPI
    Private Sub connect_Click(sender As Object, e As EventArgs) Handles Connect.Click
        gTcpMgr.ConnectModules()
    End Sub

    'debug only, incomplete codes here
    Private Sub debug_Click(sender As Object, e As EventArgs) Handles debugButton.Click
        Dim tcpParam As TcpParameter = New TcpParameter(Packet.Text, StreamDebugIdx.Value, 0)
        MsgBox(gTcpMgr.GetResponse(tcpParam))
    End Sub

    'Fatch data
    Private Sub Fetch_Click(sender As Object, e As EventArgs) Handles Fetch.Click
        gTcpMgr.FetchDataFromAll()
    End Sub

    'toggle LED light
    Private Sub Toggleled_Click(sender As Object, e As EventArgs) Handles Toggleled.Click
        gTcpMgr.ToggleLEDLight()
    End Sub

    'toggle fluorescent light
    Private Sub FluLight_Click(sender As Object, e As EventArgs) Handles FluLight.Click
        gTcpMgr.mFluLight.Toggle()
    End Sub

    'toggle plug0 (good night connected)
    Private Sub Plug0_Click(sender As Object, e As EventArgs) Handles Plug0.Click
        gTcpMgr.mPlug0.Toggle()
    End Sub

    'toggle fan
    Private Sub fan_Click(sender As Object, e As EventArgs) Handles Fan.Click
        gTcpMgr.mFan.Toggle()
    End Sub

    'toggle balcony light
    Private Sub balconyLight_Click(sender As Object, e As EventArgs) Handles BalconyLight.Click
        gTcpMgr.mBalconyLight.Toggle()
    End Sub

    'toggle light bulb
    Private Sub LightBulb_Click(sender As Object, e As EventArgs) Handles LightBulb.Click
        gTcpMgr.mLightBulb.Toggle()
    End Sub

    'toggle plug1 (laptop connected)
    Private Sub Plug1_Click(sender As Object, e As EventArgs) Handles Plug1.Click
        gTcpMgr.mPlug1.Toggle()
    End Sub

    'power on scheduling settings
    Private Sub LightingSettings_Click(sender As Object, e As EventArgs) Handles ApplianceSchedular.Click
        'toggle light settings flag
        gLightSettingsMode = Not gLightSettingsMode

        If gLightSettingsMode = True Then
            'enable all radio buttons and setings widgets
            EnableAllRadioButtons()
            SettingsGrp.Enabled = True

            'change settings button text to "Apply"
            ApplianceSchedular.Text = "Apply"

            'disable power profile button 
            ShowPowerHist.Enabled = False
        Else
            'disable setings widgets
            SettingsGrp.Enabled = False

            'change settings button text back to "Settings"
            ApplianceSchedular.Text = "Settings"

            If EnableLightSchedule.Checked = True Then
                'set schduling interval
                SetApplianceSchedule(((hr0.Value * 60) + min0.Value),
                                     ((hr1.Value * 60) + min1.Value),
                                     DisableLightSchedule.Checked)
            End If

            If ToggleLightings.Checked = True Then
                'set toggle timer
                SetApplianceTimer((hr2.Value * 60) + min2.Value)
            End If

            'uncheck scheduling and timer checks
            EnableLightSchedule.Checked = False
            ToggleLightings.Checked = False
            DisableLightSchedule.Checked = False

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
            ApplianceSchedular.Enabled = False

            'change power profile button text to "Finish"
            ShowPowerHist.Text = "Finish"

            'enable all radio buttons
            EnableAllRadioButtons()

            'enable date and time picker
            ApplianceDateTime.Enabled = True

            'enable load button
            LoadApplianceData.Enabled = True
        Else
            'enable power settings button
            ApplianceSchedular.Enabled = True

            'change power profile button text back to "Power Profile"
            ShowPowerHist.Text = "Power" + Environment.NewLine + "Profile"

            'disable all radio buttons
            DisableAllRadioButtons()

            'enable date and time picker
            ApplianceDateTime.Enabled = False

            'enable load button
            LoadApplianceData.Enabled = False
        End If
    End Sub

    'clear power profile graph
    Private Sub ClearHist_Click(sender As Object, e As EventArgs) Handles ClearHist.Click
        pwHist.Series.Clear()
        Dim col As String = "Power consumption"
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

            If gTcpMgr.IsVideoDisabled() = False Then
                'start live feed through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StartLiveFeed", gCameraModuleId, 1)
                Dim feedStatus As String = gTcpMgr.GetResponse(tcpParam)
                Debug.Assert(feedStatus = "on")

                'get name of the module
                Dim host As String = ""
                Select Case gCameraModuleId
                    Case 0
                        host = "rpi2"
                    Case 1
                        host = "rpi3"
                    Case 2
                        host = "rpi32"
                    Case Else
                        Debug.Assert(False)
                End Select

                'open the link in default web broswer
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
            Dim tcpParam As TcpParameter = New TcpParameter("StopLiveFeed", gCameraModuleId, 1)
            Dim feedStatus As String = gTcpMgr.GetResponse(tcpParam)
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

            If gTcpMgr.IsVideoDisabled() = False Then
                'start video recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StartVideoRec", gCameraModuleId, 1)
                Dim feedStatus As String = gTcpMgr.GetResponse(tcpParam)
                Debug.Assert(feedStatus = "on")
            End If

            If gTcpMgr.IsAudioDisabled() = False Then
                'start audio recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StartAudioRec", gCameraModuleId, 1)
                Dim audioFeedStatus As String = gTcpMgr.GetResponse(tcpParam)
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

            If gTcpMgr.IsVideoDisabled() = False Then
                'stop video recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StopVideoRec", gCameraModuleId, 1)
                Dim feedStatus As String = gTcpMgr.GetResponse(tcpParam)
                Debug.Assert(feedStatus = "off")
            End If

            If gTcpMgr.IsAudioDisabled() = False Then
                'stop audio recording through RPI
                Dim tcpParam As TcpParameter = New TcpParameter("StopAudioRec", gCameraModuleId, 1)
                Dim audioFeedStatus As String = gTcpMgr.GetResponse(tcpParam)
                Debug.Assert(audioFeedStatus = "off")
            End If
        End If

        'disable surveillance box
        SurveillanceGrp.Enabled = False
    End Sub

    'switch off led flood light
    Private Sub DisableLED_Click(sender As Object, e As EventArgs) Handles DisableLED.Click
        Dim tcpParam As TcpParameter = New TcpParameter("SwitchOffLEDFloodLight", gLircModuleId, 1)
        Dim powerStatus As String = gTcpMgr.GetResponse(tcpParam)

        If (powerStatus = "Disconnected") Or (powerStatus = "") Then
            Return
        End If
        Debug.Assert(powerStatus = "off")
    End Sub

    'press led flood light buttons
    Private Sub LEDButtons_Click(sender As Object, e As EventArgs) Handles LEDButton24.Click, LEDButton23.Click, LEDButton22.Click, LEDButton21.Click, LEDButton20.Click, LEDButton19.Click,
                                                                           LEDButton18.Click, LEDButton17.Click, LEDButton16.Click, LEDButton15.Click, LEDButton14.Click, LEDButton13.Click,
                                                                           LEDButton12.Click, LEDButton11.Click, LEDButton10.Click, LEDButton09.Click, LEDButton08.Click, LEDButton07.Click,
                                                                           LEDButton06.Click, LEDButton05.Click, LEDButton04.Click, LEDButton03.Click, LEDButton02.Click, LEDButton01.Click
        Dim btn As Button = DirectCast(sender, Button)

        'extract button idx
        Dim buttonidx As String = btn.Name
        buttonidx = buttonidx.Substring(9, 2)

        Dim tcpParam As TcpParameter = New TcpParameter("ClickOnLEDFloodLight " + buttonidx, gLircModuleId, 1)
        Dim buttonStatus As String = gTcpMgr.GetResponse(tcpParam)
        If (buttonStatus = "Disconnected") Or (buttonStatus = "") Then
            Return
        End If

        Debug.Assert(buttonStatus = "LED Flood Light button " + buttonidx.ToString + " pressed")
    End Sub

    'press speaker buttons
    Private Sub SpeakerButtons_Click(sender As Object, e As EventArgs) Handles SpeakerButton32.Click, SpeakerButton31.Click, SpeakerButton30.Click, SpeakerButton29.Click,
                                                                               SpeakerButton28.Click, SpeakerButton27.Click, SpeakerButton26.Click, SpeakerButton25.Click,
                                                                               SpeakerButton24.Click, SpeakerButton23.Click, SpeakerButton22.Click, SpeakerButton21.Click,
                                                                               SpeakerButton20.Click, SpeakerButton19.Click, SpeakerButton18.Click, SpeakerButton17.Click,
                                                                               SpeakerButton16.Click, SpeakerButton15.Click, SpeakerButton14.Click, SpeakerButton13.Click,
                                                                               SpeakerButton12.Click, SpeakerButton11.Click, SpeakerButton10.Click, SpeakerButton09.Click,
                                                                               SpeakerButton08.Click, SpeakerButton07.Click, SpeakerButton06.Click, SpeakerButton05.Click,
                                                                               SpeakerButton04.Click, SpeakerButton03.Click, SpeakerButton02.Click, SpeakerButton01.Click
        Dim buttonidx As String = ""
        If sender.ToString.Contains("Button, Text:") Then
            Dim btn As Button = DirectCast(sender, Button)
            buttonidx = btn.Name
        Else
            Dim rdb As RadioButton = DirectCast(sender, RadioButton)
            buttonidx = rdb.Name
        End If

        'extract button idx
        buttonidx = buttonidx.Substring(13, 2)

        Dim tcpParam As TcpParameter = New TcpParameter("ClickOnSpeaker " + buttonidx, gLircModuleId, 1)
        Dim buttonStatus As String = gTcpMgr.GetResponse(tcpParam)
        If (buttonStatus = "Disconnected") Or (buttonStatus = "") Then
            Return
        End If

        Debug.Assert(buttonStatus = "Speaker button " + buttonidx.ToString + " pressed")
    End Sub

    'add alarm
    Private Sub AddAlarm_Click(sender As Object, e As EventArgs) Handles AddAlarm.Click
        gAlarm.AddAlarmInList(HourAlarm.Value, MinAlarm.Value)
    End Sub

    'remove alarm
    Private Sub DeleteAlarm_Click(sender As Object, e As EventArgs) Handles DeleteAlarm.Click
        gAlarm.DeleteAlarmFromList(AlarmList.SelectedIndex)
    End Sub

    'browse alarm
    Private Sub BrowseAlarm_Click(sender As Object, e As EventArgs) Handles BrowseAlarm.Click
        gAlarm.SelectMusic()
    End Sub

    'test alarm music
    Private Sub TestAlarm_Click(sender As Object, e As EventArgs) Handles TestAlarm.Click
        gAlarm.PlayMusic()
    End Sub

    'snooze alarm music
    Private Sub SnoozeAlarm_Click(sender As Object, e As EventArgs) Handles SnoozeAlarm.Click
        gAlarm.KillMusic()

        'show snoozing
        SnoozeLabel.Visible = True
    End Sub

    'stop alarm
    Private Sub StopAlarm_Click(sender As Object, e As EventArgs) Handles StopAlarm.Click
        gAlarm.KillMusic()

        'stop alarm timer
        TimerAlarm.Stop()

        'stop showing snoozing
        SnoozeLabel.Visible = False
    End Sub

    'load past sensor data
    Private Sub LoadSensorData_Click(sender As Object, e As EventArgs) Handles LoadSensorData.Click
        ClimateTimer.Stop()
        LoadSensorData.Enabled = False
        SensorDateTime.Enabled = False

        Dim sensorDate As String = SensorDateTime.Value.Month.ToString + "-" + SensorDateTime.Value.Day.ToString
        gTcpMgr.ClimateData(sensorDate)

        ClimateTimer.Start()
    End Sub

    'AC on/off button
    Private Sub ACOnOff_Click(sender As Object, e As EventArgs) Handles ACOnOff.Click
        gTcpMgr.mAC.Toggle()
    End Sub

    'load appliance data
    Private Sub LoadApplianceData_Click(sender As Object, e As EventArgs) Handles LoadApplianceData.Click
        Dim applianceDate As String = " " + ApplianceDateTime.Value.Month.ToString + "-" + ApplianceDateTime.Value.Day.ToString

        'plug0 select
        If SelectPlug0.Checked = True Then
            gTcpMgr.mPlug0.GetPowerHistogram(applianceDate)
        End If

        'fluorescent light select
        If SelectFluLight.Checked = True Then
            gTcpMgr.mFluLight.GetPowerHistogram(applianceDate)
        End If

        'balcony light select
        If SelectBalconyLight.Checked = True Then
            gTcpMgr.mBalconyLight.GetPowerHistogram(applianceDate)
        End If

        'fan select
        If SelectFan.Checked = True Then
            gTcpMgr.mFan.GetPowerHistogram(applianceDate)
        End If

        'light bulb select
        If SelectLightBulb.Checked = True Then
            gTcpMgr.mLightBulb.GetPowerHistogram(applianceDate)
        End If

        'plug1 select
        If SelectPlug1.Checked = True Then
            gTcpMgr.mPlug1.GetPowerHistogram(applianceDate)
        End If
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
            Dim enableMotionDetectFlag As Boolean = gTcpMgr.EnableMotionDetect(Int(MotionDetectCheck.Checked))
            Debug.Assert((gTcpMgr.IsConnected(gMotionSensorModuleId) = False) Or (enableMotionDetectFlag = MotionDetectCheck.Checked))

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

        Dim disableVideoFlag As Boolean = gTcpMgr.DisableVideo(Int(VideoCheck.Checked))
        Debug.Assert((gTcpMgr.IsConnected(gCameraModuleId) = False) Or (disableVideoFlag = VideoCheck.Checked))
    End Sub

    'enable/disable audio recording when motion is detected
    Private Sub AudioCheck_CheckedChanged(sender As Object, e As EventArgs) Handles AudioCheck.CheckedChanged
        UpdateAudioCheckColor()

        'update color only during loading phase
        If gLoading = True Then
            Return
        End If

        Dim disableAudioFlag As Boolean = gTcpMgr.DisableAudio(Int(AudioCheck.Checked))
        Debug.Assert((gTcpMgr.IsConnected(gCameraModuleId) = False) Or (disableAudioFlag = AudioCheck.Checked))
    End Sub

    'enable/disable power on scheduler
    Private Sub EnableLightSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles EnableLightSchedule.CheckedChanged
        StartTimeGrp.Enabled = EnableLightSchedule.Checked
        EndTimeGrp.Enabled = EnableLightSchedule.Checked
        DisableLightSchedule.Enabled = EnableLightSchedule.Checked
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

    'AC swing
    Private Sub ACSwing_CheckedChanged(sender As Object, e As EventArgs) Handles ACSwing.CheckedChanged
        gTcpMgr.mAC.SetACSwing(ACSwing.Checked)
    End Sub

    'speaker num pad enable/disable
    Private Sub SpeakerNumPadCheck_CheckedChanged(sender As Object, e As EventArgs) Handles SpeakerNumPadCheck.CheckedChanged
        SpeakerNumPad.Enabled = SpeakerNumPadCheck.Checked
    End Sub



    'Radio buttons
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'plug0 select
    Private Sub SelectPlug0_CheckedChanged(sender As Object, e As EventArgs) Handles SelectPlug0.CheckedChanged
        If SelectPlug0.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gTcpMgr.mPlug0.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gTcpMgr.mPlug0.GetPowerHistogram()
            End If
        End If
    End Sub

    'fluorescent light select
    Private Sub SelectFluLight_CheckedChanged(sender As Object, e As EventArgs) Handles SelectFluLight.CheckedChanged
        If SelectFluLight.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gTcpMgr.mFluLight.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gTcpMgr.mFluLight.GetPowerHistogram()
            End If
        End If
    End Sub

    'balcony light select
    Private Sub SelectBalconyLight_CheckedChanged(sender As Object, e As EventArgs) Handles SelectBalconyLight.CheckedChanged
        If SelectBalconyLight.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gTcpMgr.mBalconyLight.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gTcpMgr.mBalconyLight.GetPowerHistogram()
            End If
        End If
    End Sub

    'fan select
    Private Sub SelectFan_CheckedChanged(sender As Object, e As EventArgs) Handles SelectFan.CheckedChanged
        If SelectFan.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gTcpMgr.mFan.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gTcpMgr.mFan.GetPowerHistogram()
            End If
        End If
    End Sub

    'light bulb select
    Private Sub SelectLightBulb_CheckedChanged(sender As Object, e As EventArgs) Handles SelectLightBulb.CheckedChanged
        If SelectLightBulb.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gTcpMgr.mLightBulb.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gTcpMgr.mLightBulb.GetPowerHistogram()
            End If
        End If
    End Sub

    'plug1 select
    Private Sub SelectPlug1_CheckedChanged(sender As Object, e As EventArgs) Handles SelectPlug1.CheckedChanged
        If SelectPlug1.Checked = True Then
            If gLightSettingsMode = True Then
                'populate schedule
                EnableLightSchedule.Checked = gTcpMgr.mPlug1.GetSchedule()
            End If

            If gPowerHistSelectMode Then
                'populate power on histogram
                gTcpMgr.mPlug1.GetPowerHistogram()
            End If
        End If
    End Sub

    'set snooze timer interval
    Private Sub SnoozeTimers_CheckedChanged(sender As Object, e As EventArgs) Handles SnoozeTimer0.CheckedChanged, SnoozeTimer1.CheckedChanged, SnoozeTimer2.CheckedChanged
        Dim rBtn As RadioButton = DirectCast(sender, RadioButton)

        'extract radio button idx
        Dim rBtnIdx As String = rBtn.Name

        If rBtnIdx = "" Then
            'form loading
            Return
        End If

        rBtnIdx = rBtnIdx.Substring(11, 1)

        'update timer value
        Select Case rBtnIdx
            Case 0 : TimerAlarm.Interval = 300000
            Case 1 : TimerAlarm.Interval = 600000
            Case 2 : TimerAlarm.Interval = 1200000
            Case Else
                Debug.Assert(False)
        End Select

    End Sub

    'ac cool mode selected
    Public Sub ACCoolMode_CheckedChanged(sender As Object, e As EventArgs)
        gTcpMgr.mAC.SetACMode(ACMode.cACCool)
    End Sub

    'ac dry mode
    Public Sub ACDryMode_CheckedChanged(sender As Object, e As EventArgs)
        gTcpMgr.mAC.SetACMode(ACMode.cACDry)
    End Sub

    'ac fan mode selected
    Public Sub ACFanMode_CheckedChanged(sender As Object, e As EventArgs)
        gTcpMgr.mAC.SetACMode(ACMode.cACFan)
    End Sub

    'speaker fm
    Private Sub SpeckerFMEnable_CheckedChanged(sender As Object, e As EventArgs) Handles SpeakerButton23.CheckedChanged
        SpeakerFMButtons.Enabled = SpeakerButton23.Checked
    End Sub

    'speaker bluetooth, usb, memory card
    Private Sub SpeakerModes_CheckedChanged(sender As Object, e As EventArgs) Handles SpeakerButton32.CheckedChanged, SpeakerButton16.CheckedChanged, SpeakerButton15.CheckedChanged
        SpeakerFolderButtons.Enabled = SpeakerButton32.Checked Or SpeakerButton16.Checked

        SpeakerTrackCtrlButtons.Enabled = SpeakerButton32.Checked Or SpeakerButton16.Checked Or SpeakerButton15.Checked
    End Sub



    'timers
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'fetch weather and motion detection status
    Private Sub TimerData_Tick(sender As Object, e As EventArgs) Handles TimerData.Tick
        gTcpMgr.CheckConnectionStatus()

        gTcpMgr.GetWeatherInfo()

        gTcpMgr.GetAirQualityInfo()

        LoadSensorData.Enabled = True
        SensorDateTime.Enabled = True
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

            Dim enableMotionDetectFlag As Boolean = gTcpMgr.EnableMotionDetect(Int(MotionDetectCheck.Checked))
            Debug.Assert((gTcpMgr.IsConnected(gMotionSensorModuleId) = False) Or (enableMotionDetectFlag = MotionDetectCheck.Checked))
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
        If gEnableSpeech = False Then
            Exit Sub
        End If

        SpeechTimer.Stop()

        Dim speechFile As String = GetSpeechFile()
        If speechFile <> "empty" Then
            Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

            'play
            Player.URL = speechFile
            'Player.controls.play()
        End If

        SpeechTimer.Start()
    End Sub

    'If connection is broken, try to reconnect to rpi at every minute
    Private Sub ReconnectTimer_Tick(sender As Object, e As EventArgs) Handles ReconnectTimer.Tick
        'ReconnectTimer.Interval = 1000
        gTcpMgr.ConnectModules()
    End Sub

    'disable led buttons after 1 hr
    Private Sub LEDTimer_Tick(sender As Object, e As EventArgs)
        LEDButtons.Enabled = False
        SpeakerButtons.Enabled = False
    End Sub

    'updates current time
    Private Sub TimerLessThan1s_Tick(sender As Object, e As EventArgs) Handles Timer500ms.Tick
        Dim curTime As String = "Current Time - "
        Dim curHr As Integer = Now.TimeOfDay.Hours

        Select Case curHr
            Case 0 To 9 : curTime = curTime + "0" + curHr.ToString + ":"
            Case 10 To 12 : curTime += curHr.ToString + ":"
            Case 13 To 21 : curTime += "0" + (curHr - 12).ToString + ":"
            Case 22 To 23 : curTime += (curHr - 12).ToString + ":"
        End Select

        Dim curMin As Integer = Now.TimeOfDay.Minutes

        If curMin < 10 Then
            curTime += "0" + curMin.ToString + ":"
        Else : curTime += curMin.ToString + ":"
        End If

        Dim curSec As Integer = Now.TimeOfDay.Seconds

        If curSec < 10 Then
            curTime += "0" + curSec.ToString + " "
        Else : curTime += curSec.ToString + " "
        End If

        If curHr >= 12 Then
            curTime = curTime + "pm"
        Else : curTime = curTime + "am"
        End If

        Dim curTimeInMin As Integer = curHr * 60 + curMin
        Dim prevTimeInMin As Integer = curTimeInMin

        If RealTime.Text <> "Current Time : hh.mm.ss pm" Then
            Dim prevTime As String = RealTime.Text.Substring(15, 11)
            Dim isPM As String = prevTime.Substring(prevTime.Length - 2, 2)
            Dim prevHr As Integer = prevTime.Substring(0, 2)
            If isPM = "pm" Then
                prevHr += 12
            End If
            Dim prevMin As Integer = prevTime.Substring(3, 2)

            prevTimeInMin = prevHr * 60 + prevMin
        End If

        'update displayed time
        If curTime <> RealTime.Text Then
            RealTime.Text = curTime
        End If

        'check for alarm
        gAlarm.CheckAndTriggerAlarm(prevTimeInMin, curTimeInMin)

        'dump tcp disconnnection debug info
        gTcpMgr.DumpDebugInfo()

        'update connected time data
        gTcpMgr.UpdateConnectedTime()
    End Sub

    'alarm timer 
    Private Sub TimerAlarm_Tick(sender As Object, e As EventArgs) Handles TimerAlarm.Tick
        gAlarm.PlayMusic()
    End Sub

    'update form controls
    Private Sub ControlRefreshTimer_Tick(sender As Object, e As EventArgs) Handles ControlRefreshTimer.Tick
        gLoading = True

        'fetch data if it is pending
        gTcpMgr.FetchDataIfPending()


        'enable controls depending connection status of different RPIs
        EnableAllWidgets()


        'refresh climate data once
        gTcpMgr.DisplayGraph(TemperatureData, Color.Crimson, Color.Green, 0, gTcpMgr.GetTemperatureReadings())
        gTcpMgr.DisplayGraph(HumidityData, Color.Brown, Color.Green, 1, gTcpMgr.GetHumidityReadings())
        gTcpMgr.DisplayGraph(PressureData, Color.Blue, Color.Green, 2, gTcpMgr.GetPressureReadings())


        'refresh weather data
        Dim curTemperature As Double = gTcpMgr.GetTemperature()
        If curTemperature > 0 Then
            Dim newText As String = "Temperature : " + curTemperature.ToString + " ^C"
            If Temperature.Text <> newText Then
                Temperature.Text = newText
                UpdateTemperatureColor(curTemperature)
            End If
        End If

        Dim curHumidity As Double = gTcpMgr.GetHumidity()
        If curHumidity > 0 Then
            Dim newText As String = "Humidity : " + curHumidity.ToString
            If Humidity.Text <> newText Then
                Humidity.Text = newText
                UpdateHumidityColor(curHumidity)
            End If
        End If

        Dim curPressure As Double = gTcpMgr.GetPressure()
        If curPressure > 0 Then
            Dim newText As String = "Atmospheric Pressure : " + curPressure.ToString + " Pa"
            If Pressure.Text <> newText Then
                Pressure.Text = newText
                UpdatePressureColor(curPressure)
            End If
        End If


        'refresh gas sensors data
        Dim curAlcoholReading As Integer = gTcpMgr.GetAlcoholReading()
        If curAlcoholReading > 0 Then
            Dim newText As String = "Alcohol : " + curAlcoholReading.ToString
            If Alcohol.Text <> newText Then
                Alcohol.Text = newText
                UpdateAlcoholColor(curAlcoholReading)
            End If
        End If

        Dim curCOReading As Integer = gTcpMgr.GetCOReading()
        If curCOReading > 0 Then
            Dim newText As String = "CO : " + curCOReading.ToString
            If CO.Text <> newText Then
                CO.Text = newText
                UpdateCOColor(curCOReading)
            End If
        End If

        Dim curSmokeReading As Integer = gTcpMgr.GetSmokeReading()
        If curSmokeReading > 0 Then
            Dim newText As String = "Smoke : " + curSmokeReading.ToString
            If Smoke.Text <> newText Then
                Smoke.Text = newText
                UpdateSmokeColor(curSmokeReading)
            End If
        End If


        'refresh motion detection data
        Dim motionStatus As String = gTcpMgr.GetMotionDetectionStatus()
        If motionStatus <> "" Then
            MonitorStatus.Text += motionStatus
            gTcpMgr.ClearMotionDetectionStatus()

            'welcome speech
            Speech("Welcome_")

            'disable surveillance box
            SurveillanceGrp.Enabled = False

            'switch on light
            If MotionDetectPowerOn.Checked = False Then
                Dim curTime As Date = DateAndTime.Now
                If (curTime.Hour >= 18) Or (curTime.Hour <= 2) Then
                    gTcpMgr.mFluLight.SetPowerOn()
                End If
            End If
        End If


        'refresh snooze status based on touch sensor output
        Dim touchSensorStatus As String = gTcpMgr.GetTouchSensorStatusData()
        If touchSensorStatus <> "" Then
            gTcpMgr.ClearTouchDetectionStatus()

            'touch button pressed
            gAlarm.KillMusic()

            'show snoozing
            SnoozeLabel.Visible = True
        End If


        'refresh motion, video, audio check status
        If gTcpMgr.IsMotionAndCamStatusPending() = True Then
            MotionDetectCheck.Checked = gTcpMgr.IsMotionDetectionEnabled()
            VideoCheck.Checked = gTcpMgr.IsVideoDisabled()
            AudioCheck.Checked = gTcpMgr.IsAudioDisabled()
        End If


        'refresh connect button text
        Dim connectText As String = gTcpMgr.GetConnectButtonStatus()
        If Connect.Text <> connectText Then
            Connect.Text = connectText
            If connectText = "Connect" Then
                'change connect button color to reddish
                Connect.BackColor = Color.FromArgb(255, 128, 128)
            Else
                'change connect button color sky blue
                Connect.BackColor = Color.LightSkyBlue
            End If
        End If


        'update appliance color
        gTcpMgr.mFluLight.UpdateColor()
        gTcpMgr.mPlug0.UpdateColor()
        gTcpMgr.mFan.UpdateColor()
        gTcpMgr.mBalconyLight.UpdateColor()
        gTcpMgr.mLightBulb.UpdateColor()
        gTcpMgr.mPlug1.UpdateColor()

        'update ac color, controls
        gTcpMgr.mAC.UpdateColor()
        gTcpMgr.mAC.UpdateACControls()

        gLoading = False
    End Sub

    'cimate timer
    Private Sub ClimateTimer_Tick(sender As Object, e As EventArgs) Handles ClimateTimer.Tick
        gTcpMgr.ClimateData()
        LoadSensorData.Enabled = True
        SensorDateTime.Enabled = True
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

    'am/pm seltection while setting alarm
    Private Sub AmPmAlarm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AmPmAlarm.SelectedIndexChanged
        If AmPmAlarm.SelectedIndex = 0 Then
            HourAlarm.Maximum = 11
            HourAlarm.Minimum = 0
        ElseIf AmPmAlarm.SelectedIndex = 1 Then
            HourAlarm.Maximum = 12
            HourAlarm.Minimum = 1
        End If
    End Sub



    'Numeric UpDown
    '--------------------------------------------------------------------------------------------------------------------------

    'AC temerature
    Public Sub ACTemp_ValueChanged(sender As Object, e As EventArgs)
        gTcpMgr.mAC.SetACTempature(ACTemp.Value)
    End Sub

    'AC fan speed
    Public Sub ACFanSpeed_ValueChanged(sender As Object, e As EventArgs)
        gTcpMgr.mAC.SetACFanSpeed(ACFanSpeed.Value)
    End Sub



    'others
    '--------------------------------------------------------------------------------------------------------------------------

    'enable/disable widgets
    Public Sub EnableAllWidgets()
        Fetch.Enabled = gTcpMgr.IsConnected(gLightings1ModuleId)
        Toggleled.Enabled = gTcpMgr.IsConnected(gLightings2ModuleId)

        Tabs.TabPages(0).Enabled = gTcpMgr.IsConnected(gMotionSensorModuleId) And gTcpMgr.IsConnected(gCameraModuleId)
        Tabs.TabPages(1).Enabled = True
        Tabs.TabPages(2).Enabled = gTcpMgr.IsConnected(gLircModuleId)
        Tabs.TabPages(3).Enabled = True
        Tabs.TabPages(4).Enabled = gTcpMgr.IsConnected(gWeatherModuleId)
    End Sub

    'enable all radio buttons
    Private Sub EnableAllRadioButtons()
        SelectPlug1.Visible = True
        SelectLightBulb.Visible = True
        SelectFan.Visible = True
        SelectFluLight.Visible = True
        SelectPlug0.Visible = True
        'SelectBalconyLight.Visible = True
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
