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


Imports System.Net.Sockets
Imports System.Threading


Public Class Tcp
    'tcp client
    Private mClient(2) As TcpClient

    'tcp connection status
    Private mFetching(2) As Boolean

    'tcp ips
    Private mIPAddress(2) As String

    'tcp fetch pending
    Private mFetchPending(2) As Boolean

    'stores tcp responses
    Private mResposnses As Hashtable

    'weather data
    Private mTemperature As Double
    Private mHumidity As Double
    Private mPressure As Double

    'gas sensor data
    Private mAlcoholReading As Integer
    Private mCOReading As Integer
    Private mSmokeReading As Integer

    'motion detection data
    Private mMotionDetectionStatus As String

    'touch sensor status
    Private mTouchSensorStatus As String

    'motion detection enable status
    Private mEnableMotionDetect As Boolean

    'video disable status
    Private mDisableVideo As Boolean

    'audio disable status
    Private mDisableAudio As Boolean

    'loading motion and camera status after connecting to rpi
    Private mLoadMotionAndCamStatus As Boolean

    'fluorescent light appliance
    Public mFluLight As Appliance

    'plug0 appliance
    Public mPlug0 As Appliance

    'fan appliance
    Public mFan As Appliance

    'balcony light appliance
    Public mBalconyLight As Appliance

    'light bulb appliance
    Public mLightBulb As Appliance

    'plug1 appliance
    Public mPlug1 As Appliance


    Public Sub New()
        'initialize mFetching array
        For idx = 0 To mFetching.Length - 1
            mFetching(idx) = False

            Select Case idx
                Case 0 : mIPAddress(idx) = "rpi2"
                Case 1 : mIPAddress(idx) = "rpi3"
                Case 2 : mIPAddress(idx) = "rpi32"
                Case Else
                    Debug.Assert(False)
            End Select

            mFetchPending(idx) = False
        Next
        mResposnses = New Hashtable()

        'initialize weather data
        mTemperature = 0
        mHumidity = 0
        mPressure = 0

        'gas sensor data
        mAlcoholReading = 0
        mCOReading = 0
        mSmokeReading = 0

        'motion detection data
        mMotionDetectionStatus = ""

        'touch sensor status
        mTouchSensorStatus = "-"

        'motion detection enable status
        mEnableMotionDetect = False

        'video disable status
        mDisableVideo = False

        'audio disable status
        mDisableAudio = False

        'loading motion and camera status after connecting to rpi
        mLoadMotionAndCamStatus = False


        'fluorescent light data
        mFluLight = New Appliance(homeCtrl.FluLight,
                                  Color.White,
                                  Color.DarkGray,
                                  "CheckIfOnFluLight",
                                  "PowerOnFluLight",
                                  "GetFluLightProfile",
                                  40)

        'plug0
        mPlug0 = New Appliance(homeCtrl.Plug0,
                               Color.FromArgb(255, 192, 192),
                               Color.FromArgb(192, 255, 255),
                               "CheckIfOnPlug0",
                               "PowerOnPlug0",
                               "GetPlug0Profile",
                               5)

        'fan
        mFan = New Appliance(homeCtrl.Fan,
                             Color.FromArgb(128, 128, 255),
                             Color.White,
                             "CheckIfOnFan",
                             "PowerOnFan",
                             "GetFanProfile",
                             60)

        'balcony light
        mBalconyLight = New Appliance(homeCtrl.BalconyLight,
                                      Color.FromArgb(255, 255, 192),
                                      Color.FromArgb(224, 224, 224),
                                      "CheckIfOnBalconyLight",
                                      "PowerOnBalconyLight",
                                      "GetBalconyLightProfile",
                                      100)

        'light bulb
        mLightBulb = New Appliance(homeCtrl.LightBulb,
                                   Color.FromArgb(255, 255, 192),
                                   Color.FromArgb(224, 224, 224),
                                   "CheckIfOnBulb0",
                                   "PowerOnBulb0",
                                   "GetBulb0Profile",
                                   100)

        'plug1
        mPlug1 = New Appliance(homeCtrl.Plug1,
                               Color.FromArgb(192, 255, 192),
                               Color.FromArgb(255, 192, 192),
                               "CheckIfOnPlug1",
                               "PowerOnPlug1",
                               "GetPlug1Profile",
                               100)
    End Sub

    'returns temperature
    Public Function GetTemperature()
        Return mTemperature
    End Function

    'returns humidity
    Public Function GetHumidity()
        Return mHumidity
    End Function

    'returns pressure
    Public Function GetPressure()
        Return mPressure
    End Function

    'returns alcohol reading
    Public Function GetAlcoholReading()
        Return mAlcoholReading
    End Function

    'returns CO reading
    Public Function GetCOReading()
        Return mCOReading
    End Function

    'returns smoke reading
    Public Function GetSmokeReading()
        Return mSmokeReading
    End Function

    'returns motion detection status
    Public Function GetMotionDetectionStatus()
        Return mMotionDetectionStatus
    End Function

    'clear motion detection status
    Public Sub ClearMotionDetectionStatus()
        mMotionDetectionStatus = ""
    End Sub

    'returns touch sensor status data
    Public Function GetTouchSensorStatusData()
        Return mTouchSensorStatus
    End Function

    'clear mtouch sensor status data
    Public Sub ClearTouchSensorStatusData()
        mTouchSensorStatus = "-"
    End Sub

    'returns EnableMotionDetect status
    Public Function IsMotionDetectionEnabled()
        Return mEnableMotionDetect
    End Function

    'returns video disable status
    Public Function IsVideoDisabled()
        Return mDisableVideo
    End Function

    'returns audio disable status
    Public Function IsAudioDisabled()
        Return mDisableAudio
    End Function

    'returns if motion can cam checkboxes are waiting to get refreshed
    Public Function IsMotionAndCamStatusPending()
        Dim curStatus As Boolean = mLoadMotionAndCamStatus
        mLoadMotionAndCamStatus = False
        Return curStatus
    End Function

    'returns true if the module is connected
    Public Function IsConnected(streamIdx As Integer)
        Return mFetching(streamIdx)
    End Function

    'dump time when some module(s) are disconnected
    Public Sub DumpDebugInfo()
        Dim moduleList As String = ""

        For streamIndex = 0 To mFetching.Length - 1
            If mFetching(streamIndex) = False Then
                moduleList += streamIndex.ToString + " "
            End If
        Next

        Try
            If moduleList <> "" Then
                FileOpen(1, gDebugFolder + "\TcpStreams.txt", OpenMode.Append)
                Print(1, homeCtrl.RealTime.Text + " : " + moduleList + Environment.NewLine)
                FileClose(1)
            End If
        Catch
        End Try
    End Sub

    'update connect button color and text
    Public Function GetConnectButtonStatus()
        'count the number of connected modules
        Dim numConnected As String = ""
        For idx = 0 To mFetching.Length - 1
            If mFetching(idx) Then
                If numConnected <> "" Then
                    numConnected = numConnected + ", "
                End If
                numConnected = numConnected + idx.ToString
            End If
        Next

        If numConnected = "" Then
            'change connect button text to "Connect"
            Return "Connect"
        Else
            'change connect button text to "Connected"
            Return "Connected (" + numConnected.ToString + ")"
        End If
    End Function

    'connect to all the modules
    Public Sub ConnectModules()
        If homeCtrl.ConnectCheck.Checked = True Then
            For idx = 0 To mFetching.Length - 1
                ConnectModule(idx)
            Next
        Else
            ConnectModule(homeCtrl.StreamIdx.Value)
        End If
    End Sub

    'connect to a module
    Private Sub ConnectModule(idx As Integer)
        If mFetching(idx) = False Then
            Dim tcpParam As TcpParameter = New TcpParameter("Handshake", idx)

            'thread to connect to RPI
            Dim connectionTrd As Thread = New Thread(AddressOf ConnectTcpTrd)
            connectionTrd.Start(tcpParam)
        End If
    End Sub

    'connect to an IP in thread
    Private Sub ConnectTcpTrd(atcpParam As TcpParameter)
        Dim port As String = "10001"
        Dim streamIdx As Integer = atcpParam.GetStreamIdx()

        ' Create a TcpClient.
        ' Note, for this client to work you need to have a TcpServer 
        ' connected to the same address as specified by the server, port combination.
        Try
            mClient(streamIdx) = New TcpClient(mIPAddress(streamIdx), port)
            'MsgBox("Connected")

            Dim handshakeResponse As String = GetResponse(atcpParam)
            If handshakeResponse = "ok" Then
                'connected to rpi
                mFetching(streamIdx) = True
                mFetchPending(streamIdx) = True
            End If
        Catch ex As Exception
            'MsgBox("Not able to connect")
        End Try
    End Sub

    'fetch data if it is pending
    Public Sub FetchDataIfPending()
        For idx = 0 To mFetching.Length - 1
            If mFetchPending(idx) = False Then
                Continue For
            End If

            mFetchPending(idx) = False
            FetchData(idx)
        Next
    End Sub

    'retuns RPI response w.r.t a input string
    Public Function GetResponse(aTcpParam As TcpParameter) As String
        'thread to get response from RPI
        Dim tcpResponseTrd As Thread = New Thread(AddressOf GetResponseFromRPI)
        tcpResponseTrd.Start(aTcpParam)

        'wait 30 sec for the thread to finish
        'disconnect if no response received
        Dim timeInSec As Integer = 0
        While aTcpParam.GetResponse() = ""
            timeInSec += 1
            If timeInSec >= 10000 Then
                tcpResponseTrd.Abort()

                'dump debug info when disconnected
                FileOpen(1, gDebugFolder + "\DisconnectStatus" + aTcpParam.GetStreamIdx().ToString + ".txt", OpenMode.Append)
                Print(1, "Disconnected due to 10s timeout: " + aTcpParam.GetDataStr() + " (" + aTcpParam.GetStreamIdx().ToString + ")" + Environment.NewLine)
                FileClose(1)

                Return Disconnect(aTcpParam.GetStreamIdx())
                Exit While
            End If

            Thread.Sleep(1)
        End While

        Return aTcpParam.GetResponse()
    End Function

    'This function updates the global variable and is run on thread.
    Private Sub GetResponseFromRPI(aTcpParam As TcpParameter)
        Dim streamIdx As Integer = aTcpParam.GetStreamIdx()

        Dim stream As NetworkStream
        Try
            ' Get a client stream for reading and writing.
            stream = mClient(streamIdx).GetStream()
        Catch ex As Exception
            'dump debug info when disconnected
            FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
            Print(1, "Disconnected for not getting the stream : " + aTcpParam.GetDataStr() + " (" + streamIdx.ToString + ")" + Environment.NewLine)
            FileClose(1)

            aTcpParam.SetResponse(Disconnect(streamIdx))
            Return
        End Try

        ' Translate the passed message into ASCII and store it as a Byte array.
        Dim data As [Byte]() = Text.Encoding.ASCII.GetBytes(aTcpParam.GetTcpDataStr())

        Try
            ' Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length)
        Catch ex As Exception
            'dump debug info when disconnected
            FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
            Print(1, "Disconnected for not able to write in stream : " + aTcpParam.GetDataStr() + " (" + streamIdx.ToString + ")" + Environment.NewLine)
            FileClose(1)

            aTcpParam.SetResponse(Disconnect(streamIdx))
            Return
        End Try

        ' Receive the TcpServer.response.
        ' Buffer to store the response bytes.
        data = New [Byte](1024) {}

        ' String to store the response ASCII representation.
        Dim responseData As String = [String].Empty

        Try
            ' Read the first batch of the TcpServer response bytes.
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = Text.Encoding.ASCII.GetString(data, 0, bytes)
        Catch ex As Exception
            'dump debug info when disconnected
            FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
            Print(1, "Disconnected for not read from stream : " + aTcpParam.GetDataStr() + " (" + streamIdx.ToString + ")" + Environment.NewLine)
            FileClose(1)

            aTcpParam.SetResponse(Disconnect(streamIdx))
            Return
        End Try

        While responseData <> ""
            ' Split string based on '#' character
            Dim params As String() = responseData.Split(New Char() {"#"c})
            Debug.Assert(params.Length() = 2)
            Debug.Assert(IsNumeric(params(0)))
            Dim responseKey As Integer = CInt(params(0))

            Debug.Assert(mResposnses.Contains(responseKey) = False)
            mResposnses.Add(responseKey, params(1))

            'response key might not be same as original message key
            'wait till message with the original key is received
            While mResposnses.Contains(aTcpParam.GetKey() = False)
                Thread.Sleep(1)
            End While

            aTcpParam.SetResponse(mResposnses.Item(aTcpParam.GetKey()))
            mResposnses.Remove(aTcpParam.GetKey())
            Exit While
        End While
    End Sub

    'sets to disconnected mode
    Private Function Disconnect(aStreamIdx As Integer) As String
        mFetching(aStreamIdx) = False
        Try
            mClient(aStreamIdx).Close()
        Catch
        End Try

        'MsgBox("Connection broken")
        Return "Disconnected"
    End Function

    'fetches data from RPI
    Public Sub FetchDataFromAll()
        If homeCtrl.ConnectCheck.Checked = True Then
            For idx = 0 To mFetching.Length - 1
                FetchData(idx)
            Next
        Else
            FetchData(homeCtrl.StreamIdx.Value)
        End If
    End Sub

    'fetches data from RPI
    Private Sub FetchData(idx As Integer)
        If mFetching(idx) = False Then
            Return
        End If

        gLoading = True

        Select Case idx
            Case 0
                GetLightingSettings()
            Case 1
                MotionAndCameraSettings()
                GetMonitorStatus()
                GetWeatherInfo()
            Case 2
                GetAirQualityInfo()
            Case Else
                Debug.Assert(False)
        End Select

        gLoading = False
    End Sub

    'gets weather info
    Public Sub GetWeatherInfo()
        If mFetching(gWeatherModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("Weather", gWeatherModuleId)

        'thread to get weather data from RPI
        Dim weatherDataTrd As Thread = New Thread(AddressOf GetWeatherInfoTrd)
        weatherDataTrd.Start(tcpParam)
    End Sub

    'gets weather info from RPI
    Private Sub GetWeatherInfoTrd(atcpParam As TcpParameter)
        If mFetching(gWeatherModuleId) = False Then
            Exit Sub
        End If

        Dim weather As String = GetResponse(atcpParam)
        If (weather = "Disconnected") Or (weather = "") Then
            Return
        End If

        ' Split string based on ',' character
        Dim params As String() = weather.Split(New Char() {","c})
        Debug.Assert(params.Length() = 3)
        Debug.Assert(IsNumeric(params(0)))
        Debug.Assert(IsNumeric(params(1)))
        Debug.Assert(IsNumeric(params(2)))

        mTemperature = CDbl(params(0))
        mHumidity = CDbl(params(1))
        mPressure = CDbl(params(2))
    End Sub

    'gets air quality info
    Public Sub GetAirQualityInfo()
        If mFetching(gAirQualityModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("AirQuality", gAirQualityModuleId)

        'thread to get weather data from RPI
        Dim aitQualityTrd As Thread = New Thread(AddressOf GetAirQualityInfoTrd)
        aitQualityTrd.Start(tcpParam)
    End Sub

    'gets air quality info in thread
    Private Sub GetAirQualityInfoTrd(atcpParam As TcpParameter)
        If mFetching(gAirQualityModuleId) = False Then
            Exit Sub
        End If

        Dim airQuality As String = GetResponse(atcpParam)
        If (airQuality = "Disconnected") Or (airQuality = "") Then
            Return
        End If

        ' Split string based on ',' character
        Dim params As String() = airQuality.Split(New Char() {","c})
        Debug.Assert(params.Length() = 3)
        Debug.Assert(IsNumeric(params(0)))
        Debug.Assert(IsNumeric(params(1)))
        Debug.Assert(IsNumeric(params(2)))

        mAlcoholReading = CInt(params(0))
        mCOReading = CInt(params(1))
        mSmokeReading = CInt(params(2))
    End Sub

    'gets motion detection status
    Public Sub GetMonitorStatus()
        If mFetching(gMotionSensorModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ExtractMonitorStatus", gMotionSensorModuleId)

        'thread to get motion detection status from RPI
        Dim motionDetectTrd As Thread = New Thread(AddressOf GetMonitorStatusTrd)
        motionDetectTrd.Start(tcpParam)
    End Sub

    'gets motion detection status
    Private Sub GetMonitorStatusTrd(atcpParam As TcpParameter)
        If mFetching(gMotionSensorModuleId) = False Then
            Exit Sub
        End If


        Dim monitorStatus As String = GetResponse(atcpParam)
        If (monitorStatus = "Disconnected") Or (monitorStatus = "") Then
            Return
        End If

        Select Case monitorStatus
            Case "-"
                'no motion detected
                Return
            Case Else
                'motion detection time
                mMotionDetectionStatus = "Motion detected at " + monitorStatus + Environment.NewLine
        End Select
    End Sub

    'gets touch sensor status
    Public Sub GetTouchSensorStatus()
        If mFetching(gTouchSensorModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ExtractTouchSensorStatus", gTouchSensorModuleId)

        'thread to get touch sensor pressed status from RPI
        Dim touchSensorTrd As Thread = New Thread(AddressOf GetTouchSensorStatusTrd)
        touchSensorTrd.Start(tcpParam)
    End Sub

    'gets touch sensor status
    Private Sub GetTouchSensorStatusTrd(atcpParam As TcpParameter)
        If mFetching(gTouchSensorModuleId) = False Then
            Exit Sub
        End If

        Dim touchSensorStatus As String = GetResponse(atcpParam)
        If (touchSensorStatus = "Disconnected") Or (touchSensorStatus = "") Then
            Return
        End If

        Debug.Assert(touchSensorStatus <> "")
        mTouchSensorStatus = touchSensorStatus
    End Sub

    'check whether tcp connection is maintained
    Public Sub CheckConnectionStatus()
        For idx = 0 To mFetching.Length - 1
            If mFetching(idx) = False Then
                Continue For
            End If

            Dim tcpParam As TcpParameter = New TcpParameter("IsConnected", idx)

            'thread to get touch sensor pressed status from RPI
            Dim connectionCheckTrd As Thread = New Thread(AddressOf CheckConnectionStatusTrd)
            connectionCheckTrd.Start(tcpParam)
        Next
    End Sub

    'check whether tcp connection is maintained
    Private Sub CheckConnectionStatusTrd(atcpParam As TcpParameter)
        If mFetching(atcpParam.GetStreamIdx()) = False Then
            Return
        End If

        Dim connectionStatus As String = GetResponse(atcpParam)

        If (connectionStatus = "Disconnected") Or (connectionStatus = "") Then
            Return
        End If

        Debug.Assert(connectionStatus = "connected")
    End Sub

    'gets motion and camera settings
    Public Sub MotionAndCameraSettings()
        If (mFetching(gMotionSensorModuleId) = False) Or (mFetching(gCameraModuleId) = False) Then
            Exit Sub
        End If

        Dim tcpParam1 As TcpParameter = New TcpParameter("GetIsEnableMotionDetect", gMotionSensorModuleId)
        Dim tcpParam2 As TcpParameter = New TcpParameter("GetIsDisableVideo", gCameraModuleId)
        Dim tcpParam3 As TcpParameter = New TcpParameter("GetIsDisableAudio", gCameraModuleId)

        Dim tcpParamArr(2) As TcpParameter
        tcpParamArr(0) = tcpParam1
        tcpParamArr(1) = tcpParam2
        tcpParamArr(2) = tcpParam3

        'thread to get touch sensor pressed status from RPI
        Dim motionCamSettingsTrd As Thread = New Thread(AddressOf MotionAndCameraSettingsInTrd)
        motionCamSettingsTrd.Start(tcpParamArr)
    End Sub

    'gets motion and camera settings using thread
    Private Sub MotionAndCameraSettingsInTrd(aTcpParamArr() As TcpParameter)
        If (mFetching(gMotionSensorModuleId) = False) Or (mFetching(gCameraModuleId) = False) Then
            Exit Sub
        End If

        'motion detection enabled data
        Dim data As String = GetResponse(aTcpParamArr(0))
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If
        mEnableMotionDetect = CBool(Int(data))

        'enabled video data
        data = GetResponse(aTcpParamArr(1))
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If
        mDisableVideo = CBool(Int(data))

        'enabled audio data
        data = GetResponse(aTcpParamArr(2))
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If
        mDisableAudio = CBool(Int(data))

        mLoadMotionAndCamStatus = True
    End Sub

    'gets light settings data
    Public Sub GetLightingSettings()
        If mFetching(gLightings1ModuleId) = False Then
            Exit Sub
        End If

        mFluLight.CheckPowerOnStatus()
        mPlug0.CheckPowerOnStatus()
        mFan.CheckPowerOnStatus()
        mBalconyLight.CheckPowerOnStatus()
        mPlug1.CheckPowerOnStatus()
        mLightBulb.CheckPowerOnStatus()
    End Sub

    'toggles LED light
    Public Sub ToggleLEDLight()
        If mFetching(gLightings2ModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ToggleLED", gLightings2ModuleId)
        GetResponse(tcpParam)
    End Sub

    'enables/disables motion detection
    Public Function EnableMotionDetect(en As Integer) As Boolean
        If mFetching(gMotionSensorModuleId) = False Then
            Return False
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("EnableMotionDetect" + Str(en), gMotionSensorModuleId)
        Dim enableMotionDetectFlag As String = GetResponse(tcpParam)

        If (enableMotionDetectFlag = "Disconnected") Or (enableMotionDetectFlag = "") Then
            Return False
        End If
        Debug.Assert((Int(enableMotionDetectFlag) = 0) Or (Int(enableMotionDetectFlag) = 1))

        mEnableMotionDetect = CBool(en)
        Return CBool(Int(enableMotionDetectFlag))
    End Function

    'enables/disables video recording on motion detection
    Public Function DisableVideo(en As Integer) As Boolean
        If mFetching(gCameraModuleId) = False Then
            Return False
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("DisableVideo" + Str(en), gCameraModuleId)
        Dim disableVideoFlag As String = GetResponse(tcpParam)

        If (disableVideoFlag = "Disconnected") Or (disableVideoFlag = "") Then
            Return False
        End If
        Debug.Assert((Int(disableVideoFlag) = 0) Or (Int(disableVideoFlag) = 1))

        mDisableVideo = CBool(en)
        Return CBool(Int(disableVideoFlag))
    End Function

    'enables/disables audio recording on motion detection
    Public Function DisableAudio(en As Integer) As Boolean
        If mFetching(gCameraModuleId) = False Then
            Return False
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("DisableAudio" + Str(en), gCameraModuleId)
        Dim disableAudioFlag As String = GetResponse(tcpParam)

        If (disableAudioFlag = "Disconnected") Or (disableAudioFlag = "") Then
            Return False
        End If
        Debug.Assert((Int(disableAudioFlag) = 0) Or (Int(disableAudioFlag) = 1))

        mDisableAudio = CBool(en)
        Return CBool(Int(disableAudioFlag))
    End Function

End Class