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


Imports System.Threading


Public Class Appliance

    'button associated the appliance
    Private mButton As Button

    'radio button associated the appliance
    Private mSelect As RadioButton

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

    'module Id
    Private mModuleId As Integer

    'toggle timer value in sec
    Private mTimerVal As Integer

    'on time value in sec
    Private mStartTime As Integer

    'off time value in sec
    Private mStopTime As Integer

    'check whether scheduling is disabled
    Private mDisableScheduler As Boolean

    'number of points in a graph
    Public mNumPointsInGraph As Integer

    'power consumption data
    Private mPowerConsumpton() As Double


    'constructor
    Public Sub New(aButton As Button,
                   aSelect As RadioButton,
                   onColor As Color,
                   offColor As Color,
                   tcpGetCommand As String,
                   tcpSetCommand As String,
                   tcpProfileCommand As String,
                   moduleId As Integer,
                   power As Integer)
        mButton = aButton
        mSelect = aSelect
        mOnColor = onColor
        mOffColor = offColor
        mTcpGetCommand = tcpGetCommand
        mTcpSetCommand = tcpSetCommand
        mTcpProfileCommand = tcpProfileCommand
        mModuleId = moduleId

        'initialization
        mTimerVal = -1
        mStartTime = 1440
        mStopTime = -1
        mDisableScheduler = False

        'load schedule
        RestoreSchedule()

        'pwr on status
        mPowerOn = False

        'initilize number of points
        mNumPointsInGraph = 480

        'initilize power consumption data
        ReDim mPowerConsumpton(mNumPointsInGraph - 1)
        For idx = 0 To mPowerConsumpton.Length - 1
            mPowerConsumpton(idx) = 0
        Next
    End Sub

    'return name
    Public Function GetName() As String
        Return mButton.Name
    End Function

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
        Dim file As String = My.Application.Info.DirectoryPath + "\" + GetName() + "\settings.ini"
        If My.Computer.FileSystem.FileExists(file) = False Then
            Return
        End If

        FileOpen(1, file, OpenMode.Input)

        Dim data As String = LineInput(1)
        mStartTime = Int(data.Substring(0, 7))

        data = LineInput(1)
        mStopTime = Int(data.Substring(0, 7))

        data = LineInput(1)
        mDisableScheduler = CBool(Int(data.Substring(0, 7)))

        FileClose(1)

        SetTooltipOnButton()
    End Sub

    'set toggle timer and scheduler information as tool tip
    Private Sub SetTooltipOnButton()
        Dim toolTipTxt As String = ""

        'convert sec to hh:mm:ss
        If ((mStartTime >= 0) And (mStartTime < 1440) And
            (mStopTime >= 0) And (mStopTime < 1440)) Then
            Dim hr0 As Integer = Int(mStartTime / 60)
            Dim min0 As Integer = Int(mStartTime Mod 60)

            Dim startTime As String = hr0.ToString + ":" + min0.ToString + ":0"

            Dim hr1 As Integer = Int(mStopTime / 60)
            Dim min1 As Integer = Int(mStopTime Mod 60)

            Dim stopTime As String = hr1.ToString + ":" + min1.ToString + ":0"

            toolTipTxt = startTime + "-" + stopTime

            If mDisableScheduler = True Then
                toolTipTxt = toolTipTxt + " (disabled)"
            End If
        End If

        'convert sec to hh:mm:ss
        If mTimerVal > 0 Then
            If toolTipTxt <> "" Then
                toolTipTxt = toolTipTxt + Environment.NewLine
            End If

            Dim hr As Integer = Int(mTimerVal / 60)
            Dim min As Integer = Int(mTimerVal Mod 60)

            Dim timerVal As String = "Toggling after "
            If hr > 0 Then
                timerVal = timerVal + hr.ToString + " hrs "
            End If
            If min > 0 Then
                timerVal = timerVal + min.ToString + " mins "
            End If

            toolTipTxt = toolTipTxt + timerVal
        End If

        homeCtrl.ToolTip1.SetToolTip(mButton, toolTipTxt)
    End Sub

    'populate power profile graph
    Public Sub GetPowerHistogram(Optional applianceData As String = " ")
        If gTcpMgr.IsConnected(mModuleId) = False Then
            Exit Sub
        End If

        If mSelect.Checked = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter(mTcpProfileCommand + applianceData, mModuleId, 0, 480)
        Dim profile As String = gTcpMgr.GetResponse(tcpParam)
        If (profile = "Disconnected") Or (profile = "") Then
            Return
        End If

        For idx = 0 To tcpParam.GetNumPackets() - 1
            If tcpParam.GetResponse(idx) = "" Then
                mPowerConsumpton(idx) = 0
                Continue For
            End If

            Debug.Assert(IsNumeric(tcpParam.GetResponse(idx)))
            mPowerConsumpton(idx) = CDbl(tcpParam.GetResponse(idx))
        Next

        'clear power profile graph
        homeCtrl.pwHist.Series.Clear()

        'set date for column
        Dim powerDate As String = ""
        If applianceData = " " Then
            powerDate = " " + DateAndTime.Now.Day.ToString + "/" + DateAndTime.Now.Month.ToString
        Else
            ' Split string based on '-' character
            Dim params As String() = applianceData.Split(New Char() {"-"c})
            Debug.Assert(params.Length() = 2)
            Debug.Assert(IsNumeric(params(0)))
            Debug.Assert(IsNumeric(params(1)))

            powerDate = " " + params(1) + "/" + params(0)
        End If

        Dim energyConsumption As Double = 0
        For idx = 0 To mPowerConsumpton.Length - 1
            If applianceData = " " Then
                If idx > (DateAndTime.Now.Hour * 60 + DateAndTime.Now.Minute) / (1440 / mNumPointsInGraph) Then
                    Exit For
                End If
            End If

            energyConsumption += mPowerConsumpton(idx)
        Next
        energyConsumption = Math.Round((energyConsumption / (60 * 1000)) * (1440 / mNumPointsInGraph), 2)

        Dim col As String = "Power consumption" + Environment.NewLine +
                            "in (kWh)" + Environment.NewLine +
                            "of" + Environment.NewLine +
                            mButton.Text + Environment.NewLine +
                            "on" + powerDate + Environment.NewLine +
                            "Energy usage : " + energyConsumption.ToString + " units"
        homeCtrl.pwHist.Series.Add(col)

        'set chart type
        homeCtrl.pwHist.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column

        gTcpMgr.DisplayGraph(homeCtrl.pwHist, Color.IndianRed, Color.Green, 3, mPowerConsumpton)
    End Sub

    'on/off appliance
    Public Overridable Sub SetPowerOn(Optional powerOn As Boolean = True)
        If gTcpMgr.IsConnected(mModuleId) = False Then
            Exit Sub
        End If

        mPowerOn = powerOn

        Dim tcpParam As TcpParameter = New TcpParameter(mTcpSetCommand + Str(Int(mPowerOn)), mModuleId, 1)
        Dim data As String = gTcpMgr.GetResponse(tcpParam)
        If data = "Disconnected" Then
            Return
        End If
        Debug.Assert((Int(data) = 0) Or (Int(data) = 1))

        Debug.Assert(CBool(Int(data)) = mPowerOn)
        UpdateColor()
    End Sub

    'set mPowerOn
    Public Sub SetPowerStatus(powerOn As Boolean)
        mPowerOn = powerOn
    End Sub

    'return power status
    Public Function GetPowerStatus() As Boolean
        Return mPowerOn
    End Function

    'check power on/off status from rpi
    Public Sub CheckPowerOnStatus()
        If gTcpMgr.IsConnected(mModuleId) = False Then
            Exit Sub
        End If

        'on/off status command from the RPI
        Dim tcpParam As TcpParameter = New TcpParameter(mTcpGetCommand, mModuleId, 1)

        'thread to get touch sensor pressed status from RPI
        Dim powerOnStatusTrd As Thread = New Thread(AddressOf CheckPowerOnStatusTrd)
        powerOnStatusTrd.Start(tcpParam)
    End Sub

    'check power on/off status from rpi
    Private Sub CheckPowerOnStatusTrd(atcpParam As TcpParameter)
        If gTcpMgr.IsConnected(mModuleId) = False Then
            Exit Sub
        End If

        Dim data As String = gTcpMgr.GetResponse(atcpParam)
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If

        mPowerOn = CBool(Int(data))
    End Sub

    'return rpi module id
    Public Function GetModuleId() As Integer
        Return mModuleId
    End Function

    'set toggle timer value
    Public Sub SetTimerVal(timerVal As Integer)
        If mSelect.Checked = False Then
            Exit Sub
        End If

        Debug.Assert(timerVal >= 0)
        mTimerVal = timerVal

        SetTooltipOnButton()
    End Sub

    'save scheduler data
    Public Sub SaveSchedule(startTime As Integer, endTime As Integer, disabled As Boolean)
        If mSelect.Checked = False Then
            Exit Sub
        End If

        Debug.Assert((startTime >= 0) And (startTime < 1440) And
                     (endTime >= 0) And (endTime < 1440))

        If startTime = endTime Then
            MsgBox("Start time and end time are equal")
            Return
        End If

        mStartTime = startTime
        mStopTime = endTime
        mDisableScheduler = disabled

        'create the folder if doesn't exist
        Dim folder As String = My.Application.Info.DirectoryPath + "\" + GetName()
        If My.Computer.FileSystem.DirectoryExists(folder) = False Then
            My.Computer.FileSystem.CreateDirectory(folder)
        End If

        'dump startTime and endTime in settings file
        FileOpen(1, folder + "\settings.ini", OpenMode.Output)

        Print(1, mStartTime.ToString + "        : on time" + Environment.NewLine)
        Print(1, mStopTime.ToString + "        : off time" + Environment.NewLine)
        Print(1, Int(mDisableScheduler).ToString + "        : scheduling enabled/disabled" + Environment.NewLine)

        FileClose(1)

        SetTooltipOnButton()
    End Sub

    'clear scheduler
    Public Sub ResetSchedule()
        If homeCtrl.EnableLightSchedule.Checked = True Then
            Dim file As String = My.Application.Info.DirectoryPath + "\" + GetName() + "\settings.ini"
            If My.Computer.FileSystem.FileExists(file) = True Then
                My.Computer.FileSystem.DeleteFile(file)
            End If

            mStartTime = 1440
            mStopTime = -1
            mDisableScheduler = False
        End If

        If homeCtrl.ToggleLightings.Checked = True Then
            mTimerVal = -1
        End If
    End Sub

    'updates scheduler values and returns true if scheduler is enabled
    Public Sub GetSchedule()
        If mSelect.Checked = False Then
            Exit Sub
        End If

        If ((mStartTime >= 0) And (mStartTime < 1440) And (mStopTime >= 0) And (mStopTime < 1440)) Then
            'convert hh:mm to min
            homeCtrl.hr0.Value = Int(mStartTime / 60)
            homeCtrl.min0.Value = Int(mStartTime Mod 60)

            'convert hh:mm to min
            homeCtrl.hr1.Value = Int(mStopTime / 60)
            homeCtrl.min1.Value = Int(mStopTime Mod 60)

            'disabled check
            homeCtrl.DisableLightSchedule.Checked = mDisableScheduler

            'check schedular
            homeCtrl.EnableLightSchedule.Checked = True
        End If

        If mTimerVal > 0 Then
            'convert hh:mm to min
            homeCtrl.hr2.Value = Int(mTimerVal / 60)
            homeCtrl.min2.Value = Int(mTimerVal Mod 60)

            'check timer
            homeCtrl.ToggleLightings.Checked = True
        End If
    End Sub

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
    Public Sub CheckSchedule()
        If mDisableScheduler = True Then
            Exit Sub
        End If
        If (mStartTime < 0) Or (mStartTime >= 1440) Then
            Exit Sub
        End If
        If (mStopTime < 0) Or (mStopTime >= 1440) Then
            Exit Sub
        End If

        Dim curTime As Integer = DateAndTime.Now.Hour * 60 +
                                 DateAndTime.Now.Minute

        If (curTime >= mStartTime) And (curTime < mStartTime + 1) Then
            If mPowerOn = False Then
                SetPowerOn()
            End If
        End If
        If (curTime >= mStopTime) And (curTime < mStopTime + 1) Then
            If mPowerOn = True Then
                SetPowerOn(False)
            End If
        End If
    End Sub

End Class
