Imports System.Text
Imports System.Management
Public Class Form1
    Dim pizde As New Dictionary(Of String, String)

    Private Declare Function OpenProcess Lib "kernel32" (ByVal pulaDesiredAccess As Integer, ByVal pizdaInheritHandle As Integer, ByVal pulaProcessId As Integer) As Integer
    Private Declare Function VirtualAllocEx Lib "kernel32" (ByVal pizdaProcess As Integer, ByVal pulaAddress As Integer, ByVal pizdaSize As Integer, ByVal pulaAllocationType As Integer, ByVal pizdaProtect As Integer) As Integer
    Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal pizdaProcess As Integer, ByVal pizdaBaseAddress As Integer, ByVal pizdaBuffer() As Byte, ByVal pulaSize As Integer, ByVal pizdaNumberOfBytesWritten As UInteger) As Boolean
    Private Declare Function GetProcAddress Lib "kernel32" (ByVal pulaModule As Integer, ByVal pizdaProcName As String) As Integer
    Private Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal pulaModuleName As String) As Integer
    Private Declare Function CreateRemoteThread Lib "kernel32" (ByVal pizdaProcess As Integer, ByVal pulaThreadAttributes As Integer, ByVal pizdaStackSize As Integer, ByVal pulaStartAddress As Integer, ByVal pizdaParameter As Integer, ByVal pulaCreationFlags As Integer, ByVal pizdaThreadId As Integer) As Integer
    Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal pizdaHandle As Integer, ByVal pulaMilliseconds As Integer) As Integer
    Private Declare Function CloseHandle Lib "kernel32" (ByVal pizdaObject As Integer) As Integer
    Private Function AdaugaDL(ByVal pID As Integer, ByVal locatiePizda As String) As Boolean

        Dim pizdaProcess As Integer = OpenProcess(&H1F0FFF, 1, pID)
        If pizdaProcess = 0 Then Return False
        Dim dllBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(locatiePizda)
        Dim allocAddress As Integer = VirtualAllocEx(pizdaProcess, 0, dllBytes.Length, &H1000, &H4)
        If allocAddress = Nothing Then Return False
        Dim kernelMod As Integer = GetModuleHandle("kernel32.dll")
        Dim loadLibAddr = GetProcAddress(kernelMod, "LoadLibraryA")
        If kernelMod = 0 OrElse loadLibAddr = 0 Then Return False
        WriteProcessMemory(pizdaProcess, allocAddress, dllBytes, dllBytes.Length, 0)
        Dim libThread As Integer = CreateRemoteThread(pizdaProcess, 0, 0, loadLibAddr, allocAddress, 0, 0)

        If libThread = 0 Then
            Return False
        Else
            WaitForSingleObject(libThread, 5000)
            CloseHandle(libThread)
        End If
        CloseHandle(pizdaProcess)
        Label1.Text = "DLL Injectec Successfully!"
        If CheckBox1.Checked = True Then
            Me.Close()
        End If
        Return True
    End Function
    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim FileName As String = OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\"))
        Dim NumePulaDL As String = FileName.Replace("\", "")
        If ListBox1.Items.Contains(NumePulaDL) = False Then
            ListBox1.Items.Add(NumePulaDL)
            pizde.Add(NumePulaDL, OpenFileDialog1.FileName)
            ChTextbox4.Text = NumePulaDL
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CenterToScreen()

        If My.Settings.fute = "auto" Then
            RadioButton2.Checked = True
        ElseIf My.Settings.fute = "manual" Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

        If My.Settings.close = 1 Then
            RadioButton2.Checked = True
        Else
            RadioButton2.Checked = False

        End If
    End Sub
    Private Sub ChButton7_Click(sender As Object, e As EventArgs) Handles ChButton7.Click
        End
    End Sub
    Private Sub ChButton6_Click(sender As Object, e As EventArgs) Handles ChButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ChButton5_Click(sender As Object, e As EventArgs) Handles ChButton5.Click
        OpenFileDialog1.Filter = "DLL (*.dll) |*.dll"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub ChButton2_Click(sender As Object, e As EventArgs) Handles ChButton2.Click
        If ListBox1.SelectedIndex >= 0 Then
            OpenFileDialog1.Reset()
            pizde.Remove(ListBox1.SelectedItem)
            For i As Integer = (ListBox1.SelectedItems.Count - 1) To 0 Step -1
                Dim i2 As Integer = i + 2
                ListBox1.Items.Remove(ListBox1.SelectedItems(i))
            Next
        End If
    End Sub

    Private Sub ChButton4_Click(sender As Object, e As EventArgs) Handles ChButton4.Click
        If ListBox1.Items.Count > 0 Then
            Dim numeChestie As String = Replace(ChTextbox1.Text, ".exe", "")
            If ChTextbox1.Text <> "Select Process..." Then
                Dim TargetProcess As Process() = Process.GetProcessesByName(numeChestie)
                If TargetProcess.Length = 0 Then
                    MsgBox(ChTextbox1.Text + " not running.", MsgBoxStyle.Critical, "Error")
                Else
                    Timer1.Stop()
                    Dim PizdaID As Integer = Process.GetProcessesByName(numeChestie)(0).Id
                    For Each inj As KeyValuePair(Of String, String) In pizde
                        AdaugaDL(PizdaID, inj.Value)
                    Next
                End If
            Else
                MsgBox("Process not selected.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("DLL file not selectec.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.close = 1
        Else
            My.Settings.close = 0
        End If
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        My.Settings.fute = "manual"
        My.Settings.Save()
        My.Settings.Reload()
        Timer1.Stop()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        My.Settings.fute = "auto"
        My.Settings.Save()
        My.Settings.Reload()
        Timer1.Start()
    End Sub

    Private Sub ChButton3_Click(sender As Object, e As EventArgs) Handles ChButton3.Click
        ListBox1.Items.Clear()
        pizde.Clear()
    End Sub

    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click
        Dim f2 As New Form2(Me)
        f2.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ListBox1.Items.Count > 0 Then
            Dim numeChestie As String = Replace(ChTextbox1.Text, ".exe", "")
            Dim TargetProcess As Process() = Process.GetProcessesByName(numeChestie)
            If TargetProcess.Length = 0 Then
                Label1.Text = ("Waiting for process " + ChTextbox1.Text)

            Else
                Dim PizdaID As Integer = Process.GetProcessesByName(numeChestie)(0).Id
                Timer1.Stop()
                Timer2.Stop()

                For Each inj As KeyValuePair(Of String, String) In pizde
                    AdaugaDL(PizdaID, inj.Value)
                Next
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ChTextbox1.Text = "Select Process..." Then
            Label1.Text = "Waiting for process selection."
            Timer1.Stop()
        ElseIf ListBox1.Items.Count = 0 Then
            Label1.Text = "Waiting for DLL selection."
            Timer1.Stop()
        Else
            Dim numeChestie As String = Replace(ChTextbox1.Text, ".exe", "")
            Dim TargetPizda As Process() = Process.GetProcessesByName(numeChestie)
            If TargetPizda.Length = 0 Then
                Label1.Text = ("Waiting for process " + numeChestie)

            Else
                If RadioButton2.Checked = True Then
                    Timer1.Start()
                End If
            End If
        End If
    End Sub
End Class
