open System;;
open System.Windows.Forms;;

[<Literal>]
let HEIGHT = 400

type MainForm = class
    inherit Form
    val box : TextBox
    val ok  : Button
    val ng  : Button
    //
    member this.ok_Click(_) =
        let paths = this.box.Text.Replace(Environment.NewLine,";")
        Environment.SetEnvironmentVariable("PATH", paths, EnvironmentVariableTarget.User)
        this.Close()
    member this.ng_Click(_) = 
        this.Close()
    //
    new() as this = 
        {
            inherit Form(Width=900, Height=HEIGHT + 100, Text="Environment variable changer")
            box = new TextBox(Height=HEIGHT)
            ok  = new Button(Top=HEIGHT)
            ng  = new Button(Top=HEIGHT)
        }
        then
            //settings of objects
            this.box.ScrollBars <- ScrollBars.Vertical
            this.box.Multiline <- true
            this.box.Dock <- DockStyle.Top
            this.ng.Left <- this.ok.Width+5
            this.ok.Text <- "OK"
            this.ng.Text <- "Cancel"
            this.ok.Click.Add(this.ok_Click)
            this.ng.Click.Add(this.ng_Click)
            //add controls to this form
            this.Controls.Add(this.box)
            this.Controls.Add(this.ok)
            this.Controls.Add(this.ng)
            //get environmental variable of user
            let paths = Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.User);
            this.box.Text <- paths.Replace(";", Environment.NewLine)
end;;
[<STAThread>]
do System.Windows.Forms.Application.Run(new MainForm());;