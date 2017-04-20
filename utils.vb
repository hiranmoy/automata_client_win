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



Module utils
    'global variables
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'contains pending speech file list
    Private gSpeechArr As List(Of String) = New List(Of String)


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

        'enable speech check
        Print(1, Int(gEnableSpeech).ToString + "      :Enable Speech" + Environment.NewLine)

        'set music file
        Print(1, gAlarm.GetAlarmMusic() + Environment.NewLine)

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
        gAlarm.SetAlarmMusic(LineInput(1))
        homeCtrl.MusicAlarmLabel.Text = My.Computer.FileSystem.GetName(gAlarm.GetAlarmMusic())

        FileClose(1)
    End Sub

End Module
