Public Class Form2
    Private otherForm As Form1
    Public Sub New(Inst As Form1)
        InitializeComponent()
        otherForm = Inst
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim pulist() As Process = Process.GetProcesses()
        For Each pla As Process In pulist
            ListBox1.Items.Add(pla.ProcessName + ".exe")
        Next
    End Sub
    Private Sub ChButton2_Click(sender As Object, e As EventArgs) Handles ChButton2.Click
        Me.Close()
    End Sub

    Private Sub ChButton1_Click(sender As Object, e As EventArgs) Handles ChButton1.Click
        Dim chestiaAia As String = ListBox1.SelectedItem
        otherForm.ChTextbox1.Text = chestiaAia
        Me.Close()
    End Sub
End Class