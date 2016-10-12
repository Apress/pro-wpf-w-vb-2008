Imports System.Windows.Media.Animation

Public Class AnimatedVideoWindow

    Private Sub cmdPlayCode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the timeline.
        ' This isn't required, but it allows you to configure details
        ' that wouldn't otherwise be possible (like repetition).
        Dim timeline As New MediaTimeline(New Uri("test.mpg", UriKind.Relative))
        timeline.RepeatBehavior = RepeatBehavior.Forever

        ' Create the clock, which is shared with the MediaPlayer.
        Dim clock As MediaClock = timeline.CreateClock()
        Dim player As New MediaPlayer()
        player.Clock = clock

        ' Create the VideoDrawing.
        Dim videoDrawing As New VideoDrawing()
        videoDrawing.Rect = New Rect(150, 0, 100, 100)
        videoDrawing.Player = player

        ' Assign the DrawingBrush.
        Dim brush As New DrawingBrush(videoDrawing)
        Me.Background = brush

        ' Start the timeline.
        clock.Controller.Begin()


    End Sub
End Class