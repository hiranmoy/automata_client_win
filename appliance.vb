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


Public Class Appliance

    'button associated the appliance
    Private mButton As Button

    'on color
    Private mOnColor As Color

    'off color
    Private mOffColor As Color

    'power on status
    Private mPowerOn As Boolean

    'tcp command for getting the status from RPI
    Private mTcpGetCommand As String

    'tcp command for setting the status in RPI
    Private mTcpSetCommand As String

    'tcp command for setting the status in RPI
    Private mTcpProfileCommand As String

    'toggle timer value in sec
    Private mTimerVal As Integer

    'on time value in sec
    Private mStartTime As Integer

    'off time value in sec
    Private mStopTime As Integer

    'check whether scheduling is disabled next time
    Private mDisableSwitchOnScheduler As Boolean
    Private mDisableSwitchOffScheduler As Boolean

    'average power requirement in W
    Private mPowerRequirement As Integer


    'constructor
    Public Sub New(aButton As Button,
                   onColor As Color,
                   offColor As Color,
                   tcpGetCommand As String,
                   tcpSetCommand As String,
                   tcpProfileCommand As String,
                   power As Integer)
        mButton = aButton
        mOnColor = onColor
        mOffColor = offColor
        mTcpGetCommand = tcpGetCommand
        mTcpSetCommand = tcpSetCommand
        mTcpProfileCommand = tcpProfileCommand
        mPowerRequirement = power

        'initialization
        mTimerVal = -1
        mStartTime = 86400
        mStopTime = -1

        'load schedule
        RestoreSchedule()

        'pwr on status
        mPowerOn = False
    End Sub

    'updates background color of the button depending on the on/off status
    Public Sub UpdateColor()
        If mPowerOn = True Then
            mButton.BackColor = mOnColor
        Else
            mButton.BackColor = mOffColor
        End If
    End Sub

    'restore scheduler data
    Private Sub RestoreSchedule()
        Dim file As String = My.Application.Info.DirectoryPath + "\" + mButton.Name + "\settings.ini"
        If My.Computer.FileSystem.FileExists(file) = False Then
            Return
        End If

        FileOpen(1, file, OpenMode.Input)

        Dim data As String = LineInput(1)
        mStartTime = Int(data.Substring(0, 7))

        data = LineInput(1)
        mStopTime = Int(data.Substring(0, 7))

        FileClose(1)
    End Sub

    'set toggle timer and scheduler information as tool tip
    Private Sub SetTooltipOnButton()
        Dim toolTipTxt As String = ""

        'convert sec to hh:mm:ss
        If ((mStartTime >= 0) And (mStartTime < 86400) And
            (mStopTime >= 0) And (mStopTime < 86400)) Then
            Dim hr0 As Integer = Int(mStartTime / 3600)
            Dim min0 As Integer = Int((mStartTime / 60) Mod 60)
            Dim sec0 As Integer = Int(mStartTime Mod 60)
            Dim startTime As String = hr0.ToString + ":" + min0.ToString + ":" + sec0.ToString

            Dim hr1 As Integer = Int(mStopTime / 3600)
            Dim min1 As Integer = Int((mStopTime / 60) Mod 60)
            Dim sec1 As Integer = Int(mStopTime Mod 60)
            Dim stopTime As String = hr1.ToString + ":" + min1.ToString + ":" + sec1.ToString

            toolTipTxt = startTime + "-" + stopTime
        End If

        'convert sec to hh:mm:ss
        If mTimerVal > 0 Then
            If toolTipTxt <> "" Then
                toolTipTxt = toolTipTxt + Environment.NewLine
            End If

            Dim hr As Integer = Int(mTimerVal / 3600)
            Dim min As Integer = Int((mTimerVal / 60) Mod 60)
            Dim sec As Integer = Int(mTimerVal Mod 60)

            Dim timerVal As String = "Toggling after "
            If hr > 0 Then
                timerVal = timerVal + hr.ToString + " hrs "
            End If
            If min > 0 Then
                timerVal = timerVal + min.ToString + " mins "
            End If
            If sec > 0 Then
                timerVal = timerVal + sec.ToString + " secs"
            End If

            toolTipTxt = toolTipTxt + timerVal
        End If

        homeCtrl.ToolTip1.SetToolTip(mButton, toolTipTxt)
    End Sub

    'populate power profile graph
    Public Sub GetPowerHistogram()
        'clear power profile graph
        homeCtrl.pwHist.Series.Clear()

        Dim col As String = "Power consumption" + Environment.NewLine +
                            "in (kWh)" + Environment.NewLine +
                            "of" + Environment.NewLine +
                            mButton.Text + Environment.NewLine +
                            "at" + Environment.NewLine +
                            DateAndTime.Now.ToString
        homeCtrl.pwHist.Series.Add(col)

        If gTcpMgr.IsConnected(gWeatherModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter(mTcpProfileCommand, gLightings1ModuleId)
        Dim profile As String = gTcpMgr.GetResponse(tcpParam)
        If (profile = "Disconnected") Or (profile = "") Then
            Return
        End If

        ' Split string based on ',' character
        Dim params As String() = profile.Split(New Char() {","c})
        Debug.Assert(params.Length() = 24)

        Dim minVal As Double = 1000000
        Dim maxVal As Double = -1
        For hrIdx = 0 To 23
            Debug.Assert(IsNumeric(params(hrIdx)))

            Dim val As Double = CDbl(params(hrIdx))

            'convert switched on time to kWh
            val = (val / 60) * mPowerRequirement / 1000
            val = Math.Round(val, 3)

            'add points in the graph
            homeCtrl.pwHist.Series(col).Points.AddXY(hrIdx, val)

            'set minimum value
            If minVal > val Then
                minVal = val
            End If

            'set maximum value
            If maxVal < val Then
                maxVal = val
            End If
        Next

        Debug.Assert((minVal >= 0) And (maxVal >= minVal))
        If maxVal = minVal Then
            maxVal += 1
        End If

        'y-axis: interval = (max - min)/5
        homeCtrl.pwHist.ChartAreas.Min.AxisY.Minimum = minVal
        homeCtrl.pwHist.ChartAreas.Min.AxisY.Maximum = maxVal
        homeCtrl.pwHist.ChartAreas.Min.AxisY.Interval = (maxVal - minVal) / 5
    End Sub

    'on/off appliance
    Public Sub SetPowerOn(Optional powerOn As Boolean = True)
        If gTcpMgr.IsConnected(gLightings1ModuleId) = False Then
            Exit Sub
        End If

        mPowerOn = powerOn

        Dim tcpParam As TcpParameter = New TcpParameter(mTcpSetCommand + Str(Int(mPowerOn)), gLightings1ModuleId)
        Dim data As String = gTcpMgr.GetResponse(tcpParam)
        If data = "Disconnected" Then
            Return
        End If
        Debug.Assert((Int(data) = 0) Or (Int(data) = 1))

        Debug.Assert(CBool(Int(data)) = mPowerOn)
        UpdateColor()
    End Sub

    Public Sub CheckPowerOnStatus()
        If gTcpMgr.IsConnected(gLightings1ModuleId) = False Then
            Exit Sub
        End If

        'get on/off status from the RPI
        Dim tcpParam As TcpParameter = New TcpParameter(mTcpGetCommand, gLightings1ModuleId)
        Dim data As String = gTcpMgr.GetResponse(tcpParam)
        If data = "Disconnected" Then
            Return
        End If
        mPowerOn = CBool(Int(data))

        'update color depending on the on/off status
        UpdateColor()
    End Sub

    'set toggle timer value
    Public Sub SetTimerVal(timerVal As Integer)
        Debug.Assert(timerVal >= 0)
        mTimerVal = timerVal
    End Sub

    'save scheduler data
    Public Sub SaveSchedule(startTime As Integer, endTime As Integer, disabled As Boolean)
        Debug.Assert((startTime >= 0) And (startTime < 86400) And
                     (endTime >= 0) And (endTime < 86400))

        If startTime = endTime Then
            MsgBox("Start time and end time are equal")
            Return
        End If

        mStartTime = startTime
        mStopTime = endTime

        'create the folder if doesn't exist
        Dim folder As String = My.Application.Info.DirectoryPath + "\" + mButton.Name
        If My.Computer.FileSystem.DirectoryExists(folder) = False Then
            My.Computer.FileSystem.CreateDirectory(folder)
        End If

        'dump startTime and endTime in settings file
        FileOpen(1, folder + "\settings.ini", OpenMode.Output)

        Print(1, mStartTime.ToString + "        : on time" + Environment.NewLine)
        Print(1, mStopTime.ToString + "        : off time" + Environment.NewLine)

        FileClose(1)

        mDisableSwitchOnScheduler = disabled
        mDisableSwitchOffScheduler = disabled
    End Sub

    'clear scheduler
    Public Sub ResetSchedule()
        If homeCtrl.EnableLightSchedule.Checked = True Then
            Dim file As String = My.Application.Info.DirectoryPath + "\" + mButton.Name + "\settings.ini"
            If My.Computer.FileSystem.FileExists(file) = True Then
                My.Computer.FileSystem.DeleteFile(file)
            End If

            mStartTime = 86400
            mStopTime = -1
        End If

        If homeCtrl.ToggleLightings.Checked = True Then
            mTimerVal = -1
        End If
    End Sub

    'updates scheduler values and returns true if scheduler is enabled
    Public Function GetSchedule() As Boolean
        'enable scheduling and timer checks
        homeCtrl.EnableLightSchedule.Enabled = True
        homeCtrl.ToggleLightings.Enabled = True

        If (mStartTime < 0) Or (mStartTime >= 86400) Then
            Return False
        End If
        If (mStopTime < 0) Or (mStopTime >= 86400) Then
            Return False
        End If

        'convert hh:mm:ss to sec
        homeCtrl.hr0.Value = Int(mStartTime / 3600)
        homeCtrl.min0.Value = Int((mStartTime / 60) Mod 60)
        homeCtrl.sec0.Value = Int(mStartTime Mod 60)

        'convert hh:mm:ss to sec
        homeCtrl.hr1.Value = Int(mStopTime / 3600)
        homeCtrl.min1.Value = Int((mStopTime / 60) Mod 60)
        homeCtrl.sec1.Value = Int(mStopTime Mod 60)

        Return True
    End Function

    'toggle appliance
    Public Sub Toggle()
        SetPowerOn(Not mPowerOn)
    End Sub

    'decrease toggle timer value by 1 and update tool tip text
    Public Sub TimerToggle()
        If mTimerVal >= 0 Then
            mTimerVal -= 1
        End If

        If mTimerVal = 0 Then
            Toggle()
        End If

        SetTooltipOnButton()
    End Sub

    'set scheduler data
    Public Sub SetSchedule()
        If (mStartTime < 0) Or (mStartTime >= 86400) Then
            Return
        End If
        If (mStopTime < 0) Or (mStopTime >= 86400) Then
            Return
        End If

        Dim curTime As Integer = DateAndTime.Now.Hour * 3600 +
                                 DateAndTime.Now.Minute * 60 +
                                 DateAndTime.Now.Second

        If (curTime >= mStartTime) And (curTime < mStartTime + 1) Then
            If mPowerOn = False Then
                If mDisableSwitchOnScheduler = True Then
                    mDisableSwitchOnScheduler = False
                Else
                    SetPowerOn()
                End If
            End If
        End If
        If (curTime >= mStopTime) And (curTime < mStopTime + 1) Then
            If mPowerOn = True Then
                If mDisableSwitchOffScheduler = True Then
                    mDisableSwitchOffScheduler = False
                Else
                    SetPowerOn(False)
                End If
            End If
        End If
    End Sub

End Class
