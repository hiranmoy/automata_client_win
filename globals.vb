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



Module globals

    'alarm class
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public gAlarm As Alarm = New Alarm



    'debug: hashset containing all tcp input keys
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public gTcpKeys As HashSet(Of Integer) = New HashSet(Of Integer)



    'file/folder paths
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'settings file path
    Public gSettingsFile = My.Application.Info.DirectoryPath + "\Settings.ini"

    'surveillance directory path
    Public gSurveillanceDir As String = "\\RPI3\backups\surveillance"

    'debug folder
    Public gDebugFolder As String = My.Application.Info.DirectoryPath + "\Debug"



    'boolean
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'data loading phase
    Public gLoading As Boolean = True

    'light settings mode
    Public gLightSettingsMode As Boolean = False

    'power profile mode
    Public gPowerHistSelectMode As Boolean = False

    'enable speech status
    Public gEnableSpeech As Boolean = False

    'live feed on status
    Public gCameraOn As Boolean = False



    'interger
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'motion activation delay
    Public gMotionActDelay As Integer = 0



    'modules
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'lighting connections 1 rpi tcp stream index
    Public gLightings1ModuleId As Integer = 0

    'ir blaster rpi tcp stream index
    Public gLircModuleId As Integer = 0

    'motion sensor rpi tcp stream index
    Public gMotionSensorModuleId As Integer = 1

    'sense hat rpi tcp stream index
    Public gWeatherModuleId As Integer = 1

    'camera and microphone rpi tcp stream index
    Public gCameraModuleId As Integer = 1

    'lighting connections 2 rpi tcp stream index
    Public gLightings2ModuleId As Integer = 2

    'air quality sensor stream index
    Public gAirQualityModuleId As Integer = 2

    'touch sensor rpi tcp stream index
    Public gTouchSensorModuleId As Integer = 2

    'number of RPIs
    Public gNumModules As Integer = 3



    'tcp client class
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public gTcpMgr As Tcp = New Tcp

End Module
