Class MainWindow
  Private inClick As Boolean = False

  Private Sub BButtons_MouseEnter(sender As Object, e As MouseEventArgs) Handles bLogoff.MouseEnter, bSleep.MouseEnter, bRestart.MouseEnter, bShut_Down.MouseEnter
    txtBlock.Text = sender.Name.Replace("_", " ").Substring(1)
  End Sub

  Private Sub BButtons_MouseLeave(sender As Object, e As MouseEventArgs) Handles bLogoff.MouseLeave, bSleep.MouseLeave, bRestart.MouseLeave, bShut_Down.MouseLeave
    txtBlock.Text = ""
  End Sub

  Private Sub MainWindow_Deactivated(sender As Object, e As EventArgs) Handles Me.Deactivated
    If Not inClick Then Close()
  End Sub

  Private Sub BButtons_Click(sender As Object, e As RoutedEventArgs) Handles bLogoff.Click, bSleep.Click, bRestart.Click, bShut_Down.Click
    inClick = True
    Select Case sender.Name
      Case "bLogoff"
        Dim psi = New ProcessStartInfo("logoff") With {
          .UseShellExecute = False,
          .CreateNoWindow = True
        }
        Process.Start(psi)
        Close()

      Case "bSleep"
        Forms.Application.SetSuspendState(Forms.PowerState.Suspend, True, False)
        Close()

      Case "bRestart"
        Dim psi = New ProcessStartInfo("shutdown", "/f /t 0 /r") With {
          .UseShellExecute = False,
          .CreateNoWindow = True
        }
        Process.Start(psi)
        Close()

      Case "bShut_Down"
        Dim psi = New ProcessStartInfo("shutdown", "/f /t 0 /s") With {
          .UseShellExecute = False,
          .CreateNoWindow = True
        }
        Process.Start(psi)
        Close()

    End Select
    inClick = False
  End Sub
End Class
