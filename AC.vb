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


Public Class AC

    'AC mode
    Private mMode As ACMode

    'temperature
    Private mTemperature As Integer

    'Fan speed
    Private mFanSpeed As Integer

    'swing
    Private mSwing As Boolean

    'turbo
    Private mTurbo As Boolean

    'on/off
    Private mPower As Boolean


    Public Sub New()
        mMode = ACMode.cACCool
        mTemperature = 25
        mFanSpeed = 3
        mSwing = False
        mTurbo = False
        mPower = False

        AddHandler homeCtrl.ACTemp.ValueChanged, AddressOf homeCtrl.ACTemp_ValueChanged
        AddHandler homeCtrl.ACFanSpeed.ValueChanged, AddressOf homeCtrl.ACFanSpeed_ValueChanged
    End Sub

    'set AC mode
    Public Sub SetACMode(ByVal aMode As Integer)
        mMode = aMode

        Select Case mMode
            Case ACMode.cACCool
                homeCtrl.ACTemp.Enabled = True
                homeCtrl.ACFanSpeed.Enabled = True
                homeCtrl.ACFanSpeed.Maximum = 4
                homeCtrl.ACTurbo.Enabled = True
            Case ACMode.cACDry
                homeCtrl.ACTemp.Enabled = True
                homeCtrl.ACFanSpeed.Enabled = False
                homeCtrl.ACTurbo.Enabled = False
            Case ACMode.cACFan
                homeCtrl.ACTemp.Enabled = False
                homeCtrl.ACFanSpeed.Enabled = True
                homeCtrl.ACFanSpeed.Maximum = 3
                homeCtrl.ACTurbo.Enabled = False
            Case Else
                Debug.Assert(False)
        End Select

        SendACSignal()
    End Sub

    'set AC temrature
    Public Sub SetACTempature(temp As Integer)
        mTemperature = temp

        SendACSignal()
    End Sub

    'set AC fan speed
    Public Sub SetACFanSpeed(fanSpeed As Integer)
        mFanSpeed = fanSpeed

        SendACSignal()
    End Sub

    'set AC swing
    Public Sub SetACSwing(swing As Boolean)
        mSwing = swing

        SendACSignal()
    End Sub

    'set AC turbo mode
    Public Sub SetACTurbo(turbo As Boolean)
        mTurbo = turbo

        SendACSignal()
    End Sub

    'set power
    Public Sub ToggleACPower()
        mPower = Not mPower

        SendACSignal(Int(mPower).ToString)

        UpdateACOnOffColorAndText()
    End Sub

    'send AC IR signal
    Private Sub SendACSignal(Optional settings As String = "")
        If settings = "" Then
            settings = Int(mMode).ToString + "," + mTemperature.ToString + "," + mFanSpeed.ToString + "," + Int(mSwing).ToString + "," + Int(mTurbo).ToString
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ClickOnAC " + settings, gLircModuleId, 1)
        'Dim buttonStatus As String = gTcpMgr.GetResponse(tcpParam)
        'If (buttonStatus = "Disconnected") Or (buttonStatus = "") Then
        'Return
        'End If
    End Sub

    'Update AC button color
    Private Sub UpdateACOnOffColorAndText()
        If mPower = False Then
            homeCtrl.ACOnOff.BackColor = Color.FromArgb(255, 128, 128)
            homeCtrl.ACOnOff.Text = "Off"
        Else
            homeCtrl.ACOnOff.BackColor = Color.FromArgb(128, 255, 128)
            homeCtrl.ACOnOff.Text = "On"
        End If
    End Sub

End Class
