Imports System.Linq.Expressions
Imports System.Reflection





Public Class Form1

    Dim StrBufferEntrada As String    'guarda datos de entrada
    Dim StrBufferSalida As String      'guarda datos de salida
    Dim enviando As Boolean = False  'el estado no recibe datos si es true
    Dim modo As String
    Dim capacitores As String




    Private Delegate Sub DelegadoAcceso(ByVal AdicionarTexto As String)


    Private Sub AccesoFormPrincipal(ByVal TextoForm As String)
        StrBufferEntrada = TextoForm

        ''-------------------------
        Txtdatosrecibidos.Text = StrBufferEntrada


    End Sub

    Private Sub PuertaAccesoInterrupcion(ByVal BufferIn As String)
        Dim TextoInterrupcion() As Object = {BufferIn}
        Dim DelegadoInterrupcion As DelegadoAcceso
        DelegadoInterrupcion = New DelegadoAcceso(AddressOf AccesoFormPrincipal)
        MyBase.Invoke(DelegadoInterrupcion, TextoInterrupcion)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'inicio variables

        StrBufferEntrada = ""
        StrBufferSalida = ""
        Btnconectar.Enabled = False
        Btnevniardatos.Enabled = False

        modo = "1"
        capacitores = "0"
        Btnevniardatos.Enabled = False
    End Sub


    Private Sub Btnbuscarpuetos_Click(sender As Object, e As EventArgs) Handles Btnbuscarpuertos.Click


        Cbopuertos.Items.Clear() 'busca puertos diponibles

        For Each PuertoDiponible As String In My.Computer.Ports.SerialPortNames
            Cbopuertos.Items.Add(PuertoDiponible)
        Next

        If Cbopuertos.Items.Count >= 0 Then
            Cbopuertos.Text = Cbopuertos.Items(0)
            MessageBox.Show("seleccione puerto COM")
            Btnconectar.Enabled = True
        Else
            MessageBox.Show("no hay puertos diponibles")
            Cbopuertos.Items.Clear()

        End If
    End Sub

    Private Sub Btnconectar_Click(sender As Object, e As EventArgs) Handles Btnconectar.Click
        If Btnconectar.Text = "CONECTAR" Then

            Try
                With PuertoCom
                    .BaudRate = 57600
                    .DataBits = 8
                    .Parity = IO.Ports.Parity.None
                    .StopBits = IO.Ports.StopBits.One
                    .PortName = Cbopuertos.Text
                    .Open()
                End With
                Btnconectar.Text = "DESCONECTAR"
                Btnevniardatos.Enabled = True

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try
        ElseIf Btnconectar.Text = "DESCONECTAR" Then

            Btnconectar.Text = "CONECTAR"
            Btnevniardatos.Enabled = False
            PuertoCom.Close()

        End If
    End Sub



   


    'esto es una interrupcion que ocurre cuando recibe datos seriales
    Private Sub PuertoCom_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles PuertoCom.DataReceived
        Dim DatoInterrupcion As String
        DatoInterrupcion = PuertoCom.ReadLine

        PuertaAccesoInterrupcion(DatoInterrupcion)


    End Sub







    Private Sub AyudaToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Try
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Ayuda2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ayuda2ToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("https://github.com/Makiben/Ayuda-Bobinadora/blob/main/Ayuda%20Bobina")

        Catch ex As Exception

        End Try
    End Sub


End Class



' concatenar  tramas VB´'

'ingresar solo numeros L, cuando pones enviar datos verificar que todo este correcto,que los campos no esten vacios , desabilitar el boton enviar hasta que los textbox esten llenos L
'truncar los decimales 
'"#" & TxtVueltas.Text & "_" & TxtLongitud.Tex & "_" & TxtTxtCalibre'
