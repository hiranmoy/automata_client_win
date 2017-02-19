Module colorFormat

    'updates temperature text and background label
    Public Sub UpdateTemperatureColor(val As Double)
        homeCtrl.Temperature.BackColor = GetBackcolor(val, 10, 25, 40)
        homeCtrl.Temperature.ForeColor = GetForecolor(val, 10, 40)
    End Sub

    'updates humidity text and background label
    Public Sub UpdateHumidityColor(val As Double)
        homeCtrl.Humidity.BackColor = GetBackcolor(val, 40, 60, 90)
        homeCtrl.Humidity.ForeColor = GetForecolor(val, 40, 90)
    End Sub

    'updates pressure text and background label
    Public Sub UpdatePressureColor(val As Double)
        homeCtrl.Pressure.BackColor = GetBackcolor(val, 970, 1015, 1030)
        homeCtrl.Pressure.ForeColor = GetForecolor(val, 970, 1030)
    End Sub

    'updates alcohol label
    Public Sub UpdateAlcoholColor(val As Double)
        homeCtrl.Alcohol.BackColor = GetBackcolor(val, 140, 170, 200)
        homeCtrl.Alcohol.ForeColor = GetForecolor(val, 140, 200)
    End Sub

    'updates CO label
    Public Sub UpdateCOColor(val As Double)
        homeCtrl.CO.BackColor = GetBackcolor(val, 110, 130, 200)
        homeCtrl.CO.ForeColor = GetForecolor(val, 110, 200)
    End Sub

    'returns back color
    Private Function GetBackcolor(curVal As Double, min As Double, opt As Double, max As Double) As Color
        Debug.Assert(max > min)

        'If the current value is less than the minimum value, return cyan color
        If curVal <= min Then
            Return Color.Cyan
        End If

        'If the current value is equal to the optimal value, return light green color
        If curVal = opt Then
            Return Color.LightGreen
        End If

        'If the current value is more than the maximum value, return red color
        If curVal >= max Then
            Return Color.Red
        End If

        'initialization
        Dim red As Integer = 255
        Dim green As Integer = 255
        Dim blue As Integer = 255

        If curVal < opt Then
            Dim range As Integer = opt - min

            'set color between between cyan and light green depending on the input value
            red = 144 * (curVal - min) / range
            green = 238 + 17 * (opt - curVal) / range
            blue = 144 + 111 * (opt - curVal) / range
        Else
            Dim range As Integer = max - opt

            'set color between between red and light green depending on the input value
            red = 144 + 111 * (curVal - opt) / range
            green = 238 * (max - curVal) / range
            blue = 144 * (max - curVal) / range
        End If

        Return Color.FromArgb(red, green, blue)
    End Function

    'returns text color
    Private Function GetForecolor(curVal As Double, min As Double, max As Double) As Color
        Debug.Assert(max > min)

        Dim range As Double = max - min

        'return white color if the input is between within 20% of the maximum value
        If curVal >= max - range * 0.2 Then
            Return Color.White
        End If

        'return red color if the input is between within 20% of the mimimum value
        If curVal <= min + range * 0.2 Then
            Return Color.Red
        End If

        'return blue color if input value > 20% of min and < 80% of max
        Return Color.Blue
    End Function

    'change motion detection checkbox color
    Public Sub UpdateMotionDetectCheckColor()
        If homeCtrl.MotionDetectCheck.Checked = True Then
            homeCtrl.MotionDetectCheck.ForeColor = Color.Red
        Else
            homeCtrl.MotionDetectCheck.ForeColor = Color.Green
        End If
    End Sub

    'change video checkbox color
    Public Sub UpdateVideoCheckColor()
        If homeCtrl.VideoCheck.Checked = True Then
            homeCtrl.VideoCheck.ForeColor = Color.Red
        Else
            homeCtrl.VideoCheck.ForeColor = Color.Green
        End If
    End Sub

    'change audio checkbox color
    Public Sub UpdateAudioCheckColor()
        If homeCtrl.AudioCheck.Checked = True Then
            homeCtrl.AudioCheck.ForeColor = Color.Red
        Else
            homeCtrl.AudioCheck.ForeColor = Color.Green
        End If
    End Sub

    'change speech checkbox color
    Public Sub UpdateSpeechCheckColor()
        If homeCtrl.SpeechCheck.Checked = True Then
            homeCtrl.SpeechCheck.ForeColor = Color.Red
        Else
            homeCtrl.SpeechCheck.ForeColor = Color.Green
        End If
    End Sub

End Module
