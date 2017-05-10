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
    Private mTemperature As Integer

    'Fan speed
    Private mFanSpeed As Integer

    'swing
    Private mSwing As Boolean

    'update controls
    Private mUpdateControls As Boolean


    Public Sub New(aButton As Button,
                   aRadioButton As RadioButton,
                   onColor As Color,
                   offColor As Color,
                   moduleId As Integer,
                   power As Integer)
        MyBase.New(aButton, aRadioButton, onColor, offColor, "", "", "", moduleId, power)

        mMode = ACMode.cACCool
        mTemperature = 25
        mFanSpeed = 3
        mSwing = False

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

        mTemperature = temp

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

        homeCtrl.ACTemp.Value = mTemperature
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
            settings = Int(mMode).ToString + "-" + mTemperature.ToString + "-" + mFanSpeed.ToString + "-" + Int(mSwing).ToString
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

End Class
