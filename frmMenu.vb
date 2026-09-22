Public Class frmMenu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formLibros As New frmConsultaLibros()
        formLibros.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formAutores As New frmConsultaAutores()
        formAutores.Show()
    End Sub
End Class