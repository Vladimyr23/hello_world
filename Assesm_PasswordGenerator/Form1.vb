Public Class Form1
    'App path that used to make the saved text file to be placed at the same place with app executable file
    Dim Application_Path As String = Application.ExecutablePath()
    'String Value that contant all the information to be saved 
    Dim save_string As String
    'values to check validation of the data entered into the password fields
    Dim ch(99) As Char
    Dim len As Integer

    'Current time display arrangement
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TimerTest As Timer = New Timer
        TimerTest.Interval = 1000
        AddHandler TimerTest.Tick, AddressOf Time_Tick
        TimerTest.Start()
        TextBox1.Text = Format("00", "00")
        TextBox2.Text = Format("00", "00")
        TextBox3.Text = Format("00", "00")
        TextBox4.Text = Format("00", "00")

    End Sub

    'Label to display the current date/time
    Private Sub Time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblTime_Date.Text = DateTime.Now.ToString()
    End Sub

    'Random number generator for each textBox
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

        Randomize()

        TextBox1.Text = Format(CInt(Int(100 * Rnd())), "00")
        TextBox2.Text = Format(CInt(Int(100 * Rnd())), "00")
        TextBox3.Text = Format(CInt(Int(100 * Rnd())), "00")
        TextBox4.Text = Format(CInt(Int(100 * Rnd())), "00")
    End Sub

    'Button to exit the app
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
        End
    End Sub

    'Next part saves the Time when the button 'Save' pressed, Note to the password and the generated code also it replaces the empty characters with 0 (where 5 replaced with 05)
    'with the EOL at the end to make next password saved from the new line
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If TextBox1.Text.Length = 1 Then
            TextBox1.Text = "0" + TextBox1.Text
        ElseIf TextBox1.Text.Length = 0 Then
            TextBox1.Text = "00"
        End If
        Format(TextBox1.Text, "00")

        If TextBox2.Text.Length = 1 Then
            TextBox2.Text = "0" + TextBox2.Text
        ElseIf TextBox2.Text.Length = 0 Then
            TextBox2.Text = "00"
        End If
        Format(TextBox2.Text, "00")

        If TextBox3.Text.Length = 1 Then
            TextBox3.Text = "0" + TextBox3.Text
        ElseIf TextBox3.Text.Length = 0 Then
            TextBox3.Text = "00"
        End If
        Format(TextBox3.Text, "00")

        If TextBox4.Text.Length = 1 Then
            TextBox4.Text = "0" + TextBox4.Text
        ElseIf TextBox4.Text.Length = 0 Then
            TextBox4.Text = "00"
        End If
        Format(TextBox4.Text, "00")

        save_string = lblTime_Date.Text + "::" + txtBoxNote.Text + "::" + TextBox1.Text + TextBox2.Text + TextBox3.Text + TextBox4.Text
        My.Computer.FileSystem.WriteAllText(Application_Path + "saved_values.txt", save_string + "
", True)

        MsgBox("Generated code was added into the file: " + Application_Path + "Saved_values.txt" + " at " + lblTime_Date.Text, MessageBoxButtons.OK, "Save message")
    End Sub

    'This part of the program cheks if the value entred by user in a one of 4 passcode fields is NUMERIC value
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        len = TextBox1.Text.Length
        ch = TextBox1.Text.ToCharArray()
        For i = 0 To len - 1
            If Not IsNumeric(ch(i)) Then
                MsgBox("Value you are trying to insert is not numeric.", MsgBoxStyle.Exclamation, "Warning!")
                TextBox1.Clear()
            End If
        Next

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        len = TextBox2.Text.Length
        ch = TextBox2.Text.ToCharArray()
        For i = 0 To len - 1
            If Not IsNumeric(ch(i)) Then
                MsgBox("Value you are trying to insert is not numeric.", MsgBoxStyle.Exclamation, "Warning!")
                TextBox2.Clear()
            End If
        Next
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        len = TextBox3.Text.Length
        ch = TextBox3.Text.ToCharArray()
        For i = 0 To len - 1
            If Not IsNumeric(ch(i)) Then
                MsgBox("Value you are trying to insert is not numeric.", MsgBoxStyle.Exclamation, "Warning!")
                TextBox3.Clear()
            End If
        Next
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        len = TextBox4.Text.Length
        ch = TextBox4.Text.ToCharArray()
        For i = 0 To len - 1
            If Not IsNumeric(ch(i)) Then
                MsgBox("Value you are trying to insert is not numeric.", MsgBoxStyle.Exclamation, "Warning!")
                TextBox4.Clear()
            End If
        Next
    End Sub

    'Help button
    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Press 'Generate' button to generate a numeric 8 digit code in a format ##-##-##-## above the 'Generate' button.
In case you would like to type your own numeric code, key it into the boxes or change digits in generated code.
Empty fields will be replaced with zeros.
To leave a note to the passcode type it in the note field.
The note can be up to 22 symbols long.
Finally, to save the passcode with current time/date and the 'Note', press 'Save' button at the bottom of app window.
After 'Save' button pressed the message, pointing the text file name which is located at the root of main application file  will appear.",
                MessageBoxButtons.OK, "Password generator Help")
    End Sub
End Class
