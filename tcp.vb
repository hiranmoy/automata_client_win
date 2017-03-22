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

    'response thread
    Private mTcpResponsesTrds(2) As Thread

    'weather data
    Private mTemperature As Double
    Private mHumidity As Double
    Private mPressure As Double

    'gas sensor data
    Private mAlcoholReading As Integer
    Private mCOReading As Integer
    Private mSmokeReading As Integer

    'number of points in a graph
    Public mNumPointsInGraph As Integer

    'climate data
    Private mClimate(2, 0) As Double

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

            'thread to get response from RPI
            mTcpResponsesTrds(idx) = New Thread(AddressOf GetTcpResponseToRPI)
            mTcpResponsesTrds(idx).Start(idx)
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

        'initilize number of points
        mNumPointsInGraph = 480

        'initilize climate data
        '0: temperature
        '1: humidity
        '2: air pressure
        ReDim mClimate(2, mNumPointsInGraph - 1)
        For idx = 0 To 2
            For minIdx = 0 To mNumPointsInGraph - 1
                mClimate(idx, minIdx) = 0
            Next
        Next

        'motion detection data
        mMotionDetectionStatus = ""

        'touch sensor status
        mTouchSensorStatus = ""

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

    'kill all tcp response threads
    Public Sub KillTcpReponseThreads()
        For idx = 0 To mTcpResponsesTrds.Length() - 1
            Try
                mClient(idx).Close()
            Catch
            End Try

            mTcpResponsesTrds(idx).Abort()
        Next
    End Sub

    'returns temperature
    Public Function GetTemperature()
        Return mTemperature
    End Function

    'returns temperature at a particular minute
    Public Function GetClimateReading(idx As Integer, min As Integer)
        Return mClimate(idx, min)
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

    'clear touch detection status
    Public Sub ClearTouchDetectionStatus()
        mTouchSensorStatus = ""
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
        Dim fetchingEnabledOnly As Integer = -1
        If homeCtrl.ConnectCheck.Checked = False Then
            fetchingEnabledOnly = homeCtrl.StreamIdx.Value
        End If

        Dim moduleList As String = ""

        For streamIndex = 0 To mFetching.Length - 1
            If (fetchingEnabledOnly <> -1) And (fetchingEnabledOnly <> streamIndex) Then
                Continue For
            End If

            If mFetching(streamIndex) = False Then
                moduleList += streamIndex.ToString + " "
            End If
        Next

        If moduleList <> "" Then
            Try
                FileOpen(1, gDebugFolder + "\TcpStreams.txt", OpenMode.Append)
                Print(1, homeCtrl.RealTime.Text + " : " + moduleList + Environment.NewLine)
                FileClose(1)
            Catch
            End Try
        End If
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
        'add current tcp parameter in the response pending list
        mResposnses.Add(aTcpParam.GetKey(), aTcpParam)

        Dim numPackets As Integer = aTcpParam.GetNumPackets()

        'thread to get response from RPI
        Dim tcpResponseTrd As Thread = New Thread(AddressOf SetTcpCommandToRPI)
        tcpResponseTrd.Start(aTcpParam)

        'wait 30 sec for the thread to finish
        'disconnect if no response received
        Dim timeInSec As Integer = 0
        While aTcpParam.GetResponse(numPackets - 1) = ""
            '(aTcpParam.GetResponse(aTcpParam.GetNumPackets() - 1) = "")
            timeInSec += 1
            If timeInSec >= 10000 Then
                tcpResponseTrd.Abort()

                If numPackets > 1 Then
                    'don't disconnect in case of multi-packet tcp parameter
                    Return "done"
                End If

                'dump debug info when disconnected
                Try
                    FileOpen(1, gDebugFolder + "\DisconnectStatus" + aTcpParam.GetStreamIdx().ToString + ".txt", OpenMode.Append)
                    Print(1, "Disconnected due to 10s timeout: " + aTcpParam.GetDataStr() + " (" + aTcpParam.GetStreamIdx().ToString + ")" + Environment.NewLine)
                    FileClose(1)
                Catch
                End Try

                Return Disconnect(aTcpParam.GetStreamIdx())
                Exit While
            End If

            Thread.Sleep(1)
        End While

        If numPackets = 1 Then
            Debug.Assert(aTcpParam.GetResponse() <> "")
            Return aTcpParam.GetResponse()
        Else
            Return "done"
        End If
    End Function

    'send tcp command to rpi
    Private Sub SetTcpCommandToRPI(aTcpParam As TcpParameter)
        Dim streamIdx As Integer = aTcpParam.GetStreamIdx()

        Dim stream As NetworkStream
        Try
            ' Get a client stream for reading and writing.
            stream = mClient(streamIdx).GetStream()
        Catch ex As Exception
            'dump debug info when disconnected
            Try
                FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
                Print(1, "Disconnected for not getting the stream : " + aTcpParam.GetDataStr() + " (" + streamIdx.ToString + ")" + Environment.NewLine)
                FileClose(1)
            Catch
            End Try
            Return
        End Try

        ' Translate the passed message into ASCII and store it as a Byte array.
        Dim data As [Byte]() = Text.Encoding.ASCII.GetBytes(aTcpParam.GetTcpDataStr())

        Try
            ' Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length)
        Catch ex As Exception
            'dump debug info when disconnected
            Try
                FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
                Print(1, "Disconnected for not being able to write in stream : " + aTcpParam.GetDataStr() + " (" + streamIdx.ToString + ")" + Environment.NewLine)
                FileClose(1)
            Catch
            End Try
            Return
        End Try
    End Sub

    'get tcp responses from rpi
    Private Sub GetTcpResponseToRPI(streamIdx As Integer)
        While (1)
            If mFetching(streamIdx) = False Then
                Thread.Sleep(1000)
            End If

            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            Dim data As [Byte]() = New [Byte](64) {}

            ' String to store the response ASCII representation.
            Dim origResponseData As String = [String].Empty

            Dim stream As NetworkStream
            Try
                ' Get a client stream for reading and writing.
                stream = mClient(streamIdx).GetStream()
            Catch ex As Exception
                If mFetching(streamIdx) Then
                    'dump debug info when disconnected
                    Try
                        FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
                        Print(1, "Disconnected for not getting the stream (" + streamIdx.ToString + ")" + Environment.NewLine)
                        FileClose(1)
                    Catch
                    End Try
                    Continue While
                End If
            End Try

            Try
                ' Read the first batch of the TcpServer response bytes.
                Dim bytes As Int32 = stream.Read(data, 0, data.Length)
                origResponseData = Text.Encoding.ASCII.GetString(data, 0, bytes)
            Catch ex As Exception
                If mFetching(streamIdx) Then
                    'dump debug info when disconnected
                    Try
                        FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
                        Print(1, "Disconnected for not being able to read from stream : (" + streamIdx.ToString + ")" + Environment.NewLine)
                        FileClose(1)
                    Catch
                    End Try
                    Continue While
                End If
            End Try

            If origResponseData = "" Then
                Continue While
            End If

            'response with broken packets removed
            Dim responseData As String = origResponseData

            'response from RPI : <broken packet><complete packet><complete packet> ... <complete packet><broken packet>
            'complete packet type 1 : #<key>=<data>~
            'complete packet type 2 : #<key>=<packetIdx>|<data>~
            'Hence, broken packets need to be removed before parsing the complete packets

            Dim firstHashCharPos As Integer = responseData.IndexOf("#", 0)
            If firstHashCharPos = -1 Then
                Continue While
            End If
            'remove incorrect characters before first '#'
            responseData = responseData.Substring(firstHashCharPos)
            If responseData = "" Then
                Continue While
            End If

            Dim lastTildaCharPos As Integer = responseData.LastIndexOf("~")
            If lastTildaCharPos = -1 Then
                Continue While
            End If
            'remove incorrect characters after last '~'
            responseData = responseData.Substring(0, lastTildaCharPos + 1)
            If responseData = "" Then
                Continue While
            End If

            ' Split string based on '#' character
            Dim params As String() = responseData.Split(New Char() {"#"c})
            Debug.Assert(params.Length() >= 2)

            'first element is empty
            Debug.Assert(params(0) = "")

            For paramIdx = 1 To params.Length() - 1
                ' Split string based on '=' character
                Dim packetParams As String() = params(paramIdx).Split(New Char() {"="c})
                Debug.Assert(packetParams.Length() = 2)

                'tcp response
                Dim response As String = packetParams(1)
                Debug.Assert(response(response.Length - 1) = "~")
                response = response.Substring(0, response.Length - 1)
                If response = "Unknown command" Then
                    Try
                        FileOpen(1, gDebugFolder + "\DisconnectStatus" + streamIdx.ToString + ".txt", OpenMode.Append)
                        Print(1, "Received 'Unknown command' from stream : (" + streamIdx.ToString + ")" + Environment.NewLine)
                        FileClose(1)
                    Catch
                    End Try
                    Continue While
                End If

                'tcp key
                Debug.Assert(IsNumeric(packetParams(0)))
                Dim responseKey As Integer = CInt(packetParams(0))

                If responseKey < 0 Then
                    'interrupt from sensors like motion, touch etc.

                    Select Case responseKey
                        Case -1
                            'motion sensor
                            SetMonitorStatus(response)
                        Case -2
                            'touch sensor
                            SetTouchSensorStatus(response)
                        Case Else
                            Debug.Assert(False)
                    End Select

                    Continue For
                End If

                Debug.Assert(mResposnses.Contains(responseKey))

                Dim tcpParam As TcpParameter = mResposnses.Item(responseKey)
                Dim packetId As Integer = 0

                ' Split string based on '|' character
                Dim subparams As String() = response.Split(New Char() {"|"c})
                Debug.Assert(subparams.Length() <= 2)

                If subparams.Length() = 2 Then
                    'tcp packet index
                    Debug.Assert(IsNumeric(subparams(0)))
                    packetId = CInt(subparams(0))
                    response = subparams(1)
                End If

                tcpParam.SetResponse(response, packetId)
                If tcpParam.IsAllPacketsReceived() = True Then
                    mResposnses.Remove(responseKey)
                End If
            Next
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
                GetWeatherInfo()
                ClimateData()
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

    'set motion detection status
    Private Sub SetMonitorStatus(monitorStatus As String)
        Debug.Assert(monitorStatus <> "")

        'motion detection time
        mMotionDetectionStatus = "Motion detected at " + monitorStatus + Environment.NewLine
    End Sub

    'gets touch sensor status
    Private Sub SetTouchSensorStatus(touchSensorStatus As String)
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

    'get climate data
    Public Sub ClimateData()
        If mFetching(gWeatherModuleId) Then
            Dim tcpParam1 As TcpParameter = New TcpParameter("GetTemperatureProfile", gWeatherModuleId, mNumPointsInGraph)
            Dim tcpParam2 As TcpParameter = New TcpParameter("GetHumidityProfile", gWeatherModuleId, mNumPointsInGraph)
            Dim tcpParam3 As TcpParameter = New TcpParameter("GetPressureProfile", gWeatherModuleId, mNumPointsInGraph)

            Dim tcpParamArr(2) As TcpParameter
            tcpParamArr(0) = tcpParam1
            tcpParamArr(1) = tcpParam2
            tcpParamArr(2) = tcpParam3

            'thread to get climate from RPI
            Dim temperatureProfileTrd As Thread = New Thread(AddressOf ClimateDataTrd)
            temperatureProfileTrd.Start(tcpParamArr)
        End If
    End Sub

    'get climate data in thread
    Private Sub ClimateDataTrd(aTcpParamArr() As TcpParameter)
        If mFetching(gWeatherModuleId) = False Then
            Return
        End If

        'wait for 10 sec so that important and small data can be captured properly
        Thread.Sleep(10000)

        For idx = 0 To 2
            gTcpMgr.GetResponse(aTcpParamArr(idx))

            For minIdx = 0 To aTcpParamArr(idx).GetNumPackets() - 1
                If aTcpParamArr(idx).GetResponse(minIdx) = "" Then
                    Continue For
                End If

                Debug.Assert(IsNumeric(aTcpParamArr(idx).GetResponse(minIdx)))
                mClimate(idx, minIdx) = CDbl(aTcpParamArr(idx).GetResponse(minIdx))
            Next
        Next
    End Sub

    'show chart data
    Public Sub ShowClimateData()
        If mFetching(gWeatherModuleId) = False Then
            Return
        End If

        homeCtrl.TemperatureData.Series("Temperature (^C)").Points.Clear()
        homeCtrl.HumidityData.Series("Humidity").Points.Clear()
        homeCtrl.PressureData.Series("Air Pressure (Pa)").Points.Clear()

        For idx = 0 To 2
            Dim minVal As Double = 1000000
            Dim maxVal As Double = -1
            For minIdx = 0 To mNumPointsInGraph - 1
                Dim origVal As Double = GetClimateReading(idx, minIdx)

                If origVal = 0 Then
                    Continue For
                End If

                'apply moving average filter of order 5
                Dim avgVal As Double = 0
                Dim div As Integer = 0

                For filterIdx = Math.Max(0, minIdx - 2) To Math.Min(minIdx + 2, mNumPointsInGraph - 1)
                    If GetClimateReading(idx, filterIdx) = 0 Then
                        Continue For
                    End If

                    avgVal += GetClimateReading(idx, filterIdx)
                    div += 1
                Next

                avgVal /= div
                Debug.Assert(avgVal > 0)

                Dim hr As Double = minIdx * (1440 / mNumPointsInGraph) / 60

                'add points in the graph
                Select Case idx
                    Case 0 : homeCtrl.TemperatureData.Series("Temperature (^C)").Points.AddXY(hr, avgVal)
                    Case 1 : homeCtrl.HumidityData.Series("Humidity").Points.AddXY(hr, avgVal)
                    Case 2 : homeCtrl.PressureData.Series("Air Pressure (Pa)").Points.AddXY(hr, avgVal)
                    Case Else
                End Select

                'set minimum value
                If minVal > avgVal Then
                    minVal = avgVal
                End If

                'set maximum value
                If maxVal < avgVal Then
                    maxVal = avgVal
                End If
            Next

            If maxVal = minVal Then
                maxVal += 1
            End If
            Dim chartMin As Integer = Int(minVal)
            Dim chartMax As Integer = Int(maxVal + 0.99)

            'y-axis: interval = (max - min)/5
            Select Case idx
                Case 0
                    homeCtrl.TemperatureData.ChartAreas.Min.AxisY.Minimum = chartMin
                    homeCtrl.TemperatureData.ChartAreas.Min.AxisY.Maximum = chartMax
                    homeCtrl.TemperatureData.ChartAreas.Min.AxisY.Interval = (chartMax - chartMin) / 5
                Case 1
                    homeCtrl.HumidityData.ChartAreas.Min.AxisY.Minimum = chartMin
                    homeCtrl.HumidityData.ChartAreas.Min.AxisY.Maximum = chartMax
                    homeCtrl.HumidityData.ChartAreas.Min.AxisY.Interval = (chartMax - chartMin) / 5
                Case 2
                    homeCtrl.PressureData.ChartAreas.Min.AxisY.Minimum = chartMin
                    homeCtrl.PressureData.ChartAreas.Min.AxisY.Maximum = chartMax
                    homeCtrl.PressureData.ChartAreas.Min.AxisY.Interval = (chartMax - chartMin) / 5
                Case Else
            End Select
        Next
    End Sub

End Class