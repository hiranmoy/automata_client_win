' -*- Visual basic -*-

'*****************************************************************
'
'              Copyright 2017 Hiranmoy Basak
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


Imports WMPLib


Public Class Alarm

    'contains alarm list
    Private mAlarmArr As List(Of Integer)
    'alarm music file
    Private mAlarmMusic As String

    'media player
    Private mMediaPlayer As WindowsMediaPlayer


    Public Sub New()
        mAlarmArr = New List(Of Integer)
        mAlarmMusic = Application.StartupPath
        mMediaPlayer = New WindowsMediaPlayer
    End Sub

    'get alarm music
    Public Function GetAlarmMusic()
        Return mAlarmMusic
    End Function

    'get alarm music
    Public Sub SetAlarmMusic(music As String)
        mAlarmMusic = music
    End Sub

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
        mMediaPlayer.URL = mAlarmMusic
    End Sub

    'kill music
    Public Sub KillMusic()
        mMediaPlayer.close()
    End Sub

    'update alarm lists
    Private Sub UpdateAlarmList()
        homeCtrl.AlarmList.Items.Clear()
        homeCtrl.AlarmList.Items.Add("Alarms set : " + mAlarmArr.Count.ToString)

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
    Public Sub CheckAndTriggerAlarm(prevTimeInMin As Integer, curTimeInMin As Integer)
        If mAlarmArr.Count = 0 Then
            Exit Sub
        End If

        For alarmIdx = 0 To mAlarmArr.Count - 1
            Dim alarmTimeInMin As Integer = mAlarmArr(alarmIdx)

            If alarmTimeInMin >= prevTimeInMin And alarmTimeInMin <= curTimeInMin Then
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

End Class
