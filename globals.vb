Imports System.Net.Sockets
Imports System.Threading

Module globals

    'tcp client
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public gClient(1) As TcpClient



    'thread to get response from RPI
    '------------------------------------------------------------------------------------------------------------------------------------------------
    Public gTcpResponseTrd As Thread



    'file/folder paths
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'settings file path
    Public gSettingsFile = My.Application.Info.DirectoryPath + "\Settings.ini"

    'surveillance directory path
    Public gSurveillanceDir As String = "\\RPI3\backups\surveillance"



    'boolean
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'tcp connection status 
    Public gFetching(1) As Boolean

    'data loading phase
    Public gLoading As Boolean = True

    'light settings mode
    Public gLightSettingsMode As Boolean = False

    'power profile mode
    Public gPowerHistSelectMode As Boolean = False

    'motion detection enable status
    Public gEnableMotionDetect As Boolean = False

    'video disable status
    Public gDisableVideo As Boolean = False

    'audio disable status
    Public gDisableAudio As Boolean = False

    'enable speech status
    Public gEnableSpeech As Boolean = False

    'live feed on status
    Public gCameraOn As Boolean = False



    'interger
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'motion activation delay
    Public gMotionActDelay As Integer = 0



    'appliances
    '------------------------------------------------------------------------------------------------------------------------------------------------

    'fluorescent light appliance
    Public gFluLight As Appliance

    'plug0 appliance
    Public gPlug0 As Appliance

    'fan appliance
    Public gFan As Appliance

    'balcony light appliance
    Public gBalconyLight As Appliance

    'light bulb appliance
    Public gLightBulb As Appliance

    'plug1 appliance
    Public gPlug1 As Appliance

End Module
