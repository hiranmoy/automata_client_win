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


Public Class AC
    Inherits Appliance

    'AC mode
    Private mMode As ACMode

    'temperature
    Private mCurTemperature As Integer

    'Fan speed
    Private mFanSpeed As Integer

    'swing
    Private mSwing As Boolean

    'update controls
    Private mUpdateControls As Boolean

    'temperatures
    Private mTemperatures(23) As Integer


    Public Sub New(aButton As Button,
                   aRadioButton As RadioButton,
                   onColor As Color,
                   offColor As Color,
                   tcpProfileCommand As String,
                   moduleId As Integer,
                   power As Integer)
        MyBase.New(aButton, aRadioButton, onColor, offColor, "", "", tcpProfileCommand, moduleId, power)

        mMode = ACMode.cACCool
        mCurTemperature = 25
        mFanSpeed = 3
        mSwing = False

        'initialize temperatures to 28^C
        For idx = 0 To mTemperatures.Length - 1
            mTemperatures(idx) = 28
        Next

        'add event handlers
        AddHandler homeCtrl.ACTemp.ValueChanged, AddressOf homeCtrl.ACTemp_ValueChanged
        AddHandler homeCtrl.ACFanSpeed.ValueChanged, AddressOf homeCtrl.ACFanSpeed_ValueChanged
        AddHandler homeCtrl.ACCoolMode.CheckedChanged, AddressOf homeCtrl.ACCoolMode_CheckedChanged
        AddHandler homeCtrl.ACDryMode.CheckedChanged, AddressOf homeCtrl.ACDryMode_CheckedChanged
        AddHandler homeCtrl.ACFanMode.CheckedChanged, AddressOf homeCtrl.ACFanMode_CheckedChanged
    End Sub

    'set AC mode
    Public Sub SetACMode(ByVal aMode As Integer, Optional sendACSignalFlag As Boolean = True)
        If mUpdateControls = True Then
            Return
        End If

        mMode = aMode

        Select Case mMode
            Case ACMode.cACCool
                homeCtrl.ACTemp.Enabled = True
                homeCtrl.ACFanSpeed.Enabled = True
                homeCtrl.ACFanSpeed.Maximum = 4
            Case ACMode.cACDry
                homeCtrl.ACTemp.Enabled = True
                homeCtrl.ACFanSpeed.Enabled = False
            Case ACMode.cACFan
                homeCtrl.ACTemp.Enabled = False
                homeCtrl.ACFanSpeed.Enabled = True
                homeCtrl.ACFanSpeed.Maximum = 3
            Case Else
                Debug.Assert(False)
        End Select

        If sendACSignalFlag = True Then
            SendACSignal()
        End If
    End Sub

    'set AC temrature
    Public Sub SetACTempature(temp As Integer, Optional sendACSignalFlag As Boolean = True)
        If mUpdateControls = True Then
            Return
        End If

        mCurTemperature = temp

        If sendACSignalFlag = True Then
            SendACSignal()
        End If
    End Sub

    'set AC fan speed
    Public Sub SetACFanSpeed(fanSpeed As Integer, Optional sendACSignalFlag As Boolean = True)
        If mUpdateControls = True Then
            Return
        End If

        mFanSpeed = fanSpeed

        If sendACSignalFlag = True Then
            SendACSignal()
        End If
    End Sub

    'set AC swing
    Public Sub SetACSwing(swing As Boolean, Optional sendACSignalFlag As Boolean = True)
        If mUpdateControls = True Then
            Return
        End If

        mSwing = swing

        If sendACSignalFlag = True Then
            SendACSignal()
        End If
    End Sub

    'update AC controls
    Public Sub UpdateACControls()
        If mUpdateControls = False Then
            Return
        End If

        homeCtrl.ACCoolMode.Checked = False
        homeCtrl.ACDryMode.Checked = False
        homeCtrl.ACFanMode.Checked = False

        Select Case mMode
            Case ACMode.cACCool : homeCtrl.ACCoolMode.Checked = True
            Case ACMode.cACDry : homeCtrl.ACDryMode.Checked = True
            Case ACMode.cACFan : homeCtrl.ACFanMode.Checked = True
            Case Else
                Debug.Assert(False)
        End Select

        homeCtrl.ACTemp.Value = mCurTemperature
        homeCtrl.ACFanSpeed.Value = mFanSpeed
        homeCtrl.ACSwing.Checked = mSwing

        mUpdateControls = False
    End Sub

    'send AC IR signal
    Private Sub SendACSignal(Optional settings As String = "")
        If gTcpMgr.IsConnected(gLircModuleId) = False Then
            Return
        End If

        If settings = "" Then
            settings = Int(mMode).ToString + "-" + mCurTemperature.ToString + "-" + mFanSpeed.ToString + "-" + Int(mSwing).ToString
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ClickOnAC " + settings, GetModuleId(), 1)
        Dim buttonStatus As String = gTcpMgr.GetResponse(tcpParam)
        If (buttonStatus = "Disconnected") Or (buttonStatus = "") Then
            Return
        End If

        Debug.Assert(buttonStatus = "AC button " + settings + " pressed")

        If (settings <> "0") Then
            SetPowerStatus(True)
        End If
    End Sub

    'get setting from rpi
    Public Sub GetSetting()
        If gTcpMgr.IsConnected(GetModuleId()) = False Then
            Exit Sub
        End If

        'get on/off status from the RPI
        Dim tcpParam As TcpParameter = New TcpParameter("GetACSetting", GetModuleId(), 1)

        'thread to get touch sensor pressed status from RPI
        Dim settingTrd As Thread = New Thread(AddressOf GetSettingTrd)
        settingTrd.Start(tcpParam)
    End Sub

    'get setting from rpi
    Private Sub GetSettingTrd(atcpParam As TcpParameter)
        If gTcpMgr.IsConnected(GetModuleId()) = False Then
            Exit Sub
        End If

        Dim data As String = gTcpMgr.GetResponse(atcpParam)
        If (data = "Disconnected") Or (data = "") Or (data = " ") Then
            Return
        End If

        If data = "0" Then
            SetPowerStatus(False)
            Return
        End If

        SetPowerStatus(True)
        If data = "1" Then
            Return
        End If

        ' Split string based on ',' character
        Dim params As String() = data.Split(New Char() {"-"c})
        Debug.Assert(params.Length() = 4)
        Debug.Assert(IsNumeric(params(0)))
        Debug.Assert(IsNumeric(params(1)))
        Debug.Assert(IsNumeric(params(2)))
        Debug.Assert(IsNumeric(params(3)))

        SetACMode(params(0), False)
        SetACTempature(params(1), False)
        SetACFanSpeed(params(2), False)
        SetACSwing(params(3), False)

        mUpdateControls = True
    End Sub

    'set power on/off
    Public Overrides Sub SetPowerOn(Optional powerOn As Boolean = True)
        If gTcpMgr.IsConnected(GetModuleId()) = False Then
            Exit Sub
        End If

        SetPowerStatus(powerOn)

        If GetPowerStatus() = False Then
            Dim tcpParam As TcpParameter = New TcpParameter("ClickOnAC 0", GetModuleId(), 1)
            Dim data As String = gTcpMgr.GetResponse(tcpParam)
            If (data = "Disconnected") Or (data = "") Then
                Return
            End If

            Debug.Assert(data = ("AC button 0 pressed"))
        Else
            SendACSignal()
        End If

        UpdateColor()
    End Sub

    'save temperature settings
    Public Sub SaveTemperatures(temperature As Integer, hr As Integer)
        If mUpdateControls = True Then
            Exit Sub
        End If

        mTemperatures(hr) = temperature

        'create the folder if doesn't exist
        Dim folder As String = My.Application.Info.DirectoryPath + "\AC"
        If My.Computer.FileSystem.DirectoryExists(folder) = False Then
            My.Computer.FileSystem.CreateDirectory(folder)
        End If

        'dump startTime and endTime in settings file
        FileOpen(1, folder + "\settings.ini", OpenMode.Output)

        For idx = 0 To mTemperatures.Length - 1
            Print(1, mTemperatures(idx).ToString + "        : " + idx.ToString + " hr" + Environment.NewLine)
        Next

        FileClose(1)
    End Sub

    'restore temperature settings
    Public Sub RestoreTemperatures()
        Dim file As String = My.Application.Info.DirectoryPath + "\AC" + "\settings.ini"
        If My.Computer.FileSystem.FileExists(file) = False Then
            Return
        End If

        mUpdateControls = True

        FileOpen(1, file, OpenMode.Input)

        For idx = 0 To mTemperatures.Length - 1
            Dim data As String = LineInput(1)
            mTemperatures(idx) = CInt(data.Substring(0, 7))

            Dim temperatureTxt As String = idx.ToString
            If temperatureTxt.Length = 1 Then
                temperatureTxt = "0" + temperatureTxt
            End If

            'get trackbar from its name
            Dim acTempTrackBarText As String = "Temp" + temperatureTxt + "hr"
            Dim obj As Object = homeCtrl.Controls.Find(acTempTrackBarText, True).FirstOrDefault()
            Dim acTrackBar As TrackBar = DirectCast(obj, TrackBar)

            acTrackBar.Value = mTemperatures(idx)

            'get label from its name
            Dim acTempLableText As String = "Temp" + temperatureTxt + "hrLabel"
            obj = homeCtrl.Controls.Find(acTempLableText, True).FirstOrDefault()
            Dim acLabel As Label = DirectCast(obj, Label)

            Dim labelText = (idx Mod 12).ToString
            If idx < 12 Then
                labelText = labelText + " am"
            Else
                labelText = labelText + " pm"
            End If
            labelText = labelText + " : " + Environment.NewLine + mTemperatures(idx).ToString + " ^C"
            acLabel.Text = labelText
        Next

        FileClose(1)

        mUpdateControls = False
    End Sub

    'adjust temperature based on temperature sensor reading
    Public Sub AdjustTemperatures()
        'exit if ac is powered off or
        'temperature Data is not available or
        'ac mode set to fan mode or
        'temperature adjustment is disabled
        If GetPowerStatus() = False Or
           gTcpMgr.IsConnected(gWeatherModuleId) = False Or
           mMode = ACMode.cACFan Or
           homeCtrl.ACAdjustment.Checked = True Then
            Exit Sub
        End If

        Dim curTemp As Double = gTcpMgr.GetTemperature()
        Dim targetTemp As Integer = mTemperatures(DateAndTime.Now.Hour)
        Dim tempDiff As Integer = CInt(curTemp) - targetTemp
        Dim acTempTobeSet As Integer = targetTemp

        If tempDiff > 0 Then
            'temperature offset of -3
            acTempTobeSet -= 3
        ElseIf tempDiff < 0 Then
            'temperature offset of 3
            acTempTobeSet += 3
        Else
            'temperature offset of -1
            acTempTobeSet -= 1
        End If

        If acTempTobeSet < 16 Then
            acTempTobeSet = 16
        ElseIf acTempTobeSet > 30 Then
            acTempTobeSet = 30
        End If

        If acTempTobeSet = mCurTemperature Then
            Exit Sub
        End If

        homeCtrl.ACTemp.Value = acTempTobeSet
    End Sub

End Class
