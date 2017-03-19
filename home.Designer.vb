<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class homeCtrl
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Fetch = New System.Windows.Forms.Button()
        Me.Temperature = New System.Windows.Forms.Label()
        Me.Packet = New System.Windows.Forms.TextBox()
        Me.debugButton = New System.Windows.Forms.Button()
        Me.Connect = New System.Windows.Forms.Button()
        Me.Timer20s = New System.Windows.Forms.Timer(Me.components)
        Me.Pressure = New System.Windows.Forms.Label()
        Me.Humidity = New System.Windows.Forms.Label()
        Me.Toggleled = New System.Windows.Forms.Button()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.settingsPage = New System.Windows.Forms.TabPage()
        Me.Recordings = New System.Windows.Forms.Button()
        Me.Record = New System.Windows.Forms.Button()
        Me.LiveFeed = New System.Windows.Forms.Button()
        Me.SurveillanceGrp = New System.Windows.Forms.GroupBox()
        Me.OpenDir = New System.Windows.Forms.Button()
        Me.AudioOpen = New System.Windows.Forms.Button()
        Me.VideoOpen = New System.Windows.Forms.Button()
        Me.secList = New System.Windows.Forms.ComboBox()
        Me.minList = New System.Windows.Forms.ComboBox()
        Me.hrList = New System.Windows.Forms.ComboBox()
        Me.dayList = New System.Windows.Forms.ComboBox()
        Me.monthList = New System.Windows.Forms.ComboBox()
        Me.yrList = New System.Windows.Forms.ComboBox()
        Me.Surveillance = New System.Windows.Forms.Button()
        Me.ClearMonitorStatus = New System.Windows.Forms.Button()
        Me.MotionDetectPowerOn = New System.Windows.Forms.CheckBox()
        Me.AudioCheck = New System.Windows.Forms.CheckBox()
        Me.VideoCheck = New System.Windows.Forms.CheckBox()
        Me.MotionDetectCheck = New System.Windows.Forms.CheckBox()
        Me.MotionActDelay = New System.Windows.Forms.TrackBar()
        Me.MotionActDelayLabel = New System.Windows.Forms.Label()
        Me.MonitorStatus = New System.Windows.Forms.TextBox()
        Me.room = New System.Windows.Forms.TabPage()
        Me.ClearHist = New System.Windows.Forms.Button()
        Me.ShowPowerHist = New System.Windows.Forms.Button()
        Me.pwHist = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SettingsGrp = New System.Windows.Forms.GroupBox()
        Me.DisableLightSchedule = New System.Windows.Forms.CheckBox()
        Me.ResetSchedule = New System.Windows.Forms.Button()
        Me.TimerGrp = New System.Windows.Forms.GroupBox()
        Me.hr2 = New System.Windows.Forms.NumericUpDown()
        Me.sec2 = New System.Windows.Forms.NumericUpDown()
        Me.min2 = New System.Windows.Forms.NumericUpDown()
        Me.ToggleLightings = New System.Windows.Forms.CheckBox()
        Me.EnableLightSchedule = New System.Windows.Forms.CheckBox()
        Me.EndTimeGrp = New System.Windows.Forms.GroupBox()
        Me.hr1 = New System.Windows.Forms.NumericUpDown()
        Me.sec1 = New System.Windows.Forms.NumericUpDown()
        Me.min1 = New System.Windows.Forms.NumericUpDown()
        Me.StartTimeGrp = New System.Windows.Forms.GroupBox()
        Me.hr0 = New System.Windows.Forms.NumericUpDown()
        Me.sec0 = New System.Windows.Forms.NumericUpDown()
        Me.min0 = New System.Windows.Forms.NumericUpDown()
        Me.SelectPlug1 = New System.Windows.Forms.RadioButton()
        Me.Plug1 = New System.Windows.Forms.Button()
        Me.SelectBalconyLight = New System.Windows.Forms.RadioButton()
        Me.SelectPlug0 = New System.Windows.Forms.RadioButton()
        Me.SelectFluLight = New System.Windows.Forms.RadioButton()
        Me.SelectFan = New System.Windows.Forms.RadioButton()
        Me.SelectLightBulb = New System.Windows.Forms.RadioButton()
        Me.LightingSettings = New System.Windows.Forms.Button()
        Me.Fan = New System.Windows.Forms.Button()
        Me.LightBulb = New System.Windows.Forms.Button()
        Me.BalconyLight = New System.Windows.Forms.Button()
        Me.Plug0 = New System.Windows.Forms.Button()
        Me.FluLight = New System.Windows.Forms.Button()
        Me.rgb_led = New System.Windows.Forms.TabPage()
        Me.DisableLED = New System.Windows.Forms.Button()
        Me.LEDButtons = New System.Windows.Forms.GroupBox()
        Me.LEDButton24 = New System.Windows.Forms.Button()
        Me.LEDButton20 = New System.Windows.Forms.Button()
        Me.LEDButton23 = New System.Windows.Forms.Button()
        Me.LEDButton19 = New System.Windows.Forms.Button()
        Me.LEDButton22 = New System.Windows.Forms.Button()
        Me.LEDButton18 = New System.Windows.Forms.Button()
        Me.LEDButton21 = New System.Windows.Forms.Button()
        Me.LEDButton17 = New System.Windows.Forms.Button()
        Me.LEDButton16 = New System.Windows.Forms.Button()
        Me.LEDButton15 = New System.Windows.Forms.Button()
        Me.LEDButton14 = New System.Windows.Forms.Button()
        Me.LEDButton13 = New System.Windows.Forms.Button()
        Me.LEDButton12 = New System.Windows.Forms.Button()
        Me.LEDButton11 = New System.Windows.Forms.Button()
        Me.LEDButton10 = New System.Windows.Forms.Button()
        Me.LEDButton09 = New System.Windows.Forms.Button()
        Me.LEDButton08 = New System.Windows.Forms.Button()
        Me.LEDButton07 = New System.Windows.Forms.Button()
        Me.LEDButton06 = New System.Windows.Forms.Button()
        Me.LEDButton05 = New System.Windows.Forms.Button()
        Me.LEDButton04 = New System.Windows.Forms.Button()
        Me.LEDButton03 = New System.Windows.Forms.Button()
        Me.LEDButton02 = New System.Windows.Forms.Button()
        Me.LEDButton01 = New System.Windows.Forms.Button()
        Me.EnableLED = New System.Windows.Forms.Button()
        Me.Alarm = New System.Windows.Forms.TabPage()
        Me.SnoozeLabel = New System.Windows.Forms.Label()
        Me.MusicAlarmLabel = New System.Windows.Forms.Label()
        Me.AlarmList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SnoozeAlarm = New System.Windows.Forms.Button()
        Me.BrowseAlarm = New System.Windows.Forms.Button()
        Me.StopAlarm = New System.Windows.Forms.Button()
        Me.DeleteAlarm = New System.Windows.Forms.Button()
        Me.HourAlarm = New System.Windows.Forms.NumericUpDown()
        Me.MinAlarm = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SnoozeTimer0 = New System.Windows.Forms.RadioButton()
        Me.SnoozeTimer2 = New System.Windows.Forms.RadioButton()
        Me.SnoozeTimer1 = New System.Windows.Forms.RadioButton()
        Me.AmPmAlarm = New System.Windows.Forms.ComboBox()
        Me.AddAlarm = New System.Windows.Forms.Button()
        Me.TestAlarm = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PressureData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.HumidityData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TemperatureData = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MotionDetectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LightingsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SpeechCheck = New System.Windows.Forms.CheckBox()
        Me.SpeechTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ReconnectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StreamDebugIdx = New System.Windows.Forms.NumericUpDown()
        Me.StreamIdx = New System.Windows.Forms.NumericUpDown()
        Me.ConnectCheck = New System.Windows.Forms.CheckBox()
        Me.LEDTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Alcohol = New System.Windows.Forms.Label()
        Me.CO = New System.Windows.Forms.Label()
        Me.RealTime = New System.Windows.Forms.Label()
        Me.Timer500ms = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAlarm = New System.Windows.Forms.Timer(Me.components)
        Me.MusicFileBrowse = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1s = New System.Windows.Forms.Timer(Me.components)
        Me.Smoke = New System.Windows.Forms.Label()
        Me.ControlRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClimateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Tabs.SuspendLayout()
        Me.settingsPage.SuspendLayout()
        Me.SurveillanceGrp.SuspendLayout()
        CType(Me.MotionActDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.room.SuspendLayout()
        CType(Me.pwHist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SettingsGrp.SuspendLayout()
        Me.TimerGrp.SuspendLayout()
        CType(Me.hr2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sec2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.min2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EndTimeGrp.SuspendLayout()
        CType(Me.hr1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sec1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.min1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StartTimeGrp.SuspendLayout()
        CType(Me.hr0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sec0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.min0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgb_led.SuspendLayout()
        Me.LEDButtons.SuspendLayout()
        Me.Alarm.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.HourAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PressureData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HumidityData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TemperatureData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StreamDebugIdx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StreamIdx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fetch
        '
        Me.Fetch.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Fetch.Enabled = False
        Me.Fetch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Fetch.Location = New System.Drawing.Point(364, 934)
        Me.Fetch.Name = "Fetch"
        Me.Fetch.Size = New System.Drawing.Size(80, 46)
        Me.Fetch.TabIndex = 25
        Me.Fetch.Text = "Fetch data"
        Me.Fetch.UseVisualStyleBackColor = False
        '
        'Temperature
        '
        Me.Temperature.AutoSize = True
        Me.Temperature.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Temperature.Location = New System.Drawing.Point(12, 9)
        Me.Temperature.Name = "Temperature"
        Me.Temperature.Padding = New System.Windows.Forms.Padding(10)
        Me.Temperature.Size = New System.Drawing.Size(96, 33)
        Me.Temperature.TabIndex = 19
        Me.Temperature.Text = "Temperature : "
        '
        'Packet
        '
        Me.Packet.Location = New System.Drawing.Point(829, 948)
        Me.Packet.Name = "Packet"
        Me.Packet.Size = New System.Drawing.Size(143, 20)
        Me.Packet.TabIndex = 18
        '
        'debugButton
        '
        Me.debugButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.debugButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.debugButton.Location = New System.Drawing.Point(648, 934)
        Me.debugButton.Name = "debugButton"
        Me.debugButton.Size = New System.Drawing.Size(80, 46)
        Me.debugButton.TabIndex = 17
        Me.debugButton.Text = "Debug"
        Me.debugButton.UseVisualStyleBackColor = False
        '
        'Connect
        '
        Me.Connect.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Connect.Location = New System.Drawing.Point(16, 927)
        Me.Connect.Name = "Connect"
        Me.Connect.Size = New System.Drawing.Size(127, 53)
        Me.Connect.TabIndex = 16
        Me.Connect.Text = "connect"
        Me.Connect.UseVisualStyleBackColor = False
        '
        'Timer20s
        '
        Me.Timer20s.Enabled = True
        Me.Timer20s.Interval = 20000
        '
        'Pressure
        '
        Me.Pressure.AutoSize = True
        Me.Pressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Pressure.Location = New System.Drawing.Point(321, 9)
        Me.Pressure.Name = "Pressure"
        Me.Pressure.Padding = New System.Windows.Forms.Padding(10)
        Me.Pressure.Size = New System.Drawing.Size(138, 33)
        Me.Pressure.TabIndex = 29
        Me.Pressure.Text = "Atmospheric Pressure : "
        '
        'Humidity
        '
        Me.Humidity.AutoSize = True
        Me.Humidity.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Humidity.Location = New System.Drawing.Point(186, 9)
        Me.Humidity.Name = "Humidity"
        Me.Humidity.Padding = New System.Windows.Forms.Padding(10)
        Me.Humidity.Size = New System.Drawing.Size(76, 33)
        Me.Humidity.TabIndex = 28
        Me.Humidity.Text = "Humidity : "
        '
        'Toggleled
        '
        Me.Toggleled.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Toggleled.Enabled = False
        Me.Toggleled.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Toggleled.Location = New System.Drawing.Point(1345, 15)
        Me.Toggleled.Name = "Toggleled"
        Me.Toggleled.Size = New System.Drawing.Size(125, 66)
        Me.Toggleled.TabIndex = 30
        Me.Toggleled.Text = "Toggle LED Light"
        Me.Toggleled.UseVisualStyleBackColor = False
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.settingsPage)
        Me.Tabs.Controls.Add(Me.room)
        Me.Tabs.Controls.Add(Me.rgb_led)
        Me.Tabs.Controls.Add(Me.Alarm)
        Me.Tabs.Controls.Add(Me.TabPage1)
        Me.Tabs.Location = New System.Drawing.Point(12, 87)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1880, 803)
        Me.Tabs.TabIndex = 31
        '
        'settingsPage
        '
        Me.settingsPage.Controls.Add(Me.Recordings)
        Me.settingsPage.Controls.Add(Me.Record)
        Me.settingsPage.Controls.Add(Me.LiveFeed)
        Me.settingsPage.Controls.Add(Me.SurveillanceGrp)
        Me.settingsPage.Controls.Add(Me.Surveillance)
        Me.settingsPage.Controls.Add(Me.ClearMonitorStatus)
        Me.settingsPage.Controls.Add(Me.MotionDetectPowerOn)
        Me.settingsPage.Controls.Add(Me.AudioCheck)
        Me.settingsPage.Controls.Add(Me.VideoCheck)
        Me.settingsPage.Controls.Add(Me.MotionDetectCheck)
        Me.settingsPage.Controls.Add(Me.MotionActDelay)
        Me.settingsPage.Controls.Add(Me.MotionActDelayLabel)
        Me.settingsPage.Controls.Add(Me.MonitorStatus)
        Me.settingsPage.Location = New System.Drawing.Point(4, 22)
        Me.settingsPage.Name = "settingsPage"
        Me.settingsPage.Padding = New System.Windows.Forms.Padding(3)
        Me.settingsPage.Size = New System.Drawing.Size(1872, 777)
        Me.settingsPage.TabIndex = 0
        Me.settingsPage.Text = "Preferences & Surveillance"
        Me.settingsPage.UseVisualStyleBackColor = True
        '
        'Recordings
        '
        Me.Recordings.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Recordings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Recordings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recordings.ForeColor = System.Drawing.Color.Blue
        Me.Recordings.Location = New System.Drawing.Point(1466, 219)
        Me.Recordings.Name = "Recordings"
        Me.Recordings.Size = New System.Drawing.Size(135, 46)
        Me.Recordings.TabIndex = 27
        Me.Recordings.Text = "Load" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Recordings"
        Me.Recordings.UseVisualStyleBackColor = False
        '
        'Record
        '
        Me.Record.BackColor = System.Drawing.Color.PaleGreen
        Me.Record.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Record.Location = New System.Drawing.Point(1714, 396)
        Me.Record.Name = "Record"
        Me.Record.Size = New System.Drawing.Size(86, 47)
        Me.Record.TabIndex = 26
        Me.Record.Text = "Record"
        Me.Record.UseVisualStyleBackColor = False
        '
        'LiveFeed
        '
        Me.LiveFeed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LiveFeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LiveFeed.Location = New System.Drawing.Point(1714, 302)
        Me.LiveFeed.Name = "LiveFeed"
        Me.LiveFeed.Size = New System.Drawing.Size(86, 47)
        Me.LiveFeed.TabIndex = 25
        Me.LiveFeed.Text = "Live" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Feed"
        Me.LiveFeed.UseVisualStyleBackColor = False
        '
        'SurveillanceGrp
        '
        Me.SurveillanceGrp.Controls.Add(Me.OpenDir)
        Me.SurveillanceGrp.Controls.Add(Me.AudioOpen)
        Me.SurveillanceGrp.Controls.Add(Me.VideoOpen)
        Me.SurveillanceGrp.Controls.Add(Me.secList)
        Me.SurveillanceGrp.Controls.Add(Me.minList)
        Me.SurveillanceGrp.Controls.Add(Me.hrList)
        Me.SurveillanceGrp.Controls.Add(Me.dayList)
        Me.SurveillanceGrp.Controls.Add(Me.monthList)
        Me.SurveillanceGrp.Controls.Add(Me.yrList)
        Me.SurveillanceGrp.Enabled = False
        Me.SurveillanceGrp.Location = New System.Drawing.Point(1319, 283)
        Me.SurveillanceGrp.Name = "SurveillanceGrp"
        Me.SurveillanceGrp.Size = New System.Drawing.Size(296, 187)
        Me.SurveillanceGrp.TabIndex = 24
        Me.SurveillanceGrp.TabStop = False
        '
        'OpenDir
        '
        Me.OpenDir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.OpenDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpenDir.Location = New System.Drawing.Point(196, 122)
        Me.OpenDir.Name = "OpenDir"
        Me.OpenDir.Size = New System.Drawing.Size(86, 47)
        Me.OpenDir.TabIndex = 20
        Me.OpenDir.Text = "Open" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Directory"
        Me.OpenDir.UseVisualStyleBackColor = False
        '
        'AudioOpen
        '
        Me.AudioOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.AudioOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AudioOpen.Location = New System.Drawing.Point(104, 122)
        Me.AudioOpen.Name = "AudioOpen"
        Me.AudioOpen.Size = New System.Drawing.Size(86, 47)
        Me.AudioOpen.TabIndex = 19
        Me.AudioOpen.Text = "Play" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Audio"
        Me.AudioOpen.UseVisualStyleBackColor = False
        '
        'VideoOpen
        '
        Me.VideoOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.VideoOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.VideoOpen.Location = New System.Drawing.Point(14, 122)
        Me.VideoOpen.Name = "VideoOpen"
        Me.VideoOpen.Size = New System.Drawing.Size(86, 47)
        Me.VideoOpen.TabIndex = 18
        Me.VideoOpen.Text = "Play" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Video"
        Me.VideoOpen.UseVisualStyleBackColor = False
        '
        'secList
        '
        Me.secList.FormattingEnabled = True
        Me.secList.Location = New System.Drawing.Point(181, 55)
        Me.secList.Name = "secList"
        Me.secList.Size = New System.Drawing.Size(53, 21)
        Me.secList.Sorted = True
        Me.secList.TabIndex = 15
        '
        'minList
        '
        Me.minList.FormattingEnabled = True
        Me.minList.Location = New System.Drawing.Point(122, 55)
        Me.minList.Name = "minList"
        Me.minList.Size = New System.Drawing.Size(53, 21)
        Me.minList.Sorted = True
        Me.minList.TabIndex = 14
        '
        'hrList
        '
        Me.hrList.FormattingEnabled = True
        Me.hrList.Location = New System.Drawing.Point(58, 55)
        Me.hrList.Name = "hrList"
        Me.hrList.Size = New System.Drawing.Size(53, 21)
        Me.hrList.Sorted = True
        Me.hrList.TabIndex = 13
        '
        'dayList
        '
        Me.dayList.FormattingEnabled = True
        Me.dayList.Location = New System.Drawing.Point(52, 19)
        Me.dayList.Name = "dayList"
        Me.dayList.Size = New System.Drawing.Size(53, 21)
        Me.dayList.Sorted = True
        Me.dayList.TabIndex = 12
        '
        'monthList
        '
        Me.monthList.FormattingEnabled = True
        Me.monthList.Location = New System.Drawing.Point(116, 19)
        Me.monthList.Name = "monthList"
        Me.monthList.Size = New System.Drawing.Size(53, 21)
        Me.monthList.Sorted = True
        Me.monthList.TabIndex = 11
        '
        'yrList
        '
        Me.yrList.FormattingEnabled = True
        Me.yrList.Location = New System.Drawing.Point(175, 19)
        Me.yrList.Name = "yrList"
        Me.yrList.Size = New System.Drawing.Size(70, 21)
        Me.yrList.Sorted = True
        Me.yrList.TabIndex = 9
        '
        'Surveillance
        '
        Me.Surveillance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Surveillance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Surveillance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Surveillance.ForeColor = System.Drawing.Color.Blue
        Me.Surveillance.Location = New System.Drawing.Point(1319, 219)
        Me.Surveillance.Name = "Surveillance"
        Me.Surveillance.Size = New System.Drawing.Size(135, 46)
        Me.Surveillance.TabIndex = 23
        Me.Surveillance.Text = "Load" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Surveillance cllips"
        Me.Surveillance.UseVisualStyleBackColor = False
        '
        'ClearMonitorStatus
        '
        Me.ClearMonitorStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClearMonitorStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearMonitorStatus.Location = New System.Drawing.Point(24, 262)
        Me.ClearMonitorStatus.Name = "ClearMonitorStatus"
        Me.ClearMonitorStatus.Size = New System.Drawing.Size(57, 26)
        Me.ClearMonitorStatus.TabIndex = 21
        Me.ClearMonitorStatus.Text = "Clear"
        Me.ClearMonitorStatus.UseVisualStyleBackColor = False
        '
        'MotionDetectPowerOn
        '
        Me.MotionDetectPowerOn.AutoSize = True
        Me.MotionDetectPowerOn.ForeColor = System.Drawing.Color.Green
        Me.MotionDetectPowerOn.Location = New System.Drawing.Point(473, 130)
        Me.MotionDetectPowerOn.Name = "MotionDetectPowerOn"
        Me.MotionDetectPowerOn.Size = New System.Drawing.Size(166, 30)
        Me.MotionDetectPowerOn.TabIndex = 7
        Me.MotionDetectPowerOn.Text = "Don't Power on light" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "at night after motion detection"
        Me.MotionDetectPowerOn.UseVisualStyleBackColor = True
        '
        'AudioCheck
        '
        Me.AudioCheck.AutoSize = True
        Me.AudioCheck.ForeColor = System.Drawing.Color.Green
        Me.AudioCheck.Location = New System.Drawing.Point(516, 300)
        Me.AudioCheck.Name = "AudioCheck"
        Me.AudioCheck.Size = New System.Drawing.Size(90, 17)
        Me.AudioCheck.TabIndex = 6
        Me.AudioCheck.Text = "Disable audio"
        Me.AudioCheck.UseVisualStyleBackColor = True
        '
        'VideoCheck
        '
        Me.VideoCheck.AutoSize = True
        Me.VideoCheck.ForeColor = System.Drawing.Color.Green
        Me.VideoCheck.Location = New System.Drawing.Point(516, 268)
        Me.VideoCheck.Name = "VideoCheck"
        Me.VideoCheck.Size = New System.Drawing.Size(90, 17)
        Me.VideoCheck.TabIndex = 5
        Me.VideoCheck.Text = "Disable video"
        Me.VideoCheck.UseVisualStyleBackColor = True
        '
        'MotionDetectCheck
        '
        Me.MotionDetectCheck.AutoSize = True
        Me.MotionDetectCheck.ForeColor = System.Drawing.Color.Green
        Me.MotionDetectCheck.Location = New System.Drawing.Point(474, 107)
        Me.MotionDetectCheck.Name = "MotionDetectCheck"
        Me.MotionDetectCheck.Size = New System.Drawing.Size(140, 17)
        Me.MotionDetectCheck.TabIndex = 4
        Me.MotionDetectCheck.Text = "Enable motion detection"
        Me.MotionDetectCheck.UseVisualStyleBackColor = True
        '
        'MotionActDelay
        '
        Me.MotionActDelay.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MotionActDelay.Location = New System.Drawing.Point(473, 39)
        Me.MotionActDelay.Name = "MotionActDelay"
        Me.MotionActDelay.Size = New System.Drawing.Size(177, 45)
        Me.MotionActDelay.TabIndex = 3
        '
        'MotionActDelayLabel
        '
        Me.MotionActDelayLabel.AutoSize = True
        Me.MotionActDelayLabel.ForeColor = System.Drawing.Color.Blue
        Me.MotionActDelayLabel.Location = New System.Drawing.Point(490, 16)
        Me.MotionActDelayLabel.Name = "MotionActDelayLabel"
        Me.MotionActDelayLabel.Size = New System.Drawing.Size(119, 13)
        Me.MotionActDelayLabel.TabIndex = 2
        Me.MotionActDelayLabel.Text = "Motion Activation Delay"
        '
        'MonitorStatus
        '
        Me.MonitorStatus.BackColor = System.Drawing.Color.Ivory
        Me.MonitorStatus.Location = New System.Drawing.Point(24, 16)
        Me.MonitorStatus.Multiline = True
        Me.MonitorStatus.Name = "MonitorStatus"
        Me.MonitorStatus.ReadOnly = True
        Me.MonitorStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MonitorStatus.Size = New System.Drawing.Size(194, 227)
        Me.MonitorStatus.TabIndex = 1
        '
        'room
        '
        Me.room.BackColor = System.Drawing.Color.WhiteSmoke
        Me.room.Controls.Add(Me.ClearHist)
        Me.room.Controls.Add(Me.ShowPowerHist)
        Me.room.Controls.Add(Me.pwHist)
        Me.room.Controls.Add(Me.SettingsGrp)
        Me.room.Controls.Add(Me.SelectPlug1)
        Me.room.Controls.Add(Me.Plug1)
        Me.room.Controls.Add(Me.SelectBalconyLight)
        Me.room.Controls.Add(Me.SelectPlug0)
        Me.room.Controls.Add(Me.SelectFluLight)
        Me.room.Controls.Add(Me.SelectFan)
        Me.room.Controls.Add(Me.SelectLightBulb)
        Me.room.Controls.Add(Me.LightingSettings)
        Me.room.Controls.Add(Me.Fan)
        Me.room.Controls.Add(Me.LightBulb)
        Me.room.Controls.Add(Me.BalconyLight)
        Me.room.Controls.Add(Me.Plug0)
        Me.room.Controls.Add(Me.FluLight)
        Me.room.Location = New System.Drawing.Point(4, 22)
        Me.room.Name = "room"
        Me.room.Padding = New System.Windows.Forms.Padding(3)
        Me.room.Size = New System.Drawing.Size(1872, 777)
        Me.room.TabIndex = 1
        Me.room.Text = "Lightings"
        '
        'ClearHist
        '
        Me.ClearHist.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClearHist.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearHist.Location = New System.Drawing.Point(1793, 720)
        Me.ClearHist.Name = "ClearHist"
        Me.ClearHist.Size = New System.Drawing.Size(57, 26)
        Me.ClearHist.TabIndex = 20
        Me.ClearHist.Text = "Clear"
        Me.ClearHist.UseVisualStyleBackColor = False
        '
        'ShowPowerHist
        '
        Me.ShowPowerHist.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ShowPowerHist.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ShowPowerHist.Location = New System.Drawing.Point(820, 16)
        Me.ShowPowerHist.Name = "ShowPowerHist"
        Me.ShowPowerHist.Size = New System.Drawing.Size(70, 742)
        Me.ShowPowerHist.TabIndex = 34
        Me.ShowPowerHist.Text = "Power " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Profile"
        Me.ShowPowerHist.UseVisualStyleBackColor = False
        '
        'pwHist
        '
        ChartArea5.Name = "ChartArea1"
        Me.pwHist.ChartAreas.Add(ChartArea5)
        Legend5.Name = "Legend1"
        Me.pwHist.Legends.Add(Legend5)
        Me.pwHist.Location = New System.Drawing.Point(903, 18)
        Me.pwHist.Name = "pwHist"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Power on Time"
        Series5.YValuesPerPoint = 4
        Me.pwHist.Series.Add(Series5)
        Me.pwHist.Size = New System.Drawing.Size(963, 753)
        Me.pwHist.TabIndex = 33
        Me.pwHist.Text = "Power Histogram"
        '
        'SettingsGrp
        '
        Me.SettingsGrp.Controls.Add(Me.DisableLightSchedule)
        Me.SettingsGrp.Controls.Add(Me.ResetSchedule)
        Me.SettingsGrp.Controls.Add(Me.TimerGrp)
        Me.SettingsGrp.Controls.Add(Me.ToggleLightings)
        Me.SettingsGrp.Controls.Add(Me.EnableLightSchedule)
        Me.SettingsGrp.Controls.Add(Me.EndTimeGrp)
        Me.SettingsGrp.Controls.Add(Me.StartTimeGrp)
        Me.SettingsGrp.Enabled = False
        Me.SettingsGrp.Location = New System.Drawing.Point(4, 329)
        Me.SettingsGrp.Name = "SettingsGrp"
        Me.SettingsGrp.Size = New System.Drawing.Size(802, 429)
        Me.SettingsGrp.TabIndex = 21
        Me.SettingsGrp.TabStop = False
        '
        'DisableLightSchedule
        '
        Me.DisableLightSchedule.AutoSize = True
        Me.DisableLightSchedule.Enabled = False
        Me.DisableLightSchedule.ForeColor = System.Drawing.Color.Maroon
        Me.DisableLightSchedule.Location = New System.Drawing.Point(490, 36)
        Me.DisableLightSchedule.Name = "DisableLightSchedule"
        Me.DisableLightSchedule.Size = New System.Drawing.Size(117, 17)
        Me.DisableLightSchedule.TabIndex = 20
        Me.DisableLightSchedule.Text = "Disable Scheduling"
        Me.DisableLightSchedule.UseVisualStyleBackColor = True
        '
        'ResetSchedule
        '
        Me.ResetSchedule.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ResetSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ResetSchedule.Location = New System.Drawing.Point(739, 17)
        Me.ResetSchedule.Name = "ResetSchedule"
        Me.ResetSchedule.Size = New System.Drawing.Size(57, 26)
        Me.ResetSchedule.TabIndex = 19
        Me.ResetSchedule.Text = "Reset"
        Me.ResetSchedule.UseVisualStyleBackColor = False
        '
        'TimerGrp
        '
        Me.TimerGrp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TimerGrp.Controls.Add(Me.hr2)
        Me.TimerGrp.Controls.Add(Me.sec2)
        Me.TimerGrp.Controls.Add(Me.min2)
        Me.TimerGrp.Enabled = False
        Me.TimerGrp.ForeColor = System.Drawing.Color.Blue
        Me.TimerGrp.Location = New System.Drawing.Point(120, 86)
        Me.TimerGrp.Name = "TimerGrp"
        Me.TimerGrp.Size = New System.Drawing.Size(170, 49)
        Me.TimerGrp.TabIndex = 18
        Me.TimerGrp.TabStop = False
        Me.TimerGrp.Text = "Timer"
        '
        'hr2
        '
        Me.hr2.Location = New System.Drawing.Point(6, 19)
        Me.hr2.Name = "hr2"
        Me.hr2.Size = New System.Drawing.Size(48, 20)
        Me.hr2.TabIndex = 11
        '
        'sec2
        '
        Me.sec2.Location = New System.Drawing.Point(114, 19)
        Me.sec2.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.sec2.Name = "sec2"
        Me.sec2.Size = New System.Drawing.Size(48, 20)
        Me.sec2.TabIndex = 13
        '
        'min2
        '
        Me.min2.Location = New System.Drawing.Point(60, 19)
        Me.min2.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.min2.Name = "min2"
        Me.min2.Size = New System.Drawing.Size(48, 20)
        Me.min2.TabIndex = 12
        '
        'ToggleLightings
        '
        Me.ToggleLightings.AutoSize = True
        Me.ToggleLightings.Enabled = False
        Me.ToggleLightings.ForeColor = System.Drawing.Color.Maroon
        Me.ToggleLightings.Location = New System.Drawing.Point(6, 99)
        Me.ToggleLightings.Name = "ToggleLightings"
        Me.ToggleLightings.Size = New System.Drawing.Size(91, 17)
        Me.ToggleLightings.TabIndex = 17
        Me.ToggleLightings.Text = "Toggle on/off"
        Me.ToggleLightings.UseVisualStyleBackColor = True
        '
        'EnableLightSchedule
        '
        Me.EnableLightSchedule.AutoSize = True
        Me.EnableLightSchedule.Enabled = False
        Me.EnableLightSchedule.ForeColor = System.Drawing.Color.Maroon
        Me.EnableLightSchedule.Location = New System.Drawing.Point(6, 35)
        Me.EnableLightSchedule.Name = "EnableLightSchedule"
        Me.EnableLightSchedule.Size = New System.Drawing.Size(79, 17)
        Me.EnableLightSchedule.TabIndex = 16
        Me.EnableLightSchedule.Text = "Scheduling"
        Me.EnableLightSchedule.UseVisualStyleBackColor = True
        '
        'EndTimeGrp
        '
        Me.EndTimeGrp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EndTimeGrp.Controls.Add(Me.hr1)
        Me.EndTimeGrp.Controls.Add(Me.sec1)
        Me.EndTimeGrp.Controls.Add(Me.min1)
        Me.EndTimeGrp.Enabled = False
        Me.EndTimeGrp.ForeColor = System.Drawing.Color.Blue
        Me.EndTimeGrp.Location = New System.Drawing.Point(299, 17)
        Me.EndTimeGrp.Name = "EndTimeGrp"
        Me.EndTimeGrp.Size = New System.Drawing.Size(170, 49)
        Me.EndTimeGrp.TabIndex = 15
        Me.EndTimeGrp.TabStop = False
        Me.EndTimeGrp.Text = "End Time"
        '
        'hr1
        '
        Me.hr1.Location = New System.Drawing.Point(6, 19)
        Me.hr1.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.hr1.Name = "hr1"
        Me.hr1.Size = New System.Drawing.Size(48, 20)
        Me.hr1.TabIndex = 11
        '
        'sec1
        '
        Me.sec1.Location = New System.Drawing.Point(114, 19)
        Me.sec1.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.sec1.Name = "sec1"
        Me.sec1.Size = New System.Drawing.Size(48, 20)
        Me.sec1.TabIndex = 13
        '
        'min1
        '
        Me.min1.Location = New System.Drawing.Point(60, 19)
        Me.min1.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.min1.Name = "min1"
        Me.min1.Size = New System.Drawing.Size(48, 20)
        Me.min1.TabIndex = 12
        '
        'StartTimeGrp
        '
        Me.StartTimeGrp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.StartTimeGrp.Controls.Add(Me.hr0)
        Me.StartTimeGrp.Controls.Add(Me.sec0)
        Me.StartTimeGrp.Controls.Add(Me.min0)
        Me.StartTimeGrp.Enabled = False
        Me.StartTimeGrp.ForeColor = System.Drawing.Color.Blue
        Me.StartTimeGrp.Location = New System.Drawing.Point(120, 17)
        Me.StartTimeGrp.Name = "StartTimeGrp"
        Me.StartTimeGrp.Size = New System.Drawing.Size(170, 49)
        Me.StartTimeGrp.TabIndex = 14
        Me.StartTimeGrp.TabStop = False
        Me.StartTimeGrp.Text = "Start Time"
        '
        'hr0
        '
        Me.hr0.Location = New System.Drawing.Point(6, 19)
        Me.hr0.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.hr0.Name = "hr0"
        Me.hr0.Size = New System.Drawing.Size(48, 20)
        Me.hr0.TabIndex = 11
        '
        'sec0
        '
        Me.sec0.Location = New System.Drawing.Point(114, 19)
        Me.sec0.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.sec0.Name = "sec0"
        Me.sec0.Size = New System.Drawing.Size(48, 20)
        Me.sec0.TabIndex = 13
        '
        'min0
        '
        Me.min0.Location = New System.Drawing.Point(60, 19)
        Me.min0.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.min0.Name = "min0"
        Me.min0.Size = New System.Drawing.Size(48, 20)
        Me.min0.TabIndex = 12
        '
        'SelectPlug1
        '
        Me.SelectPlug1.AutoSize = True
        Me.SelectPlug1.Location = New System.Drawing.Point(16, 23)
        Me.SelectPlug1.Name = "SelectPlug1"
        Me.SelectPlug1.Size = New System.Drawing.Size(14, 13)
        Me.SelectPlug1.TabIndex = 20
        Me.SelectPlug1.TabStop = True
        Me.SelectPlug1.UseVisualStyleBackColor = True
        Me.SelectPlug1.Visible = False
        '
        'Plug1
        '
        Me.Plug1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Plug1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Plug1.Location = New System.Drawing.Point(35, 10)
        Me.Plug1.Name = "Plug1"
        Me.Plug1.Size = New System.Drawing.Size(62, 40)
        Me.Plug1.TabIndex = 19
        Me.Plug1.Text = "Laptop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "outlet"
        Me.Plug1.UseVisualStyleBackColor = False
        '
        'SelectBalconyLight
        '
        Me.SelectBalconyLight.AutoSize = True
        Me.SelectBalconyLight.Location = New System.Drawing.Point(567, 194)
        Me.SelectBalconyLight.Name = "SelectBalconyLight"
        Me.SelectBalconyLight.Size = New System.Drawing.Size(14, 13)
        Me.SelectBalconyLight.TabIndex = 10
        Me.SelectBalconyLight.TabStop = True
        Me.SelectBalconyLight.UseVisualStyleBackColor = True
        Me.SelectBalconyLight.Visible = False
        '
        'SelectPlug0
        '
        Me.SelectPlug0.AutoSize = True
        Me.SelectPlug0.Location = New System.Drawing.Point(475, 243)
        Me.SelectPlug0.Name = "SelectPlug0"
        Me.SelectPlug0.Size = New System.Drawing.Size(14, 13)
        Me.SelectPlug0.TabIndex = 9
        Me.SelectPlug0.TabStop = True
        Me.SelectPlug0.UseVisualStyleBackColor = True
        Me.SelectPlug0.Visible = False
        '
        'SelectFluLight
        '
        Me.SelectFluLight.AutoSize = True
        Me.SelectFluLight.Location = New System.Drawing.Point(170, 243)
        Me.SelectFluLight.Name = "SelectFluLight"
        Me.SelectFluLight.Size = New System.Drawing.Size(14, 13)
        Me.SelectFluLight.TabIndex = 8
        Me.SelectFluLight.TabStop = True
        Me.SelectFluLight.UseVisualStyleBackColor = True
        Me.SelectFluLight.Visible = False
        '
        'SelectFan
        '
        Me.SelectFan.AutoSize = True
        Me.SelectFan.Location = New System.Drawing.Point(270, 114)
        Me.SelectFan.Name = "SelectFan"
        Me.SelectFan.Size = New System.Drawing.Size(14, 13)
        Me.SelectFan.TabIndex = 7
        Me.SelectFan.TabStop = True
        Me.SelectFan.UseVisualStyleBackColor = True
        Me.SelectFan.Visible = False
        '
        'SelectLightBulb
        '
        Me.SelectLightBulb.AutoSize = True
        Me.SelectLightBulb.Location = New System.Drawing.Point(270, 18)
        Me.SelectLightBulb.Name = "SelectLightBulb"
        Me.SelectLightBulb.Size = New System.Drawing.Size(14, 13)
        Me.SelectLightBulb.TabIndex = 6
        Me.SelectLightBulb.TabStop = True
        Me.SelectLightBulb.UseVisualStyleBackColor = True
        Me.SelectLightBulb.Visible = False
        '
        'LightingSettings
        '
        Me.LightingSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LightingSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LightingSettings.Location = New System.Drawing.Point(4, 299)
        Me.LightingSettings.Name = "LightingSettings"
        Me.LightingSettings.Size = New System.Drawing.Size(802, 27)
        Me.LightingSettings.TabIndex = 5
        Me.LightingSettings.Text = "Scheduler"
        Me.LightingSettings.UseVisualStyleBackColor = False
        '
        'Fan
        '
        Me.Fan.BackColor = System.Drawing.Color.White
        Me.Fan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Fan.Location = New System.Drawing.Point(292, 95)
        Me.Fan.Name = "Fan"
        Me.Fan.Size = New System.Drawing.Size(64, 54)
        Me.Fan.TabIndex = 4
        Me.Fan.Text = "Fan"
        Me.Fan.UseVisualStyleBackColor = False
        '
        'LightBulb
        '
        Me.LightBulb.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LightBulb.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LightBulb.Location = New System.Drawing.Point(292, 6)
        Me.LightBulb.Name = "LightBulb"
        Me.LightBulb.Size = New System.Drawing.Size(62, 36)
        Me.LightBulb.TabIndex = 3
        Me.LightBulb.Text = "Light" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bulb"
        Me.LightBulb.UseVisualStyleBackColor = False
        '
        'BalconyLight
        '
        Me.BalconyLight.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BalconyLight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BalconyLight.Location = New System.Drawing.Point(587, 182)
        Me.BalconyLight.Name = "BalconyLight"
        Me.BalconyLight.Size = New System.Drawing.Size(62, 36)
        Me.BalconyLight.TabIndex = 2
        Me.BalconyLight.Text = "Balcony" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Light"
        Me.BalconyLight.UseVisualStyleBackColor = False
        '
        'Plug0
        '
        Me.Plug0.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Plug0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Plug0.Location = New System.Drawing.Point(494, 234)
        Me.Plug0.Name = "Plug0"
        Me.Plug0.Size = New System.Drawing.Size(62, 29)
        Me.Plug0.TabIndex = 1
        Me.Plug0.Text = "GN outlet"
        Me.Plug0.UseVisualStyleBackColor = False
        '
        'FluLight
        '
        Me.FluLight.BackColor = System.Drawing.Color.DarkGray
        Me.FluLight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FluLight.Location = New System.Drawing.Point(191, 237)
        Me.FluLight.Name = "FluLight"
        Me.FluLight.Size = New System.Drawing.Size(181, 27)
        Me.FluLight.TabIndex = 0
        Me.FluLight.Text = "Fluoroscent Light"
        Me.FluLight.UseVisualStyleBackColor = False
        '
        'rgb_led
        '
        Me.rgb_led.Controls.Add(Me.DisableLED)
        Me.rgb_led.Controls.Add(Me.LEDButtons)
        Me.rgb_led.Controls.Add(Me.EnableLED)
        Me.rgb_led.Location = New System.Drawing.Point(4, 22)
        Me.rgb_led.Name = "rgb_led"
        Me.rgb_led.Size = New System.Drawing.Size(1872, 777)
        Me.rgb_led.TabIndex = 3
        Me.rgb_led.Text = "RGB LED"
        Me.rgb_led.UseVisualStyleBackColor = True
        '
        'DisableLED
        '
        Me.DisableLED.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DisableLED.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DisableLED.ForeColor = System.Drawing.Color.White
        Me.DisableLED.Location = New System.Drawing.Point(185, 424)
        Me.DisableLED.Name = "DisableLED"
        Me.DisableLED.Size = New System.Drawing.Size(71, 46)
        Me.DisableLED.TabIndex = 19
        Me.DisableLED.Text = "Switch off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LED"
        Me.DisableLED.UseVisualStyleBackColor = False
        '
        'LEDButtons
        '
        Me.LEDButtons.Controls.Add(Me.LEDButton24)
        Me.LEDButtons.Controls.Add(Me.LEDButton20)
        Me.LEDButtons.Controls.Add(Me.LEDButton23)
        Me.LEDButtons.Controls.Add(Me.LEDButton19)
        Me.LEDButtons.Controls.Add(Me.LEDButton22)
        Me.LEDButtons.Controls.Add(Me.LEDButton18)
        Me.LEDButtons.Controls.Add(Me.LEDButton21)
        Me.LEDButtons.Controls.Add(Me.LEDButton17)
        Me.LEDButtons.Controls.Add(Me.LEDButton16)
        Me.LEDButtons.Controls.Add(Me.LEDButton15)
        Me.LEDButtons.Controls.Add(Me.LEDButton14)
        Me.LEDButtons.Controls.Add(Me.LEDButton13)
        Me.LEDButtons.Controls.Add(Me.LEDButton12)
        Me.LEDButtons.Controls.Add(Me.LEDButton11)
        Me.LEDButtons.Controls.Add(Me.LEDButton10)
        Me.LEDButtons.Controls.Add(Me.LEDButton09)
        Me.LEDButtons.Controls.Add(Me.LEDButton08)
        Me.LEDButtons.Controls.Add(Me.LEDButton07)
        Me.LEDButtons.Controls.Add(Me.LEDButton06)
        Me.LEDButtons.Controls.Add(Me.LEDButton05)
        Me.LEDButtons.Controls.Add(Me.LEDButton04)
        Me.LEDButtons.Controls.Add(Me.LEDButton03)
        Me.LEDButtons.Controls.Add(Me.LEDButton02)
        Me.LEDButtons.Controls.Add(Me.LEDButton01)
        Me.LEDButtons.Enabled = False
        Me.LEDButtons.Location = New System.Drawing.Point(87, 115)
        Me.LEDButtons.Name = "LEDButtons"
        Me.LEDButtons.Size = New System.Drawing.Size(257, 281)
        Me.LEDButtons.TabIndex = 18
        Me.LEDButtons.TabStop = False
        '
        'LEDButton24
        '
        Me.LEDButton24.BackColor = System.Drawing.Color.DarkGray
        Me.LEDButton24.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton24.Location = New System.Drawing.Point(175, 233)
        Me.LEDButton24.Name = "LEDButton24"
        Me.LEDButton24.Size = New System.Drawing.Size(70, 38)
        Me.LEDButton24.TabIndex = 33
        Me.LEDButton24.Text = "Smooth"
        Me.LEDButton24.UseVisualStyleBackColor = False
        '
        'LEDButton20
        '
        Me.LEDButton20.BackColor = System.Drawing.Color.DarkGray
        Me.LEDButton20.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton20.Location = New System.Drawing.Point(176, 189)
        Me.LEDButton20.Name = "LEDButton20"
        Me.LEDButton20.Size = New System.Drawing.Size(70, 38)
        Me.LEDButton20.TabIndex = 33
        Me.LEDButton20.Text = "Fade"
        Me.LEDButton20.UseVisualStyleBackColor = False
        '
        'LEDButton23
        '
        Me.LEDButton23.BackColor = System.Drawing.Color.Crimson
        Me.LEDButton23.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton23.ForeColor = System.Drawing.Color.White
        Me.LEDButton23.Location = New System.Drawing.Point(119, 233)
        Me.LEDButton23.Name = "LEDButton23"
        Me.LEDButton23.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton23.TabIndex = 35
        Me.LEDButton23.Text = "P"
        Me.LEDButton23.UseVisualStyleBackColor = False
        '
        'LEDButton19
        '
        Me.LEDButton19.BackColor = System.Drawing.Color.BlueViolet
        Me.LEDButton19.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton19.ForeColor = System.Drawing.Color.White
        Me.LEDButton19.Location = New System.Drawing.Point(120, 189)
        Me.LEDButton19.Name = "LEDButton19"
        Me.LEDButton19.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton19.TabIndex = 35
        Me.LEDButton19.Text = "V"
        Me.LEDButton19.UseVisualStyleBackColor = False
        '
        'LEDButton22
        '
        Me.LEDButton22.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.LEDButton22.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton22.ForeColor = System.Drawing.Color.Black
        Me.LEDButton22.Location = New System.Drawing.Point(64, 233)
        Me.LEDButton22.Name = "LEDButton22"
        Me.LEDButton22.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton22.TabIndex = 36
        Me.LEDButton22.Text = "DS"
        Me.LEDButton22.UseVisualStyleBackColor = False
        '
        'LEDButton18
        '
        Me.LEDButton18.BackColor = System.Drawing.Color.SkyBlue
        Me.LEDButton18.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton18.ForeColor = System.Drawing.Color.Black
        Me.LEDButton18.Location = New System.Drawing.Point(64, 189)
        Me.LEDButton18.Name = "LEDButton18"
        Me.LEDButton18.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton18.TabIndex = 36
        Me.LEDButton18.Text = "S"
        Me.LEDButton18.UseVisualStyleBackColor = False
        '
        'LEDButton21
        '
        Me.LEDButton21.BackColor = System.Drawing.Color.Yellow
        Me.LEDButton21.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton21.ForeColor = System.Drawing.Color.Black
        Me.LEDButton21.Location = New System.Drawing.Point(8, 233)
        Me.LEDButton21.Name = "LEDButton21"
        Me.LEDButton21.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton21.TabIndex = 34
        Me.LEDButton21.Text = "Y"
        Me.LEDButton21.UseVisualStyleBackColor = False
        '
        'LEDButton17
        '
        Me.LEDButton17.BackColor = System.Drawing.Color.Orange
        Me.LEDButton17.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton17.ForeColor = System.Drawing.Color.White
        Me.LEDButton17.Location = New System.Drawing.Point(8, 189)
        Me.LEDButton17.Name = "LEDButton17"
        Me.LEDButton17.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton17.TabIndex = 34
        Me.LEDButton17.Text = "DY"
        Me.LEDButton17.UseVisualStyleBackColor = False
        '
        'LEDButton16
        '
        Me.LEDButton16.BackColor = System.Drawing.Color.DarkGray
        Me.LEDButton16.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton16.Location = New System.Drawing.Point(176, 145)
        Me.LEDButton16.Name = "LEDButton16"
        Me.LEDButton16.Size = New System.Drawing.Size(70, 38)
        Me.LEDButton16.TabIndex = 29
        Me.LEDButton16.Text = "Strobe"
        Me.LEDButton16.UseVisualStyleBackColor = False
        '
        'LEDButton15
        '
        Me.LEDButton15.BackColor = System.Drawing.Color.Indigo
        Me.LEDButton15.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton15.ForeColor = System.Drawing.Color.White
        Me.LEDButton15.Location = New System.Drawing.Point(120, 145)
        Me.LEDButton15.Name = "LEDButton15"
        Me.LEDButton15.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton15.TabIndex = 31
        Me.LEDButton15.Text = "I"
        Me.LEDButton15.UseVisualStyleBackColor = False
        '
        'LEDButton14
        '
        Me.LEDButton14.BackColor = System.Drawing.Color.Aquamarine
        Me.LEDButton14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton14.ForeColor = System.Drawing.Color.Black
        Me.LEDButton14.Location = New System.Drawing.Point(64, 145)
        Me.LEDButton14.Name = "LEDButton14"
        Me.LEDButton14.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton14.TabIndex = 32
        Me.LEDButton14.Text = "C"
        Me.LEDButton14.UseVisualStyleBackColor = False
        '
        'LEDButton13
        '
        Me.LEDButton13.BackColor = System.Drawing.Color.Coral
        Me.LEDButton13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton13.ForeColor = System.Drawing.Color.White
        Me.LEDButton13.Location = New System.Drawing.Point(8, 145)
        Me.LEDButton13.Name = "LEDButton13"
        Me.LEDButton13.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton13.TabIndex = 30
        Me.LEDButton13.Text = "O"
        Me.LEDButton13.UseVisualStyleBackColor = False
        '
        'LEDButton12
        '
        Me.LEDButton12.BackColor = System.Drawing.Color.DarkGray
        Me.LEDButton12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton12.Location = New System.Drawing.Point(176, 101)
        Me.LEDButton12.Name = "LEDButton12"
        Me.LEDButton12.Size = New System.Drawing.Size(70, 38)
        Me.LEDButton12.TabIndex = 25
        Me.LEDButton12.Text = "Flash"
        Me.LEDButton12.UseVisualStyleBackColor = False
        '
        'LEDButton11
        '
        Me.LEDButton11.BackColor = System.Drawing.Color.SteelBlue
        Me.LEDButton11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton11.ForeColor = System.Drawing.Color.White
        Me.LEDButton11.Location = New System.Drawing.Point(120, 101)
        Me.LEDButton11.Name = "LEDButton11"
        Me.LEDButton11.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton11.TabIndex = 27
        Me.LEDButton11.Text = "LB"
        Me.LEDButton11.UseVisualStyleBackColor = False
        '
        'LEDButton10
        '
        Me.LEDButton10.BackColor = System.Drawing.Color.LimeGreen
        Me.LEDButton10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton10.ForeColor = System.Drawing.Color.White
        Me.LEDButton10.Location = New System.Drawing.Point(64, 101)
        Me.LEDButton10.Name = "LEDButton10"
        Me.LEDButton10.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton10.TabIndex = 28
        Me.LEDButton10.Text = "LG"
        Me.LEDButton10.UseVisualStyleBackColor = False
        '
        'LEDButton09
        '
        Me.LEDButton09.BackColor = System.Drawing.Color.OrangeRed
        Me.LEDButton09.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton09.ForeColor = System.Drawing.Color.White
        Me.LEDButton09.Location = New System.Drawing.Point(8, 101)
        Me.LEDButton09.Name = "LEDButton09"
        Me.LEDButton09.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton09.TabIndex = 26
        Me.LEDButton09.Text = "OR"
        Me.LEDButton09.UseVisualStyleBackColor = False
        '
        'LEDButton08
        '
        Me.LEDButton08.BackColor = System.Drawing.Color.White
        Me.LEDButton08.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton08.Location = New System.Drawing.Point(175, 57)
        Me.LEDButton08.Name = "LEDButton08"
        Me.LEDButton08.Size = New System.Drawing.Size(70, 38)
        Me.LEDButton08.TabIndex = 21
        Me.LEDButton08.Text = "W"
        Me.LEDButton08.UseVisualStyleBackColor = False
        '
        'LEDButton07
        '
        Me.LEDButton07.BackColor = System.Drawing.Color.Blue
        Me.LEDButton07.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton07.ForeColor = System.Drawing.Color.White
        Me.LEDButton07.Location = New System.Drawing.Point(120, 57)
        Me.LEDButton07.Name = "LEDButton07"
        Me.LEDButton07.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton07.TabIndex = 24
        Me.LEDButton07.Text = "B"
        Me.LEDButton07.UseVisualStyleBackColor = False
        '
        'LEDButton06
        '
        Me.LEDButton06.BackColor = System.Drawing.Color.Green
        Me.LEDButton06.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton06.ForeColor = System.Drawing.Color.White
        Me.LEDButton06.Location = New System.Drawing.Point(64, 57)
        Me.LEDButton06.Name = "LEDButton06"
        Me.LEDButton06.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton06.TabIndex = 24
        Me.LEDButton06.Text = "G"
        Me.LEDButton06.UseVisualStyleBackColor = False
        '
        'LEDButton05
        '
        Me.LEDButton05.BackColor = System.Drawing.Color.Red
        Me.LEDButton05.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton05.ForeColor = System.Drawing.Color.White
        Me.LEDButton05.Location = New System.Drawing.Point(8, 57)
        Me.LEDButton05.Name = "LEDButton05"
        Me.LEDButton05.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton05.TabIndex = 23
        Me.LEDButton05.Text = "R"
        Me.LEDButton05.UseVisualStyleBackColor = False
        '
        'LEDButton04
        '
        Me.LEDButton04.BackColor = System.Drawing.Color.Brown
        Me.LEDButton04.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton04.ForeColor = System.Drawing.Color.White
        Me.LEDButton04.Location = New System.Drawing.Point(176, 13)
        Me.LEDButton04.Name = "LEDButton04"
        Me.LEDButton04.Size = New System.Drawing.Size(69, 38)
        Me.LEDButton04.TabIndex = 22
        Me.LEDButton04.Text = "On"
        Me.LEDButton04.UseVisualStyleBackColor = False
        '
        'LEDButton03
        '
        Me.LEDButton03.BackColor = System.Drawing.Color.Black
        Me.LEDButton03.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton03.ForeColor = System.Drawing.Color.White
        Me.LEDButton03.Location = New System.Drawing.Point(120, 13)
        Me.LEDButton03.Name = "LEDButton03"
        Me.LEDButton03.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton03.TabIndex = 21
        Me.LEDButton03.Text = "Off"
        Me.LEDButton03.UseVisualStyleBackColor = False
        '
        'LEDButton02
        '
        Me.LEDButton02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LEDButton02.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton02.Location = New System.Drawing.Point(64, 13)
        Me.LEDButton02.Name = "LEDButton02"
        Me.LEDButton02.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton02.TabIndex = 20
        Me.LEDButton02.Text = "-"
        Me.LEDButton02.UseVisualStyleBackColor = False
        '
        'LEDButton01
        '
        Me.LEDButton01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LEDButton01.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LEDButton01.Location = New System.Drawing.Point(6, 13)
        Me.LEDButton01.Name = "LEDButton01"
        Me.LEDButton01.Size = New System.Drawing.Size(50, 38)
        Me.LEDButton01.TabIndex = 19
        Me.LEDButton01.Text = "+"
        Me.LEDButton01.UseVisualStyleBackColor = False
        '
        'EnableLED
        '
        Me.EnableLED.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EnableLED.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnableLED.Location = New System.Drawing.Point(142, 36)
        Me.EnableLED.Name = "EnableLED"
        Me.EnableLED.Size = New System.Drawing.Size(157, 46)
        Me.EnableLED.TabIndex = 17
        Me.EnableLED.Text = "Enable RGB LED"
        Me.EnableLED.UseVisualStyleBackColor = False
        '
        'Alarm
        '
        Me.Alarm.Controls.Add(Me.SnoozeLabel)
        Me.Alarm.Controls.Add(Me.MusicAlarmLabel)
        Me.Alarm.Controls.Add(Me.AlarmList)
        Me.Alarm.Controls.Add(Me.GroupBox1)
        Me.Alarm.Location = New System.Drawing.Point(4, 22)
        Me.Alarm.Name = "Alarm"
        Me.Alarm.Size = New System.Drawing.Size(1872, 777)
        Me.Alarm.TabIndex = 4
        Me.Alarm.Text = "Alarm"
        Me.Alarm.UseVisualStyleBackColor = True
        '
        'SnoozeLabel
        '
        Me.SnoozeLabel.AutoSize = True
        Me.SnoozeLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SnoozeLabel.ForeColor = System.Drawing.Color.Blue
        Me.SnoozeLabel.Location = New System.Drawing.Point(341, 148)
        Me.SnoozeLabel.Name = "SnoozeLabel"
        Me.SnoozeLabel.Padding = New System.Windows.Forms.Padding(7)
        Me.SnoozeLabel.Size = New System.Drawing.Size(63, 27)
        Me.SnoozeLabel.TabIndex = 39
        Me.SnoozeLabel.Text = "Snoozed"
        Me.SnoozeLabel.Visible = False
        '
        'MusicAlarmLabel
        '
        Me.MusicAlarmLabel.AutoSize = True
        Me.MusicAlarmLabel.Location = New System.Drawing.Point(341, 118)
        Me.MusicAlarmLabel.Name = "MusicAlarmLabel"
        Me.MusicAlarmLabel.Size = New System.Drawing.Size(63, 13)
        Me.MusicAlarmLabel.TabIndex = 38
        Me.MusicAlarmLabel.Text = "music1.wav"
        '
        'AlarmList
        '
        Me.AlarmList.FormattingEnabled = True
        Me.AlarmList.Items.AddRange(New Object() {"Alarms set : 0"})
        Me.AlarmList.Location = New System.Drawing.Point(65, 76)
        Me.AlarmList.Name = "AlarmList"
        Me.AlarmList.Size = New System.Drawing.Size(197, 95)
        Me.AlarmList.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SnoozeAlarm)
        Me.GroupBox1.Controls.Add(Me.BrowseAlarm)
        Me.GroupBox1.Controls.Add(Me.StopAlarm)
        Me.GroupBox1.Controls.Add(Me.DeleteAlarm)
        Me.GroupBox1.Controls.Add(Me.HourAlarm)
        Me.GroupBox1.Controls.Add(Me.MinAlarm)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.AmPmAlarm)
        Me.GroupBox1.Controls.Add(Me.AddAlarm)
        Me.GroupBox1.Controls.Add(Me.TestAlarm)
        Me.GroupBox1.Location = New System.Drawing.Point(65, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 123)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Set Alarm"
        '
        'SnoozeAlarm
        '
        Me.SnoozeAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SnoozeAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SnoozeAlarm.Location = New System.Drawing.Point(286, 72)
        Me.SnoozeAlarm.Name = "SnoozeAlarm"
        Me.SnoozeAlarm.Size = New System.Drawing.Size(64, 33)
        Me.SnoozeAlarm.TabIndex = 37
        Me.SnoozeAlarm.Text = "Snooze"
        Me.SnoozeAlarm.UseVisualStyleBackColor = False
        '
        'BrowseAlarm
        '
        Me.BrowseAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BrowseAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BrowseAlarm.Location = New System.Drawing.Point(359, 24)
        Me.BrowseAlarm.Name = "BrowseAlarm"
        Me.BrowseAlarm.Size = New System.Drawing.Size(60, 33)
        Me.BrowseAlarm.TabIndex = 36
        Me.BrowseAlarm.Text = "Browse"
        Me.BrowseAlarm.UseVisualStyleBackColor = False
        '
        'StopAlarm
        '
        Me.StopAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.StopAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StopAlarm.Location = New System.Drawing.Point(359, 72)
        Me.StopAlarm.Name = "StopAlarm"
        Me.StopAlarm.Size = New System.Drawing.Size(60, 33)
        Me.StopAlarm.TabIndex = 27
        Me.StopAlarm.Text = "Stop"
        Me.StopAlarm.UseVisualStyleBackColor = False
        '
        'DeleteAlarm
        '
        Me.DeleteAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DeleteAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DeleteAlarm.Location = New System.Drawing.Point(289, 24)
        Me.DeleteAlarm.Name = "DeleteAlarm"
        Me.DeleteAlarm.Size = New System.Drawing.Size(60, 33)
        Me.DeleteAlarm.TabIndex = 26
        Me.DeleteAlarm.Text = "Remove"
        Me.DeleteAlarm.UseVisualStyleBackColor = False
        '
        'HourAlarm
        '
        Me.HourAlarm.Location = New System.Drawing.Point(20, 24)
        Me.HourAlarm.Maximum = New Decimal(New Integer() {11, 0, 0, 0})
        Me.HourAlarm.Name = "HourAlarm"
        Me.HourAlarm.Size = New System.Drawing.Size(50, 20)
        Me.HourAlarm.TabIndex = 18
        '
        'MinAlarm
        '
        Me.MinAlarm.Location = New System.Drawing.Point(76, 24)
        Me.MinAlarm.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.MinAlarm.Name = "MinAlarm"
        Me.MinAlarm.Size = New System.Drawing.Size(50, 20)
        Me.MinAlarm.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SnoozeTimer0)
        Me.GroupBox2.Controls.Add(Me.SnoozeTimer2)
        Me.GroupBox2.Controls.Add(Me.SnoozeTimer1)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 57)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Snooze time_out"
        '
        'SnoozeTimer0
        '
        Me.SnoozeTimer0.AutoSize = True
        Me.SnoozeTimer0.Checked = True
        Me.SnoozeTimer0.Location = New System.Drawing.Point(8, 22)
        Me.SnoozeTimer0.Name = "SnoozeTimer0"
        Me.SnoozeTimer0.Size = New System.Drawing.Size(53, 17)
        Me.SnoozeTimer0.TabIndex = 6
        Me.SnoozeTimer0.TabStop = True
        Me.SnoozeTimer0.Text = "5 min."
        Me.SnoozeTimer0.UseVisualStyleBackColor = True
        '
        'SnoozeTimer2
        '
        Me.SnoozeTimer2.AutoSize = True
        Me.SnoozeTimer2.Location = New System.Drawing.Point(120, 22)
        Me.SnoozeTimer2.Name = "SnoozeTimer2"
        Me.SnoozeTimer2.Size = New System.Drawing.Size(59, 17)
        Me.SnoozeTimer2.TabIndex = 8
        Me.SnoozeTimer2.TabStop = True
        Me.SnoozeTimer2.Text = "20 min."
        Me.SnoozeTimer2.UseVisualStyleBackColor = True
        '
        'SnoozeTimer1
        '
        Me.SnoozeTimer1.AutoSize = True
        Me.SnoozeTimer1.Location = New System.Drawing.Point(61, 22)
        Me.SnoozeTimer1.Name = "SnoozeTimer1"
        Me.SnoozeTimer1.Size = New System.Drawing.Size(59, 17)
        Me.SnoozeTimer1.TabIndex = 7
        Me.SnoozeTimer1.Text = "10 min."
        Me.SnoozeTimer1.UseVisualStyleBackColor = True
        '
        'AmPmAlarm
        '
        Me.AmPmAlarm.FormattingEnabled = True
        Me.AmPmAlarm.Items.AddRange(New Object() {"AM", "PM"})
        Me.AmPmAlarm.Location = New System.Drawing.Point(132, 23)
        Me.AmPmAlarm.Name = "AmPmAlarm"
        Me.AmPmAlarm.Size = New System.Drawing.Size(60, 21)
        Me.AmPmAlarm.TabIndex = 20
        '
        'AddAlarm
        '
        Me.AddAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.AddAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AddAlarm.Location = New System.Drawing.Point(216, 24)
        Me.AddAlarm.Name = "AddAlarm"
        Me.AddAlarm.Size = New System.Drawing.Size(60, 33)
        Me.AddAlarm.TabIndex = 21
        Me.AddAlarm.Text = "Add"
        Me.AddAlarm.UseVisualStyleBackColor = False
        '
        'TestAlarm
        '
        Me.TestAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TestAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TestAlarm.Location = New System.Drawing.Point(216, 72)
        Me.TestAlarm.Name = "TestAlarm"
        Me.TestAlarm.Size = New System.Drawing.Size(60, 33)
        Me.TestAlarm.TabIndex = 23
        Me.TestAlarm.Text = "Test"
        Me.TestAlarm.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PressureData)
        Me.TabPage1.Controls.Add(Me.HumidityData)
        Me.TabPage1.Controls.Add(Me.TemperatureData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1872, 777)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Climate"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PressureData
        '
        ChartArea6.Name = "ChartArea1"
        Me.PressureData.ChartAreas.Add(ChartArea6)
        Legend6.Name = "Legend1"
        Me.PressureData.Legends.Add(Legend6)
        Me.PressureData.Location = New System.Drawing.Point(969, 12)
        Me.PressureData.Name = "PressureData"
        Me.PressureData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Series6.ChartArea = "ChartArea1"
        Series6.Legend = "Legend1"
        Series6.Name = "Air Pressure (Pa)"
        Series6.YValuesPerPoint = 4
        Me.PressureData.Series.Add(Series6)
        Me.PressureData.Size = New System.Drawing.Size(900, 350)
        Me.PressureData.TabIndex = 36
        Me.PressureData.Text = "Power Histogram"
        '
        'HumidityData
        '
        ChartArea7.Name = "ChartArea1"
        Me.HumidityData.ChartAreas.Add(ChartArea7)
        Legend7.Name = "Legend1"
        Me.HumidityData.Legends.Add(Legend7)
        Me.HumidityData.Location = New System.Drawing.Point(14, 414)
        Me.HumidityData.Name = "HumidityData"
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "Humidity"
        Series7.YValuesPerPoint = 4
        Me.HumidityData.Series.Add(Series7)
        Me.HumidityData.Size = New System.Drawing.Size(900, 350)
        Me.HumidityData.TabIndex = 35
        Me.HumidityData.Text = "Power Histogram"
        '
        'TemperatureData
        '
        ChartArea8.Name = "ChartArea1"
        Me.TemperatureData.ChartAreas.Add(ChartArea8)
        Legend8.Name = "Legend1"
        Me.TemperatureData.Legends.Add(Legend8)
        Me.TemperatureData.Location = New System.Drawing.Point(14, 12)
        Me.TemperatureData.Name = "TemperatureData"
        Me.TemperatureData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "Temperature (^C)"
        Series8.YValuesPerPoint = 4
        Me.TemperatureData.Series.Add(Series8)
        Me.TemperatureData.Size = New System.Drawing.Size(900, 350)
        Me.TemperatureData.TabIndex = 34
        Me.TemperatureData.Text = "Power Histogram"
        '
        'MotionDetectTimer
        '
        Me.MotionDetectTimer.Interval = 1000
        '
        'LightingsTimer
        '
        Me.LightingsTimer.Enabled = True
        Me.LightingsTimer.Interval = 1000
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Schedule"
        '
        'SpeechCheck
        '
        Me.SpeechCheck.AutoSize = True
        Me.SpeechCheck.ForeColor = System.Drawing.Color.Green
        Me.SpeechCheck.Location = New System.Drawing.Point(1527, 41)
        Me.SpeechCheck.Name = "SpeechCheck"
        Me.SpeechCheck.Size = New System.Drawing.Size(97, 17)
        Me.SpeechCheck.TabIndex = 22
        Me.SpeechCheck.Text = "Enable speech"
        Me.SpeechCheck.UseVisualStyleBackColor = True
        '
        'SpeechTimer
        '
        Me.SpeechTimer.Enabled = True
        '
        'ReconnectTimer
        '
        Me.ReconnectTimer.Enabled = True
        Me.ReconnectTimer.Interval = 20000
        '
        'StreamDebugIdx
        '
        Me.StreamDebugIdx.Location = New System.Drawing.Point(753, 949)
        Me.StreamDebugIdx.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.StreamDebugIdx.Name = "StreamDebugIdx"
        Me.StreamDebugIdx.Size = New System.Drawing.Size(48, 20)
        Me.StreamDebugIdx.TabIndex = 32
        '
        'StreamIdx
        '
        Me.StreamIdx.Location = New System.Drawing.Point(165, 960)
        Me.StreamIdx.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.StreamIdx.Name = "StreamIdx"
        Me.StreamIdx.Size = New System.Drawing.Size(48, 20)
        Me.StreamIdx.TabIndex = 33
        '
        'ConnectCheck
        '
        Me.ConnectCheck.AutoSize = True
        Me.ConnectCheck.Checked = True
        Me.ConnectCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ConnectCheck.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ConnectCheck.Location = New System.Drawing.Point(165, 927)
        Me.ConnectCheck.Name = "ConnectCheck"
        Me.ConnectCheck.Size = New System.Drawing.Size(37, 17)
        Me.ConnectCheck.TabIndex = 22
        Me.ConnectCheck.Text = "All"
        Me.ConnectCheck.UseVisualStyleBackColor = True
        '
        'LEDTimer
        '
        Me.LEDTimer.Interval = 3600000
        '
        'Alcohol
        '
        Me.Alcohol.AutoSize = True
        Me.Alcohol.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Alcohol.Location = New System.Drawing.Point(587, 9)
        Me.Alcohol.Name = "Alcohol"
        Me.Alcohol.Padding = New System.Windows.Forms.Padding(10)
        Me.Alcohol.Size = New System.Drawing.Size(68, 33)
        Me.Alcohol.TabIndex = 34
        Me.Alcohol.Text = "Alcohol :"
        '
        'CO
        '
        Me.CO.AutoSize = True
        Me.CO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CO.Location = New System.Drawing.Point(729, 9)
        Me.CO.Name = "CO"
        Me.CO.Padding = New System.Windows.Forms.Padding(10)
        Me.CO.Size = New System.Drawing.Size(48, 33)
        Me.CO.TabIndex = 35
        Me.CO.Text = "CO :"
        '
        'RealTime
        '
        Me.RealTime.AutoSize = True
        Me.RealTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RealTime.ForeColor = System.Drawing.Color.Red
        Me.RealTime.Location = New System.Drawing.Point(1148, 29)
        Me.RealTime.Name = "RealTime"
        Me.RealTime.Padding = New System.Windows.Forms.Padding(5)
        Me.RealTime.Size = New System.Drawing.Size(147, 23)
        Me.RealTime.TabIndex = 39
        Me.RealTime.Text = "Current Time : hh.mm.ss pm"
        '
        'Timer500ms
        '
        Me.Timer500ms.Enabled = True
        Me.Timer500ms.Interval = 500
        '
        'TimerAlarm
        '
        Me.TimerAlarm.Interval = 300000
        '
        'MusicFileBrowse
        '
        Me.MusicFileBrowse.FileName = "OpenFileDialog1"
        '
        'Timer1s
        '
        Me.Timer1s.Enabled = True
        Me.Timer1s.Interval = 1000
        '
        'Smoke
        '
        Me.Smoke.AutoSize = True
        Me.Smoke.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Smoke.Location = New System.Drawing.Point(846, 9)
        Me.Smoke.Name = "Smoke"
        Me.Smoke.Padding = New System.Windows.Forms.Padding(10)
        Me.Smoke.Size = New System.Drawing.Size(66, 33)
        Me.Smoke.TabIndex = 40
        Me.Smoke.Text = "Smoke :"
        '
        'ControlRefreshTimer
        '
        Me.ControlRefreshTimer.Enabled = True
        '
        'ClimateTimer
        '
        Me.ClimateTimer.Enabled = True
        Me.ClimateTimer.Interval = 300000
        '
        'homeCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1904, 1011)
        Me.Controls.Add(Me.Smoke)
        Me.Controls.Add(Me.RealTime)
        Me.Controls.Add(Me.CO)
        Me.Controls.Add(Me.Alcohol)
        Me.Controls.Add(Me.ConnectCheck)
        Me.Controls.Add(Me.StreamIdx)
        Me.Controls.Add(Me.StreamDebugIdx)
        Me.Controls.Add(Me.SpeechCheck)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.Toggleled)
        Me.Controls.Add(Me.Pressure)
        Me.Controls.Add(Me.Humidity)
        Me.Controls.Add(Me.Fetch)
        Me.Controls.Add(Me.Temperature)
        Me.Controls.Add(Me.Packet)
        Me.Controls.Add(Me.debugButton)
        Me.Controls.Add(Me.Connect)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "homeCtrl"
        Me.Text = "Automata"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Tabs.ResumeLayout(False)
        Me.settingsPage.ResumeLayout(False)
        Me.settingsPage.PerformLayout()
        Me.SurveillanceGrp.ResumeLayout(False)
        CType(Me.MotionActDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.room.ResumeLayout(False)
        Me.room.PerformLayout()
        CType(Me.pwHist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SettingsGrp.ResumeLayout(False)
        Me.SettingsGrp.PerformLayout()
        Me.TimerGrp.ResumeLayout(False)
        CType(Me.hr2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sec2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.min2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EndTimeGrp.ResumeLayout(False)
        CType(Me.hr1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sec1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.min1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StartTimeGrp.ResumeLayout(False)
        CType(Me.hr0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sec0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.min0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgb_led.ResumeLayout(False)
        Me.LEDButtons.ResumeLayout(False)
        Me.Alarm.ResumeLayout(False)
        Me.Alarm.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.HourAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PressureData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HumidityData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TemperatureData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StreamDebugIdx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StreamIdx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fetch As Button
    Friend WithEvents Temperature As Label
    Friend WithEvents Packet As TextBox
    Friend WithEvents debugButton As Button
    Friend WithEvents Connect As Button
    Friend WithEvents Timer20s As Timer
    Friend WithEvents Pressure As Label
    Friend WithEvents Humidity As Label
    Friend WithEvents Toggleled As Button
    Friend WithEvents Tabs As TabControl
    Friend WithEvents settingsPage As TabPage
    Friend WithEvents room As TabPage
    Friend WithEvents MonitorStatus As TextBox
    Friend WithEvents MotionActDelay As TrackBar
    Friend WithEvents MotionActDelayLabel As Label
    Friend WithEvents MotionDetectCheck As CheckBox
    Friend WithEvents AudioCheck As CheckBox
    Friend WithEvents VideoCheck As CheckBox
    Friend WithEvents Plug0 As Button
    Friend WithEvents FluLight As Button
    Friend WithEvents Fan As Button
    Friend WithEvents LightBulb As Button
    Friend WithEvents BalconyLight As Button
    Friend WithEvents SelectBalconyLight As RadioButton
    Friend WithEvents SelectPlug0 As RadioButton
    Friend WithEvents SelectFluLight As RadioButton
    Friend WithEvents SelectFan As RadioButton
    Friend WithEvents SelectLightBulb As RadioButton
    Friend WithEvents LightingSettings As Button
    Friend WithEvents StartTimeGrp As GroupBox
    Friend WithEvents hr0 As NumericUpDown
    Friend WithEvents sec0 As NumericUpDown
    Friend WithEvents min0 As NumericUpDown
    Friend WithEvents EndTimeGrp As GroupBox
    Friend WithEvents hr1 As NumericUpDown
    Friend WithEvents sec1 As NumericUpDown
    Friend WithEvents min1 As NumericUpDown
    Friend WithEvents TimerGrp As GroupBox
    Friend WithEvents hr2 As NumericUpDown
    Friend WithEvents sec2 As NumericUpDown
    Friend WithEvents min2 As NumericUpDown
    Friend WithEvents ToggleLightings As CheckBox
    Friend WithEvents EnableLightSchedule As CheckBox
    Friend WithEvents MotionDetectPowerOn As CheckBox
    Friend WithEvents MotionDetectTimer As Timer
    Friend WithEvents SelectPlug1 As RadioButton
    Friend WithEvents Plug1 As Button
    Friend WithEvents LightingsTimer As Timer
    Friend WithEvents SettingsGrp As GroupBox
    Friend WithEvents ResetSchedule As Button
    Friend WithEvents pwHist As DataVisualization.Charting.Chart
    Friend WithEvents ShowPowerHist As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ClearHist As Button
    Friend WithEvents ClearMonitorStatus As Button
    Friend WithEvents SpeechCheck As CheckBox
    Friend WithEvents SpeechTimer As Timer
    Friend WithEvents ReconnectTimer As Timer
    Friend WithEvents StreamDebugIdx As NumericUpDown
    Friend WithEvents rgb_led As TabPage
    Friend WithEvents StreamIdx As NumericUpDown
    Friend WithEvents ConnectCheck As CheckBox
    Friend WithEvents LEDTimer As Timer
    Friend WithEvents Alcohol As Label
    Friend WithEvents CO As Label
    Friend WithEvents Alarm As TabPage
    Friend WithEvents MusicAlarmLabel As Label
    Friend WithEvents AlarmList As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SnoozeAlarm As Button
    Friend WithEvents BrowseAlarm As Button
    Friend WithEvents StopAlarm As Button
    Friend WithEvents DeleteAlarm As Button
    Friend WithEvents HourAlarm As NumericUpDown
    Friend WithEvents MinAlarm As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SnoozeTimer0 As RadioButton
    Friend WithEvents SnoozeTimer2 As RadioButton
    Friend WithEvents SnoozeTimer1 As RadioButton
    Friend WithEvents AmPmAlarm As ComboBox
    Friend WithEvents AddAlarm As Button
    Friend WithEvents TestAlarm As Button
    Friend WithEvents RealTime As Label
    Friend WithEvents Timer500ms As Timer
    Friend WithEvents TimerAlarm As Timer
    Friend WithEvents MusicFileBrowse As OpenFileDialog
    Friend WithEvents Timer1s As Timer
    Friend WithEvents Smoke As Label
    Friend WithEvents DisableLED As Button
    Friend WithEvents LEDButtons As GroupBox
    Friend WithEvents LEDButton24 As Button
    Friend WithEvents LEDButton20 As Button
    Friend WithEvents LEDButton23 As Button
    Friend WithEvents LEDButton19 As Button
    Friend WithEvents LEDButton22 As Button
    Friend WithEvents LEDButton18 As Button
    Friend WithEvents LEDButton21 As Button
    Friend WithEvents LEDButton17 As Button
    Friend WithEvents LEDButton16 As Button
    Friend WithEvents LEDButton15 As Button
    Friend WithEvents LEDButton14 As Button
    Friend WithEvents LEDButton13 As Button
    Friend WithEvents LEDButton12 As Button
    Friend WithEvents LEDButton11 As Button
    Friend WithEvents LEDButton10 As Button
    Friend WithEvents LEDButton09 As Button
    Friend WithEvents LEDButton08 As Button
    Friend WithEvents LEDButton07 As Button
    Friend WithEvents LEDButton06 As Button
    Friend WithEvents LEDButton05 As Button
    Friend WithEvents LEDButton04 As Button
    Friend WithEvents LEDButton03 As Button
    Friend WithEvents LEDButton02 As Button
    Friend WithEvents LEDButton01 As Button
    Friend WithEvents EnableLED As Button
    Friend WithEvents Recordings As Button
    Friend WithEvents Record As Button
    Friend WithEvents LiveFeed As Button
    Friend WithEvents SurveillanceGrp As GroupBox
    Friend WithEvents OpenDir As Button
    Friend WithEvents AudioOpen As Button
    Friend WithEvents VideoOpen As Button
    Friend WithEvents secList As ComboBox
    Friend WithEvents minList As ComboBox
    Friend WithEvents hrList As ComboBox
    Friend WithEvents dayList As ComboBox
    Friend WithEvents monthList As ComboBox
    Friend WithEvents yrList As ComboBox
    Friend WithEvents Surveillance As Button
    Friend WithEvents SnoozeLabel As Label
    Friend WithEvents DisableLightSchedule As CheckBox
    Friend WithEvents ControlRefreshTimer As Timer
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TemperatureData As DataVisualization.Charting.Chart
    Friend WithEvents ClimateTimer As Timer
    Friend WithEvents PressureData As DataVisualization.Charting.Chart
    Friend WithEvents HumidityData As DataVisualization.Charting.Chart
End Class
