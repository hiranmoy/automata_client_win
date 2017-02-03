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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Fetch = New System.Windows.Forms.Button()
        Me.Temperature = New System.Windows.Forms.Label()
        Me.Packet = New System.Windows.Forms.TextBox()
        Me.debugButton = New System.Windows.Forms.Button()
        Me.Connect = New System.Windows.Forms.Button()
        Me.Timer10s = New System.Windows.Forms.Timer(Me.components)
        Me.Pressure = New System.Windows.Forms.Label()
        Me.Humidity = New System.Windows.Forms.Label()
        Me.Toggleled = New System.Windows.Forms.Button()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.settingsPage = New System.Windows.Forms.TabPage()
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
        Me.surveilance = New System.Windows.Forms.TabPage()
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
        Me.MotionDetectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LightingsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SpeechCheck = New System.Windows.Forms.CheckBox()
        Me.SpeechTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ReconnectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TcpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StreamIdx = New System.Windows.Forms.NumericUpDown()
        Me.rgb_led = New System.Windows.Forms.TabPage()
        Me.enableLED = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Tabs.SuspendLayout()
        Me.settingsPage.SuspendLayout()
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
        Me.surveilance.SuspendLayout()
        Me.SurveillanceGrp.SuspendLayout()
        CType(Me.StreamIdx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgb_led.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fetch
        '
        Me.Fetch.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Fetch.Enabled = False
        Me.Fetch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Fetch.Location = New System.Drawing.Point(280, 653)
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
        Me.Packet.Location = New System.Drawing.Point(630, 667)
        Me.Packet.Name = "Packet"
        Me.Packet.Size = New System.Drawing.Size(143, 20)
        Me.Packet.TabIndex = 18
        '
        'debugButton
        '
        Me.debugButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.debugButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.debugButton.Location = New System.Drawing.Point(449, 653)
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
        Me.Connect.Location = New System.Drawing.Point(12, 653)
        Me.Connect.Name = "Connect"
        Me.Connect.Size = New System.Drawing.Size(80, 46)
        Me.Connect.TabIndex = 16
        Me.Connect.Text = "connect"
        Me.Connect.UseVisualStyleBackColor = False
        '
        'Timer10s
        '
        Me.Timer10s.Interval = 10000
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
        Me.Toggleled.Location = New System.Drawing.Point(554, 9)
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
        Me.Tabs.Controls.Add(Me.surveilance)
        Me.Tabs.Controls.Add(Me.rgb_led)
        Me.Tabs.Enabled = False
        Me.Tabs.Location = New System.Drawing.Point(12, 94)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1630, 520)
        Me.Tabs.TabIndex = 31
        '
        'settingsPage
        '
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
        Me.settingsPage.Size = New System.Drawing.Size(1622, 494)
        Me.settingsPage.TabIndex = 0
        Me.settingsPage.Text = "Preferences"
        Me.settingsPage.UseVisualStyleBackColor = True
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
        Me.room.Size = New System.Drawing.Size(1622, 494)
        Me.room.TabIndex = 1
        Me.room.Text = "Lightings"
        '
        'ClearHist
        '
        Me.ClearHist.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClearHist.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearHist.Location = New System.Drawing.Point(1504, 429)
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
        Me.ShowPowerHist.Location = New System.Drawing.Point(669, 10)
        Me.ShowPowerHist.Name = "ShowPowerHist"
        Me.ShowPowerHist.Size = New System.Drawing.Size(70, 454)
        Me.ShowPowerHist.TabIndex = 34
        Me.ShowPowerHist.Text = "Power " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Profile"
        Me.ShowPowerHist.UseVisualStyleBackColor = False
        '
        'pwHist
        '
        ChartArea3.Name = "ChartArea1"
        Me.pwHist.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.pwHist.Legends.Add(Legend3)
        Me.pwHist.Location = New System.Drawing.Point(745, 18)
        Me.pwHist.Name = "pwHist"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Power on Time"
        Series3.YValuesPerPoint = 4
        Me.pwHist.Series.Add(Series3)
        Me.pwHist.Size = New System.Drawing.Size(871, 446)
        Me.pwHist.TabIndex = 33
        Me.pwHist.Text = "Power Histogram"
        '
        'SettingsGrp
        '
        Me.SettingsGrp.Controls.Add(Me.ResetSchedule)
        Me.SettingsGrp.Controls.Add(Me.TimerGrp)
        Me.SettingsGrp.Controls.Add(Me.ToggleLightings)
        Me.SettingsGrp.Controls.Add(Me.EnableLightSchedule)
        Me.SettingsGrp.Controls.Add(Me.EndTimeGrp)
        Me.SettingsGrp.Controls.Add(Me.StartTimeGrp)
        Me.SettingsGrp.Enabled = False
        Me.SettingsGrp.Location = New System.Drawing.Point(4, 329)
        Me.SettingsGrp.Name = "SettingsGrp"
        Me.SettingsGrp.Size = New System.Drawing.Size(644, 150)
        Me.SettingsGrp.TabIndex = 21
        Me.SettingsGrp.TabStop = False
        '
        'ResetSchedule
        '
        Me.ResetSchedule.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ResetSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ResetSchedule.Location = New System.Drawing.Point(563, 31)
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
        Me.LightingSettings.Size = New System.Drawing.Size(646, 27)
        Me.LightingSettings.TabIndex = 5
        Me.LightingSettings.Text = "Settings"
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
        'surveilance
        '
        Me.surveilance.Controls.Add(Me.Recordings)
        Me.surveilance.Controls.Add(Me.Record)
        Me.surveilance.Controls.Add(Me.LiveFeed)
        Me.surveilance.Controls.Add(Me.SurveillanceGrp)
        Me.surveilance.Controls.Add(Me.Surveillance)
        Me.surveilance.Location = New System.Drawing.Point(4, 22)
        Me.surveilance.Name = "surveilance"
        Me.surveilance.Size = New System.Drawing.Size(1622, 494)
        Me.surveilance.TabIndex = 2
        Me.surveilance.Text = "Surveillance"
        Me.surveilance.UseVisualStyleBackColor = True
        '
        'Recordings
        '
        Me.Recordings.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Recordings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Recordings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recordings.ForeColor = System.Drawing.Color.Blue
        Me.Recordings.Location = New System.Drawing.Point(195, 76)
        Me.Recordings.Name = "Recordings"
        Me.Recordings.Size = New System.Drawing.Size(135, 46)
        Me.Recordings.TabIndex = 22
        Me.Recordings.Text = "Load" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Recordings"
        Me.Recordings.UseVisualStyleBackColor = False
        '
        'Record
        '
        Me.Record.BackColor = System.Drawing.Color.PaleGreen
        Me.Record.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Record.Location = New System.Drawing.Point(443, 253)
        Me.Record.Name = "Record"
        Me.Record.Size = New System.Drawing.Size(86, 47)
        Me.Record.TabIndex = 21
        Me.Record.Text = "Record"
        Me.Record.UseVisualStyleBackColor = False
        '
        'LiveFeed
        '
        Me.LiveFeed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LiveFeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LiveFeed.Location = New System.Drawing.Point(443, 159)
        Me.LiveFeed.Name = "LiveFeed"
        Me.LiveFeed.Size = New System.Drawing.Size(86, 47)
        Me.LiveFeed.TabIndex = 20
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
        Me.SurveillanceGrp.Location = New System.Drawing.Point(48, 140)
        Me.SurveillanceGrp.Name = "SurveillanceGrp"
        Me.SurveillanceGrp.Size = New System.Drawing.Size(296, 187)
        Me.SurveillanceGrp.TabIndex = 12
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
        Me.Surveillance.Location = New System.Drawing.Point(48, 76)
        Me.Surveillance.Name = "Surveillance"
        Me.Surveillance.Size = New System.Drawing.Size(135, 46)
        Me.Surveillance.TabIndex = 11
        Me.Surveillance.Text = "Load" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Surveillance cllips"
        Me.Surveillance.UseVisualStyleBackColor = False
        '
        'MotionDetectTimer
        '
        Me.MotionDetectTimer.Interval = 1000
        '
        'LightingsTimer
        '
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
        Me.SpeechCheck.Location = New System.Drawing.Point(736, 35)
        Me.SpeechCheck.Name = "SpeechCheck"
        Me.SpeechCheck.Size = New System.Drawing.Size(97, 17)
        Me.SpeechCheck.TabIndex = 22
        Me.SpeechCheck.Text = "Enable speech"
        Me.SpeechCheck.UseVisualStyleBackColor = True
        '
        'SpeechTimer
        '
        '
        'ReconnectTimer
        '
        Me.ReconnectTimer.Interval = 60000
        '
        'TcpTimer
        '
        Me.TcpTimer.Interval = 1000
        '
        'StreamIdx
        '
        Me.StreamIdx.Location = New System.Drawing.Point(554, 668)
        Me.StreamIdx.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.StreamIdx.Name = "StreamIdx"
        Me.StreamIdx.Size = New System.Drawing.Size(48, 20)
        Me.StreamIdx.TabIndex = 32
        Me.StreamIdx.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rgb_led
        '
        Me.rgb_led.Controls.Add(Me.GroupBox1)
        Me.rgb_led.Controls.Add(Me.enableLED)
        Me.rgb_led.Location = New System.Drawing.Point(4, 22)
        Me.rgb_led.Name = "rgb_led"
        Me.rgb_led.Size = New System.Drawing.Size(1622, 494)
        Me.rgb_led.TabIndex = 3
        Me.rgb_led.Text = "RGB LED"
        Me.rgb_led.UseVisualStyleBackColor = True
        '
        'enableLED
        '
        Me.enableLED.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.enableLED.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.enableLED.Location = New System.Drawing.Point(142, 36)
        Me.enableLED.Name = "enableLED"
        Me.enableLED.Size = New System.Drawing.Size(157, 46)
        Me.enableLED.TabIndex = 17
        Me.enableLED.Text = "Enable RGB LED"
        Me.enableLED.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Controls.Add(Me.Button14)
        Me.GroupBox1.Controls.Add(Me.Button15)
        Me.GroupBox1.Controls.Add(Me.Button16)
        Me.GroupBox1.Controls.Add(Me.Button17)
        Me.GroupBox1.Controls.Add(Me.Button18)
        Me.GroupBox1.Controls.Add(Me.Button19)
        Me.GroupBox1.Controls.Add(Me.Button20)
        Me.GroupBox1.Controls.Add(Me.Button21)
        Me.GroupBox1.Controls.Add(Me.Button22)
        Me.GroupBox1.Controls.Add(Me.Button23)
        Me.GroupBox1.Controls.Add(Me.Button24)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(87, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 281)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkGray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(175, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 38)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Smooth"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkGray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(176, 189)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 38)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Fade"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Crimson
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(119, 233)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 38)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "P"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.BlueViolet
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(120, 189)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 38)
        Me.Button4.TabIndex = 35
        Me.Button4.Text = "V"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(64, 233)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(50, 38)
        Me.Button5.TabIndex = 36
        Me.Button5.Text = "DS"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.SkyBlue
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Location = New System.Drawing.Point(64, 189)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 38)
        Me.Button6.TabIndex = 36
        Me.Button6.Text = "S"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Yellow
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(8, 233)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(50, 38)
        Me.Button7.TabIndex = 34
        Me.Button7.Text = "Y"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Orange
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(8, 189)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(50, 38)
        Me.Button8.TabIndex = 34
        Me.Button8.Text = "DY"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.DarkGray
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.Location = New System.Drawing.Point(176, 145)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(70, 38)
        Me.Button9.TabIndex = 29
        Me.Button9.Text = "Strobe"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Indigo
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Location = New System.Drawing.Point(120, 145)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(50, 38)
        Me.Button10.TabIndex = 31
        Me.Button10.Text = "I"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Aquamarine
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button11.ForeColor = System.Drawing.Color.Black
        Me.Button11.Location = New System.Drawing.Point(64, 145)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(50, 38)
        Me.Button11.TabIndex = 32
        Me.Button11.Text = "C"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Coral
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button12.ForeColor = System.Drawing.Color.White
        Me.Button12.Location = New System.Drawing.Point(8, 145)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(50, 38)
        Me.Button12.TabIndex = 30
        Me.Button12.Text = "O"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.DarkGray
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button13.Location = New System.Drawing.Point(176, 101)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(70, 38)
        Me.Button13.TabIndex = 25
        Me.Button13.Text = "Flash"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.SteelBlue
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button14.ForeColor = System.Drawing.Color.White
        Me.Button14.Location = New System.Drawing.Point(120, 101)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(50, 38)
        Me.Button14.TabIndex = 27
        Me.Button14.Text = "LB"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.LimeGreen
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button15.ForeColor = System.Drawing.Color.White
        Me.Button15.Location = New System.Drawing.Point(64, 101)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(50, 38)
        Me.Button15.TabIndex = 28
        Me.Button15.Text = "LG"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.OrangeRed
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button16.ForeColor = System.Drawing.Color.White
        Me.Button16.Location = New System.Drawing.Point(8, 101)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(50, 38)
        Me.Button16.TabIndex = 26
        Me.Button16.Text = "OR"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.White
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button17.Location = New System.Drawing.Point(175, 57)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(70, 38)
        Me.Button17.TabIndex = 21
        Me.Button17.Text = "W"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.Blue
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button18.ForeColor = System.Drawing.Color.White
        Me.Button18.Location = New System.Drawing.Point(120, 57)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(50, 38)
        Me.Button18.TabIndex = 24
        Me.Button18.Text = "B"
        Me.Button18.UseVisualStyleBackColor = False
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.Green
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button19.ForeColor = System.Drawing.Color.White
        Me.Button19.Location = New System.Drawing.Point(64, 57)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(50, 38)
        Me.Button19.TabIndex = 24
        Me.Button19.Text = "G"
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.Red
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button20.ForeColor = System.Drawing.Color.White
        Me.Button20.Location = New System.Drawing.Point(8, 57)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(50, 38)
        Me.Button20.TabIndex = 23
        Me.Button20.Text = "R"
        Me.Button20.UseVisualStyleBackColor = False
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.Brown
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button21.ForeColor = System.Drawing.Color.White
        Me.Button21.Location = New System.Drawing.Point(176, 13)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(69, 38)
        Me.Button21.TabIndex = 22
        Me.Button21.Text = "On"
        Me.Button21.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.Black
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button22.ForeColor = System.Drawing.Color.White
        Me.Button22.Location = New System.Drawing.Point(120, 13)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(50, 38)
        Me.Button22.TabIndex = 21
        Me.Button22.Text = "Off"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button23.Location = New System.Drawing.Point(64, 13)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(50, 38)
        Me.Button23.TabIndex = 20
        Me.Button23.Text = "-"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button24.Location = New System.Drawing.Point(6, 13)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(50, 38)
        Me.Button24.TabIndex = 19
        Me.Button24.Text = "+"
        Me.Button24.UseVisualStyleBackColor = False
        '
        'homeCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1654, 711)
        Me.Controls.Add(Me.StreamIdx)
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
        Me.Name = "homeCtrl"
        Me.Text = "Automata"
        Me.Tabs.ResumeLayout(False)
        Me.settingsPage.ResumeLayout(False)
        Me.settingsPage.PerformLayout()
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
        Me.surveilance.ResumeLayout(False)
        Me.SurveillanceGrp.ResumeLayout(False)
        CType(Me.StreamIdx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgb_led.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fetch As Button
    Friend WithEvents Temperature As Label
    Friend WithEvents Packet As TextBox
    Friend WithEvents debugButton As Button
    Friend WithEvents Connect As Button
    Friend WithEvents Timer10s As Timer
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
    Friend WithEvents TcpTimer As Timer
    Friend WithEvents surveilance As TabPage
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
    Friend WithEvents LiveFeed As Button
    Friend WithEvents Record As Button
    Friend WithEvents Recordings As Button
    Friend WithEvents StreamIdx As NumericUpDown
    Friend WithEvents rgb_led As TabPage
    Friend WithEvents enableLED As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button21 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button24 As Button
End Class
