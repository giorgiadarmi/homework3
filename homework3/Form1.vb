Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Path As String = "C:\Users\giorgia.darmiento\source\repos\homework3\wireshark.csv"

        Dim ListOfUnits As New List(Of Packet)
        Me.RichTextBox1.AppendText("Distribution of data from wireshark:" & Environment.NewLine & Environment.NewLine)

        Using R As New TextFieldParser(Path)

            R.Delimiters = New String() {","}

            Dim NamesOfVariables As String = R.ReadLine

            Do While Not R.EndOfData

                Dim Values() As String = R.ReadFields()

                Dim Packet As New Packet

                'fille the fields with actual data

                Packet.No = Values(0)
                Packet.Time = Values(1)
                Packet.Source = Values(2)
                Packet.Destination = Values(3)
                Packet.Protocol = Values(4)
                Packet.Length = Values(5)
                Me.RichTextBox1.AppendText(" No: " & Packet.No.ToString().PadRight(15) & " Time: " & Packet.Time.ToString().PadRight(15) &
                                           " Source: " & Packet.Source.ToString().PadRight(80) & " Destination: " & Packet.Destination.ToString().PadRight(80) &
                                           " Protocol: " & Packet.Protocol.ToString().PadRight(15) & " Length: " & Packet.Length.ToString().PadRight(15) & Environment.NewLine & Environment.NewLine)
                Dim ListOfLength As New List(Of Double)
                ListOfLength.Add(CDbl(Packet.Length))

                Dim Avarage_Online As Double = Me.ComputationOfArithmeticMean_OnlineAlgo(ListOfLength)
                Me.RichTextBox1.AppendText("Arithmetic mean of length (online formula):  " & Avarage_Online & Environment.NewLine)
                ListOfUnits.Add(Packet)



            Loop

        End Using




    End Sub

    Function ComputationOfArithmeticMean_OnlineAlgo(ListOfLength As List(Of Double)) As Double
        Dim Avarage_Online As Double = 0
        Dim CurrentIndex As Integer = 0

        For Each v As Double In ListOfLength
            CurrentIndex += 1
            Avarage_Online += (v - Avarage_Online) / CurrentIndex
        Next
        Return Avarage_Online
    End Function

End Class

Public Class Packet
    Public No As Integer
    Public Time As String
    Public Source As String
    Public Destination As String
    Public Protocol As String
    Public Length As String
End Class