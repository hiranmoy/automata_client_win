Imports System.Net.Sockets
Imports System.Threading

Module tcp
    'global variables
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'tcp response
    Private gResponse As String = ""



    'retuns RPI response w.r.t a input string
    Public Function GetResponse(aTcpParam As TcpParameter) As String
        'Debug.Assert(gFetching = True)

        'start the thread monitoring timer
        homeCtrl.TcpTimer.Start()

        'create thread
        gTcpResponseTrd = New Thread(AddressOf GetResponseFromRPI)
        gTcpResponseTrd.Start(aTcpParam)

        'wait for the thread to finish
        While gTcpResponseTrd.IsAlive = True
            Thread.Sleep(1)
        End While

        'stop the thread monitoring timer
        homeCtrl.TcpTimer.Stop()

        'disconnect if response not received within 10 sec
        If gResponse = "" Then
            gResponse = ""
            Return Disconnect(aTcpParam.GetStreamIdx())
        End If

        'reinitilize gResponse
        Dim response As String = gResponse
        gResponse = ""
        Return response
    End Function

    'This function updates the global variable and is run on thread.
    Private Sub GetResponseFromRPI(aTcpParam As TcpParameter)
        ' String to store the response ASCII representation.
        Dim responseData As String = [String].Empty

        Dim stream As NetworkStream
        Try
            ' Get a client stream for reading and writing.
            stream = gClient(aTcpParam.GetStreamIdx()).GetStream()
        Catch ex As Exception
            gResponse = Disconnect(aTcpParam.GetStreamIdx())
            Return
        End Try

        ' Translate the passed message into ASCII and store it as a Byte array.
        Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(aTcpParam.GetDataStr())

        Try
            ' Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length)
        Catch ex As Exception
            gResponse = Disconnect(aTcpParam.GetStreamIdx())
            Return
        End Try

        ' Receive the TcpServer.response.
        ' Buffer to store the response bytes.
        data = New [Byte](1024) {}

        Try
            ' Read the first batch of the TcpServer response bytes.
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
        Catch ex As Exception
            gResponse = Disconnect(aTcpParam.GetStreamIdx())
            Return
        End Try

        gResponse = responseData
    End Sub

    'sets to disconnected mode
    Private Function Disconnect(aStreamIdx As Integer) As String
        gFetching(aStreamIdx) = False

        homeCtrl.EnableAllWidgets()

        'MsgBox("Connection broken")

        Return "Disconnected"
    End Function

    'connect to an IP
    Public Function ConnectIP(ip As String, streamIdx As Integer) As Boolean
        Dim port As String = "10001"

        ' Create a TcpClient.
        ' Note, for this client to work you need to have a TcpServer 
        ' connected to the same address as specified by the server, port combination.
        Try
            gClient(streamIdx) = New TcpClient(ip, port)
            'MsgBox("Connected")

            Dim tcpParam As TcpParameter = New TcpParameter("Handshake", streamIdx)
            Dim handshakeResponse As String = GetResponse(tcpParam)
            If handshakeResponse = "ok" Then
                Return True
            End If
        Catch ex As Exception
            'MsgBox("Not able to connect")
        End Try

        Return False
    End Function

    'connect to a module
    Public Sub ConnectModule(idx As Integer)

        If gFetching(idx) = False Then
            Dim connected As Boolean = False

            Dim host As String = "-1"

            Select Case idx
                Case 0
                    'read rpi2 ip
                    host = GetIPFromFile("\\RPI2\backups\ip.txt")
                Case 1
                    'read rpi3 ip
                    host = GetIPFromFile("\\RPI3\backups\ip.txt")
                Case 2
                    'read rpi32 ip
                    host = GetIPFromFile("\\RPI32\backups\ip.txt")
                Case Else
                    Debug.Assert(False)
            End Select
            'MsgBox(host)

            If host <> "-1" Then
                If ConnectIP(host, idx) = True Then
                    connected = True
                End If

                If connected = True Then
                    'connected to rpi
                    gFetching(idx) = True

                    homeCtrl.EnableAllWidgets()
                    FetchData(idx)
                End If
            End If
        End If

    End Sub

    'fetches all data from RPI
    Public Sub FetchData(idx As Integer)
        gLoading = True

        If idx = 0 Then
            If gFetching(0) = True Then
                GetLightingSettings()
            End If
        End If

        If idx = 1 Then
            If gFetching(1) = True Then
                MotionAndCameraSettings()
                GetMonitorStatus()
                GetWeatherInfo()
            End If
        End If

        If idx = 2 Then
            If gFetching(2) = True Then
                GetAirQualityInfo()
            End If
        End If

        gLoading = False
    End Sub

    'gets weather info
    Public Sub GetWeatherInfo()
        If gFetching(gWeatherModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("Weather", gWeatherModuleId)
        Dim weather As String = GetResponse(tcpParam)
        If (weather = "Disconnected") Or (weather = "") Then
            Return
        End If

        ' Split string based on ',' character
        Dim params As String() = weather.Split(New Char() {","c})
        Debug.Assert(params.Length() = 3)

        homeCtrl.Temperature.Text = "Temperature : " + params(0) + " ^C"
        homeCtrl.Humidity.Text = "Humidity : " + params(1)
        homeCtrl.Pressure.Text = "Atmospheric Pressure : " + params(2) + " Pa"

        'Graphics
        Debug.Assert(IsNumeric(params(0)))
        UpdateTemperatureColor(params(0))
        Debug.Assert(IsNumeric(params(1)))
        UpdateHumidityColor(params(1))
        Debug.Assert(IsNumeric(params(2)))
        UpdatePressureColor(params(2))
    End Sub

    'gets weather info
    Public Sub GetAirQualityInfo()
        If gFetching(gAirQualityModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("AirQuality", gAirQualityModuleId)
        Dim airQuality As String = GetResponse(tcpParam)
        If (airQuality = "Disconnected") Or (airQuality = "") Then
            Return
        End If

        ' Split string based on ',' character
        Dim params As String() = airQuality.Split(New Char() {","c})
        Debug.Assert(params.Length() = 2)

        homeCtrl.Alcohol.Text = "Alcohol : " + params(0)
        homeCtrl.CO.Text = "CO : " + params(1)

        'Graphics
        Debug.Assert(IsNumeric(params(0)))
        UpdateAlcoholColor(params(0))
        Debug.Assert(IsNumeric(params(1)))
        UpdateCOColor(params(1))
    End Sub

    'gets motion detection status
    Public Sub GetMonitorStatus()
        If gFetching(gMotionSensorModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ExtractMonitorStatus", gMotionSensorModuleId)
        Dim monitorStatus As String = GetResponse(tcpParam)
        If (monitorStatus = "Disconnected") Or (monitorStatus = "") Then
            Return
        End If

        Select Case monitorStatus
            Case "-"
                'no motion detected
                Return
            Case Else
                'motion detection times
                homeCtrl.MonitorStatus.Text += monitorStatus + Environment.NewLine

                'welcome speech
                Speech("Welcome_")

                'disable surveillance box
                homeCtrl.SurveillanceGrp.Enabled = False

                'switch on light
                If homeCtrl.MotionDetectPowerOn.Checked = False Then
                    Dim curTime As Date = DateAndTime.Now

                    If (curTime.Hour >= 18) Or (curTime.Hour <= 2) Then
                        gFluLight.SetPowerOn(True)
                    End If
                End If
        End Select
    End Sub

    'gets touch sensor status
    Public Sub GetTouchSensorStatus()
        If gFetching(gTouchSensorModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ExtractTouchSensorStatus", gTouchSensorModuleId)
        Dim touchSensorStatus As String = GetResponse(tcpParam)
        If (touchSensorStatus = "Disconnected") Or (touchSensorStatus = "") Then
            Return
        End If

        Debug.Assert((touchSensorStatus = "0") Or (touchSensorStatus = "1"))

        If touchSensorStatus = "1" Then
            'touch button pressed
            KillMusic()
        End If
    End Sub

    'check whether tcp connection is maintained
    Public Sub CheckConnectionStatus()
        For idx = 0 To gFetching.Length - 1
            If gFetching(idx) = False Then
                Continue For
            End If

            Dim tcpParam As TcpParameter = New TcpParameter("IsConnected", idx)
            Dim connectionStatus As String = GetResponse(tcpParam)

            If (connectionStatus = "Disconnected") Or (connectionStatus = "") Then
                Return
            End If

            Debug.Assert(connectionStatus = "connected")
        Next
    End Sub

    'gets motion and camera settings
    Public Sub MotionAndCameraSettings()
        If (gFetching(gMotionSensorModuleId) = False) Or (gFetching(gCameraModuleId) = False) Then
            Exit Sub
        End If

        'motion detection enabled data
        Dim tcpParam As TcpParameter = New TcpParameter("GetIsEnableMotionDetect", gMotionSensorModuleId)
        Dim data As String = GetResponse(tcpParam)
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If
        gEnableMotionDetect = CBool(Int(data))
        homeCtrl.MotionDetectCheck.Checked = gEnableMotionDetect

        'enabled video data
        tcpParam = New TcpParameter("GetIsDisableVideo", gCameraModuleId)
        data = GetResponse(tcpParam)
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If
        gDisableVideo = CBool(Int(data))
        homeCtrl.VideoCheck.Checked = gDisableVideo

        'enabled audio data
        tcpParam = New TcpParameter("GetIsDisableAudio", gCameraModuleId)
        data = GetResponse(tcpParam)
        If (data = "Disconnected") Or (data = "") Then
            Return
        End If
        gDisableAudio = CBool(Int(data))
        homeCtrl.AudioCheck.Checked = gDisableAudio
    End Sub

    'gets light settings data
    Public Sub GetLightingSettings()
        If gFetching(gLightings1ModuleId) = False Then
            Exit Sub
        End If

        'fluorescent light data
        gFluLight = New Appliance(homeCtrl.FluLight,
                                  Color.White,
                                  Color.DarkGray,
                                  "CheckIfOnFluLight",
                                  "PowerOnFluLight")

        'plug0
        gPlug0 = New Appliance(homeCtrl.Plug0,
                               Color.FromArgb(255, 192, 192),
                               Color.FromArgb(192, 255, 255),
                               "CheckIfOnPlug0",
                               "PowerOnPlug0")

        'fan
        gFan = New Appliance(homeCtrl.Fan,
                             Color.FromArgb(128, 128, 255),
                             Color.White,
                             "CheckIfOnFan",
                             "PowerOnFan")

        'balcony light
        gBalconyLight = New Appliance(homeCtrl.BalconyLight,
                                      Color.FromArgb(255, 255, 192),
                                      Color.FromArgb(224, 224, 224),
                                      "CheckIfOnBalconyLight",
                                      "PowerOnBalconyLight")

        'light bulb
        gLightBulb = New Appliance(homeCtrl.LightBulb,
                                   Color.FromArgb(255, 255, 192),
                                   Color.FromArgb(224, 224, 224),
                                   "CheckIfOnBulb0",
                                   "PowerOnBulb0")

        'plug1
        gPlug1 = New Appliance(homeCtrl.Plug1,
                               Color.FromArgb(192, 255, 192),
                               Color.FromArgb(255, 192, 192),
                               "CheckIfOnPlug1",
                               "PowerOnPlug1")
    End Sub

    'toggles LED light
    Public Sub ToggleLEDLight()
        If gFetching(gLightings2ModuleId) = False Then
            Exit Sub
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("ToggleLED", gLightings2ModuleId)
        GetResponse(tcpParam)
    End Sub

    'enables/disables motion detection
    Public Function EnableMotionDetect(en As Integer) As Boolean
        If gFetching(gMotionSensorModuleId) = False Then
            Return False
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("EnableMotionDetect" + Str(en), gMotionSensorModuleId)
        Dim enableMotionDetectFlag As String = GetResponse(tcpParam)

        If (enableMotionDetectFlag = "Disconnected") Or (enableMotionDetectFlag = "") Then
            Return False
        End If
        Debug.Assert((Int(enableMotionDetectFlag) = 0) Or (Int(enableMotionDetectFlag) = 1))

        gEnableMotionDetect = CBool(en)
        Return CBool(Int(enableMotionDetectFlag))
    End Function

    'enables/disables video recording on motion detection
    Public Function DisableVideo(en As Integer) As Boolean
        If gFetching(gCameraModuleId) = False Then
            Return False
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("DisableVideo" + Str(en), gCameraModuleId)
        Dim disableVideoFlag As String = GetResponse(tcpParam)

        If (disableVideoFlag = "Disconnected") Or (disableVideoFlag = "") Then
            Return False
        End If
        Debug.Assert((Int(disableVideoFlag) = 0) Or (Int(disableVideoFlag) = 1))

        gDisableVideo = CBool(en)
        Return CBool(Int(disableVideoFlag))
    End Function

    'enables/disables audio recording on motion detection
    Public Function DisableAudio(en As Integer) As Boolean
        If gFetching(gCameraModuleId) = False Then
            Return False
        End If

        Dim tcpParam As TcpParameter = New TcpParameter("DisableAudio" + Str(en), gCameraModuleId)
        Dim disableAudioFlag As String = GetResponse(tcpParam)

        If (disableAudioFlag = "Disconnected") Or (disableAudioFlag = "") Then
            Return False
        End If
        Debug.Assert((Int(disableAudioFlag) = 0) Or (Int(disableAudioFlag) = 1))

        gDisableAudio = CBool(en)
        Return CBool(Int(disableAudioFlag))
    End Function

End Module
